using System;
using System.Collections.Generic;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace toDoList
{
    internal class AgendaItem
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }


        public AgendaItem()
        {
            Description = "";
            Date = DateTime.Now;
            Status = "Not Done";
        }
        /*
         * Create another constructor that takes the description as an argument and 
         * initializes the description to it and then puts the default values  in the 
         * other two variables like you did in the default constructor.
         **/
        public AgendaItem(string desc)
        {
            Description = desc;
            Date = DateTime.Now;
            Status = "Not Done";
        }
        /*
           Create a third constructor that takes all 3 arguments and puts them into
           the 3 variables description, date, and status.  Make sure you match the types 
           of these arguments with how the properties were declared.
        */
        public AgendaItem(string desc, DateTime date, string status)
        {
            Description = desc;
            Date = date;
            Status = status;
        }

        public override string ToString()
        {
            return $"{Description} , {Date} , {Status}";
        }
    }
}
