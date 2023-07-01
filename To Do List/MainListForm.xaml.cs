using Microsoft.Win32; //for SafeFileDialog
using System;
using System.Collections.Generic;
using System.IO; //for File
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace To_Do_List
{
    /// <summary>
    /// Interaction logic for MainListForm.xaml
    /// </summary>
    public partial class MainListForm : Window
    {
        //Declare class objects
        private readonly ToDoList newToDoList = new();
        private ModifyItemsForm newModifyItemsForm = new();
        private string username = "";

        public MainListForm()
        {
            InitializeComponent(); //Initialze windows content

            //Populate ListBox data
            mainformLb.ItemsSource = newToDoList.TDList;
        }

        //Implicitly call Shutdown when the MainWindow closes
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }

        //Event handlers

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            //Instantiate new instance of modifyitemsform
            newModifyItemsForm = new ModifyItemsForm();
            newModifyItemsForm.ShowDialog();

            //Add new to do object depending on action taken by the user when new window is closed
            if (newModifyItemsForm.DialogResult == true)
            {
                MessageBox.Show("Todo item added");
                newToDoList.Add(newModifyItemsForm.ToDoItem);
                mainformLb.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Action cancelled");
            }

        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            if (mainformLb.SelectedItem != null)
            {
                //Instantiate new instance of modifyitemsform
                newModifyItemsForm = new ModifyItemsForm();

                var selectedObject = (ToDoItem)mainformLb.SelectedItem;

                //Set selected class object's parameter into UI elements
                newModifyItemsForm.titleTb.Text = selectedObject.Title;
                newModifyItemsForm.descriptionTb.Text = selectedObject.Desc;
                newModifyItemsForm.dueDateCalendar.SelectedDate = selectedObject.UserDT;

                newModifyItemsForm.costTypeCob.SelectedItem = selectedObject.ChargeFreqS;
                newModifyItemsForm.costTb.Text = selectedObject.Cost.ToString();




                int userIndex = mainformLb.SelectedIndex;

                newModifyItemsForm.ShowDialog();


                if (newModifyItemsForm.DialogResult == true)
                {
                    MessageBox.Show("Todo item edited");
                    newToDoList.Edit(userIndex, newModifyItemsForm.ToDoItem);
                    //Update listbox so it has all the items in the source
                    mainformLb.Items.Refresh();
                }
                else
                {
                    MessageBox.Show("Edit cancelled");
                }

            }
            else
            {
                MessageBox.Show("Please select an item to edit");
            }

        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (mainformLb.SelectedItem != null)
            {
                MessageBox.Show("Item removed successfuly");
                newToDoList.Delete((ToDoItem)mainformLb.SelectedItem);
                //Update listbox so it has all the items in the source
                mainformLb.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Please select an item to delete");
            }
        }

        //Save final summary to a text file
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            //Uses name textbox for the arguments needed in property
            if (nameTb.Text == "" || nameTb.Text == "Your name here")
            {
                MessageBox.Show("Please enter your name");
            }
            else
            {
                username = nameTb.Text;

                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.DefaultExt = ".txt"; //Sets default file extension
                saveDialog.Filter = "Text Files|*.txt"; //Added to display nicely

                //Nullable bool, shows save to dialog
                bool? result = saveDialog.ShowDialog();
                if (result == true)
                {
                    string path = saveDialog.FileName;
                    string s = ""; //Clear string for multiple saves
                    s += username + "'s ToDo List:\n\n"; //Append name and title

                    foreach (ToDoItem item in newToDoList.TDList)
                    {
                        //Append ToString from list of class objects
                        s += item.ToString() + "\n\n";
                    }

                    //Method WriteAllText()
                    File.WriteAllText(path, s);
                }
            }

        }

        private void openButton_Click(object sender, RoutedEventArgs e)
        {
            //Check if user wants to replace list
            MessageBoxResult response = MessageBox.Show("Warning!\n\nThis will replace your current todo list, are you sure you want to continue?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);

            //If yes, show dialog to open the text file
            if (response == MessageBoxResult.Yes)
            {
                var openDialog = new OpenFileDialog();
                openDialog.Filter = "Text Files|*.txt";

                if (openDialog.ShowDialog() == true)
                {
                    string path = openDialog.FileName;

                    try
                    {
                        //Read lines from text file
                        string[] toDoLines = File.ReadAllLines(path);

                        //Process strings after prefixes in each line, declare new class objects, and replace the toDoItemList
                        newToDoList.Rewrite(toDoLines);

                        //Split name array element based on apostrophe, display name string in textbox, refresh listbox
                        string[] words = toDoLines[0].Split('\'');
                        nameTb.Text = words[0];
                        mainformLb.Items.Refresh();
                    }
                    catch (IOException ex)
                    {
                        MessageBox.Show($"Error! This text file could not be read: {ex.Message}");
                    }
                }
            }

        }

    }
}
