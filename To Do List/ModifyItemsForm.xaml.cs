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
        public ModifyItemsForm()
        {
            InitializeComponent();
        }

        //Auto-property
        public ToDoItem ToDoItem { get; set; }

        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            string title = titleTb.Text; ;
            string description = descriptionTb.Text;

            Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void dateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime userDate = dueDateCalendar.SelectedDate ?? DateTime.MinValue;
            Console.WriteLine($"User selected date: {userDate.ToShortDateString()}");
        }
    }
}
