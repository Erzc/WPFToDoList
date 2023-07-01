using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

namespace To_Do_List
{
    class ToDoList
    {
        //Initialize a list of ToDoItem objects
        public List<ToDoItem> toDoItemList = new();

        //Properties

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
            toDoItemList[num] = item;

            Calc();
        }

        public void Rewrite(string[] replToDo)
        {
            //Clear the old list
            toDoItemList.Clear();

            //Local vars
            DateTime currentDT = DateTime.Now;
            string titlePrefix = "Title: ";
            string descPrefix = "Description: ";
            string deadlinePrefix = "Deadline: ";

            string costFreqPrefix = "Cost Frequency: ";
            string totalNumChargesPrefix = "Total Charges: ";
            string oneCostPrefix = "One Time Cost: $";
            string totalCostPrefix = "Total Cost: $";

            //Process lines to extract the string after each prefix, then convert into appropriate type
            for (int i = 2; i < replToDo.Length; i += 9)
            {



                string title = replToDo[i + 1].Substring(titlePrefix.Length);
                string description = replToDo[i + 2].Substring(descPrefix.Length);
                DateTime userDT = DateTime.Parse(replToDo[i + 3].Substring(deadlinePrefix.Length));
                
                int totalNumCharges = Convert.ToInt32(replToDo[i + 4].Substring(costFreqPrefix.Length));
                string chargeFreqS = replToDo[i + 5].Substring(totalNumChargesPrefix.Length);
                decimal cost = decimal.Parse(replToDo[i + 6].Substring(oneCostPrefix.Length));
                decimal totalCost = decimal.Parse(replToDo[i + 7].Substring(totalCostPrefix.Length));

                //Short term goal is less than 1 year from the current time
                if ((userDT.Year - currentDT.Year) < 1)
                {
                    toDoItemList.Add(new ShortTermItem(cost, totalNumCharges, chargeFreqS, title, description, userDT));
                }
                //Long term goal is greater than 1 year
                else
                {
                    toDoItemList.Add(new LongTermItem(cost, totalNumCharges, chargeFreqS, title, description, userDT));
                }

            }

        }


        //Calculate the total 
        private void Calc()
        {
            TotalCost = 0;

            foreach (var item in toDoItemList)
            {
                TotalCost += item.Cost;
            }
        }






    }
}
