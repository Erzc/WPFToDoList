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
        bool validCost = true;
        decimal cost = 0;



        public ModifyItemsForm()
        {
            InitializeComponent();

            //Format textboxes
            costTb.TextAlignment = TextAlignment.Center;

            //Format colors
            descriptionTb.Background = Brushes.LightGray;
            titleTb.Background = Brushes.LightGray;
            costTb.Background = Brushes.LightGray;
            costTypeCob.Background = Brushes.LightGray;
            submitButton.Foreground = Brushes.Green;
            cancelButton.Foreground = Brushes.DarkRed;
        }

        //Auto-property
        public ToDoItem ToDoItem { get; set; } = new ShortTermItem();

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            //Local vars
            int totalNumCharges = 0;
            string description = descriptionTb.Text, title = "", chargeFreqS = "";
            DateTime currentDT = DateTime.Now;
            TimeSpan duration = userDT - currentDT;

            //Manually invoke event handler to validate cost value
            costTb_LostFocus(costTb, new RoutedEventArgs());

            //Validate correct/missing information
            if (string.IsNullOrEmpty(titleTb.Text))
            {
                MessageBox.Show("Please enter a title.");
            }
            else if (userDT <= currentDT)
            {
                MessageBox.Show("Please choose a future deadline date.");
            }
            else if (string.IsNullOrEmpty(costTypeCob.Text) && cost != 0)
            {
                MessageBox.Show("Please select a cost frequency.");
            }
            else if (validCost)
            {
                title = titleTb.Text;

                //Check if no combobox selection
                if (costTypeCob.SelectedIndex == -1)
                {
                    chargeFreqS = "";
                }
                else
                {
                    chargeFreqS = ((ComboBoxItem)costTypeCob.SelectedItem).Content.ToString();
                }

                //If first combobox item selected, get day between two dates
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
                //If no combobox item selected
                else
                {
                    totalNumCharges = 0;
                }


                //Short term goal is less than 1 year from the current time
                if ((userDT.Year - currentDT.Year) < 1)
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
            else
            {
                MessageBox.Show("The cost is not valid.");
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

        private void costTb_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(costTb.Text))
            {
                cost = 0;
                validCost = true;
            }
            else
            {
                try
                {
                    cost = decimal.Parse(costTb.Text);
                    validCost = true;
                }
                catch (FormatException)
                {
                    MessageBox.Show("The cost must be in decimal format.");
                    validCost = false;
                }
                catch (OverflowException)
                {
                    MessageBox.Show("The cost value is either too small or too large.");
                    validCost = false;
                }
            }
        }

    }
}
