using System;
using System.Collections.Generic;
using System.Linq;
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

            //set variables
        }


        //Event handlers






    }
}
