using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace To_Do_List
{
    class ToDoList
    {
        //Initialize a list of ToDoItem objects for to do lists
        public List<ToDoItem> toDoItemList = new List<ToDoItem>();

        //Properties
        public decimal Price { get; set; }
        public string UserName { get; set; }
        public ToDoItem RewriteToDoItem { get; set; }

        //For toDoItemList access in MainListForm
        public List<ToDoItem> TDList
        {
            get { return toDoItemList; }
            set { toDoItemList = value; }
        }

        public decimal TotalCost { get; set; }


        //Methods:

        public void Add(ToDoItem item)
        {
            toDoItemList.Add(item);

            Calc();
        }


        public void Delete(ToDoItem item)
        {
            toDoItemList.Remove(item);
        }


        public void Edit(int num, ToDoItem item)
        {
            //toDoItemList.Add(item);

            toDoItemList[num] = item;

            Calc();
        }


        internal void RewriteList(List<string> repToDoList)
        {
            //Clear the list
            toDoItemList.Clear();

            DateTime currentDT = DateTime.Now;

            for (int i = 0; i < repToDoList.Count; i+=5) {
            //foreach (string item in repToDoList)

                int id = Convert.ToInt32(repToDoList[i]);
                string title = repToDoList[i + 1];
                string description = repToDoList[i + 2];
                DateTime userDT = DateTime.Parse(repToDoList[i + 3]);
                decimal cost = decimal.Parse(repToDoList[i + 4]);

                //Short term goal is less than 1 year from the current time
                if ((userDT.Year + currentDT.Year) < 1)
                {
                    toDoItemList.Add(new ShortTermItem(id, cost, title, description, userDT));
                }
                //Long term goal is greater than 1 year
                else
                {
                    toDoItemList.Add(new LongTermItem(id, cost, title, description, userDT));
                }

            }

        }


        //Calculate the total 
        private void Calc()
        {
            TotalCost = 0;

            //implicit type
            foreach (var item in toDoItemList)
            {
                TotalCost += item.Cost;
            }
        }






    }
}
