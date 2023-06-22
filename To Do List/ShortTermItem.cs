using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Do_List
{
    class ShortTermItem : ToDoItem //Derived class inherits from ToDoItem
    {
        public ShortTermItem()
            : base()
        {}

        public ShortTermItem(int id, string title, string description, DateTime currentDT)
            : base(id, title, description, currentDT)
        {}

        //Methods:

        protected override void Calc()
        {
            Cost = Id; //test
        }

        public override decimal Cost { get; set; }

        //string overload ToString()
        public override string ToString()
        {
            return base.ToString() + ". Time: Short term";
        }

    }
}
