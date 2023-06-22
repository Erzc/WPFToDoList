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
        public DateTime CurrentDT { get; private set; }
        public virtual decimal Cost { get; set; }

        //Parameterless constructor
        public ToDoItem()
            : this(-1, "title", "desc", DateTime.MinValue)
        {}

        //Overloaded constructor with parameters
        public ToDoItem(int id, string title, string description, DateTime currentDT)
        {
            Id = id;
            Title = title;
            Desc = description;
            CurrentDT = currentDT;

            Calc();
        }

        //Methods

        //Protected abstract method, implemented in child classes to calculate price
        protected abstract void Calc();

        //ToString concatenates order info in formatted string
        public override string ToString()
        {
            return
                "Todo item number: " + Id
                + " Cost: " + Cost;
        }

    }
}
