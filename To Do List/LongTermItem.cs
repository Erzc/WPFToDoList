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
        {}

        public LongTermItem(decimal cost, int totalNumCharges, string chargeFreqS, string title, string description, DateTime userDT)
            : base(cost, totalNumCharges, chargeFreqS, title, description, userDT)
        {}

        //Methods:

        protected override void Calc()
        {
            TotalCost = Cost * TotalNumCharges;
        }

        public override decimal Cost { get; set; }

        //string overload ToString()
        public override string ToString()
        {
            return base.ToString() + "\nTime: Long term";
        }





    }
}
