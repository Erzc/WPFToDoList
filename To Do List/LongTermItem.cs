using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Do_List
{
    class LongTermItem : ToDoItem //Derived class inherits from ToDoItem
    {
        public LongTermItem()
            : base()
        {
        }

        public LongTermItem(int id, string title, string description, DateTime currentDT)
            : base(id, title, description, currentDT)
        { }

        //Methods:

        protected override void Calc()
        {
            Cost = Id; //test
        }

        public override decimal Cost { get; set; }

        //string overload ToString()
        public override string ToString()
        {
            return base.ToString() + ". Time: Long term";
        }





    }
}
