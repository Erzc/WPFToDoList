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
        private ToDoList newToDoList;
        private ModifyItemsForm newModifyItemsForm;

        public MainListForm()
        {
            InitializeComponent();

            //Instantiate new instance of the ToDoList
            newToDoList = new ToDoList();

            //Set te ItemsSource for the main ListBox
            mainformLb.ItemsSource = newToDoList.TDList;
        }

        //Event handlers

        private void addButton_Click(object sender, RoutedEventArgs e)
        {

            //Instantiate new instance of modifyitemsform
            newModifyItemsForm = new ModifyItemsForm();
            newModifyItemsForm.ShowDialog();

            if (newModifyItemsForm.DialogResult == true)
            {
                MessageBox.Show("Todo item added")
;               newToDoList.Add(newModifyItemsForm.ToDoItem);
            }
            else
            {
                MessageBox.Show("Error! Action cancelled");
            }

        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            //Instantiate new instance of modifyitemsform
            newModifyItemsForm = new ModifyItemsForm();
            newModifyItemsForm.ShowDialog();

            string numVal = editNumTb.Text;
            int itemIndex = 0;

            //Parse textbox value to integer with exception handling
            try
            {
                itemIndex = int.Parse(numVal);
                MessageBox.Show($"Parsed integer: {itemIndex}"); //Debugging----------------
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid number! Please enter an integer in the textbox.");
            }
            catch (OverflowException)
            {
                MessageBox.Show("This number is too small or too large.");
            }


            //TODO: Set item in new dialogue


            if (newModifyItemsForm.DialogResult == true)
            {
                MessageBox.Show("Todo item edited")
;               newToDoList.Edit(itemIndex, newModifyItemsForm.ToDoItem);
            }
            else
            {
                MessageBox.Show("Error! Edit cancelled");
            }

        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (mainformLb.SelectedItem != null)
            {
                MessageBox.Show("Item removed successfuly");
                newToDoList.Delete((ToDoItem)mainformLb.SelectedItem);
                //Updates listbox so it has all the items in the source
                mainformLb.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Error! Please select an item");
            }
        }

        //Save final summary to a text file
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            //Uses name textbox for the arguments needed in property
            newToDoList.UserName = nameTb.Text;

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = ".txt"; //Sets default file extension
            saveDialog.Filter = "Text Files|*.txt"; //Added to display nicely

            //Nullable bool, shows save to dialog
            bool? result = saveDialog.ShowDialog();
            if (result == true)
            {
                string path = saveDialog.FileName;
                string s = "";

                s += newToDoList.ToString(); //Appends ToString

                foreach (ToDoItem item in newToDoList.TDList)
                {
                    //Appends ToString from list of class objects
                    s += item.ToString() + "\n";
                }

                //Method WriteAllText()
                File.WriteAllText(path, s);
            }

        }


    }
}
