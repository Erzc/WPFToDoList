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
        //Fields
        string desc = "";

        //Properties
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Desc { get; private set; }
        public DateTime UserDT { get; private set; }
        public virtual decimal Cost { get; set; }

        //Parameterless constructor
        public ToDoItem()
            : this(-1, 0, "title", "desc", DateTime.MinValue)
        {}

        //Overloaded constructor with parameters
        public ToDoItem(int id, decimal cost, string title, string description, DateTime userDT)
        {
            Id = id;
            Title = title;
            Desc = description;
            UserDT = userDT;

            Calc();
        }

        //Methods

        //Protected abstract method, implemented in child classes to calculate price
        protected abstract void Calc();

        //ToString concatenates order info in formatted string
        public override string ToString()
        {
            return
                "Id: " + Id +
                " \nTitle: " + Title +
                " \nDescription: " + Desc +
                " \nDue Date: " + UserDT +
                " \nCost: " + Cost;
        }

    }
}
