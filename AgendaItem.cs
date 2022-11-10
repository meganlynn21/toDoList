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

        public AgendaItem(string desc)
        {
            Description = desc;
            Date = DateTime.Now;
            Status = "Not Done";
        }

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
