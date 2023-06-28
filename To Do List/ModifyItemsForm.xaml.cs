using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Sockets;
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
    /// Interaction logic for ModifyItemsForm.xaml
    /// </summary>
    public partial class ModifyItemsForm : Window
    {
        DateTime userDT = new(2023, 1, 20, 12, 30, 0);

        public ModifyItemsForm()
        {
            InitializeComponent();
        }

        //Auto-property
        public ToDoItem ToDoItem { get; set; } = new ShortTermItem();

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            int id = 0;
            decimal cost = 0;
            string title = titleTb.Text;
            string description = descriptionTb.Text;
            DateTime currentDT = DateTime.Now;

            //Exception handling to convert strings to int and decimal values
            try {
                id = Convert.ToInt32(idTb.Text);
            }
            catch (FormatException) {
                MessageBox.Show("The id value must be an integer.");
            }
            catch (OverflowException) {
                MessageBox.Show("The id value is either too small or too large.");
            }


            try {
                cost = decimal.Parse(costTb.Text);
            }
            catch (FormatException) {
                MessageBox.Show("The cost must be in decimal format.");
            }
            catch (OverflowException) {
                MessageBox.Show("The cost value is either too small or too large.");
            }


            if (userDT <= currentDT) {
                MessageBox.Show("Please choose a future deadline date.");
            }
            //Short term goal is less than 1 year from the current time
            else if ((userDT.Year - currentDT.Year) < 1) {
                ToDoItem = new ShortTermItem(id, cost, title, description, userDT);
                DialogResult = true;
                Close();
            }
            //Long term goal is greater than 1 year
            else {
                ToDoItem = new LongTermItem(id, cost, title, description, userDT);
                DialogResult = true;
                Close();
            }

        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void dateChanged(object sender, SelectionChangedEventArgs e)
        {
            userDT = dueDateCalendar.SelectedDate ?? DateTime.MinValue;
            //Console.WriteLine($"User selected the date: {userDT.ToShortDateString()}");
        }
    }
}
