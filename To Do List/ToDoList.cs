using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace To_Do_List
{
    class ToDoList
    {
        //Initialize a list of ToDoItem objects for to do lists
        public List<ToDoItem> toDoItemList = new List<ToDoItem>();

        //Properties
        public decimal Price { get; set; }
        public string UserName { get; set; }


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
