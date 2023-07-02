using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Do_List
{
    public abstract class ToDoItem //Base class
    {
        //Properties
        public string Title { get; private set; }
        public string Desc { get; private set; }
        public DateTime UserDT { get; private set; }
        public int TotalNumCharges { get; set; }
        public string ChargeFreqS { get; set; }
        public decimal Cost { get; set; }
        public virtual decimal TotalCost { get; set; }

        //Parameterless constructor
        public ToDoItem()
            : this(0, 0, "none", "title", "desc", DateTime.MinValue)
        {}

        //Overloaded constructor with parameters
        public ToDoItem(decimal cost, int totalNumCharges, string chargeFreqS, string title, string description, DateTime userDT)
        {
            Title = title;
            Cost = cost;
            TotalNumCharges = totalNumCharges;
            Desc = description;
            UserDT = userDT;
            ChargeFreqS = chargeFreqS;

            Calc();
        }

        //Methods

        //Protected abstract method, implemented in child classes to calculate total costs
        protected abstract void Calc();

        //Concatenates item info in formatted string and
        //Round decimal to 2 decimal places
        public override string ToString()
        {
            return
                "Title: " + Title +
                "\nDescription: " + Desc +
                "\nDeadline: " + UserDT +
                "\nCost Frequency: " + ChargeFreqS +
                "\nTotal Charges: " + TotalNumCharges +
                "\nOne Time Cost: $" + Math.Round(Cost, 2).ToString("0.00") +
                "\nTotal Cost: $" + Math.Round(TotalCost, 2).ToString("0.00");
        }

    }
}
