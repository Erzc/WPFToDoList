using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
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

            Calc();
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

            //Regular expression pattern matches a colon, then any number of spaces (\s*),
            //then takes the remaining information ((.*)) until the end of the string ($)
            string colonPattern = @":\s*(.*)$";
            string dollarPattern = @"\$\s*(.*)$";

            //Process lines to extract the string after each prefix, then convert into appropriate type
            for (int i = 2; i < replToDo.Length; i += 9)
            {
                string title = Regex.Match(replToDo[i], colonPattern).Groups[1].Value.Trim();
                string description = Regex.Match(replToDo[i+1], colonPattern).Groups[1].Value.Trim();
                DateTime userDT = DateTime.Parse(Regex.Match(replToDo[i+2], colonPattern).Groups[1].Value.Trim());

                string chargeFreqS = Regex.Match(replToDo[i+3], colonPattern).Groups[1].Value.Trim();
                int totalNumCharges = Convert.ToInt32(Regex.Match(replToDo[i+4], colonPattern).Groups[1].Value.Trim());
                decimal cost = decimal.Parse(Regex.Match(replToDo[i+5], dollarPattern).Groups[1].Value.Trim()); //Dollar pattern
                string totalCost = Regex.Match(replToDo[i+6], dollarPattern).Groups[1].Value.Trim(); //Dollar pattern


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

            Calc();

        }


        //Calculate the total 
        private void Calc()
        {
            TotalCost = 0;

            foreach (var item in toDoItemList)
            {
                TotalCost += item.TotalCost;
            }
        }






    }
}
