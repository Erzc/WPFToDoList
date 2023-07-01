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
            int totalNumCharges = 0;
            decimal cost = 0;
            string title = titleTb.Text;
            string description = descriptionTb.Text;
            string chargeFreqS = "None";
            DateTime currentDT = DateTime.Now;
            TimeSpan duration = userDT - currentDT;

            if (string.IsNullOrEmpty(costTb.Text))
            {
                cost = 0;
            }
            else
            {
                try
                {
                    cost = decimal.Parse(costTb.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("The cost must be in decimal format.");
                }
                catch (OverflowException)
                {
                    MessageBox.Show("The cost value is either too small or too large.");
                }
            }

            chargeFreqS = costTypeCob.SelectedItem.ToString();

            //If first item selected, get day between two dates
            if (costTypeCob.SelectedIndex == 0) //Daily
            {
                totalNumCharges = (int)duration.TotalDays;
            }
            else if (costTypeCob.SelectedIndex == 1) //Monthly
            {
                //Calculate difference in years first, then months
                totalNumCharges = (userDT.Year - currentDT.Year) * 12 + (userDT.Month - currentDT.Month);
            }
            else if (costTypeCob.SelectedIndex == 2) //Yearly
            {
                totalNumCharges = (int)(duration.TotalDays / 365.25);
            }
            else if (costTypeCob.SelectedIndex == 3) //One time
            {
                totalNumCharges = 1;
            }
            //If no combobox item selected but cost entered
            else
            {
                if (cost != 0)
                {
                    MessageBox.Show("Please select a cost frequency.");
                }
            }


            if (userDT <= currentDT)
            {
                MessageBox.Show("Please choose a future deadline date.");
            }
            //Short term goal is less than 1 year from the current time
            else if ((userDT.Year - currentDT.Year) < 1)
            {
                ToDoItem = new ShortTermItem(cost, totalNumCharges, chargeFreqS, title, description, userDT);
                DialogResult = true;
                Close();
            }
            //Long term goal is greater than 1 year
            else
            {
                ToDoItem = new LongTermItem(cost, totalNumCharges, chargeFreqS, title, description, userDT);
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
