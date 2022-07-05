using System;
using System.Collections.Generic;
using System.Text;

namespace MeetingsManager
{
    public class Meeting
    {
        public string Name { get; set; }
        public string ResponsiblePerson { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public Type Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<Attendee> Attendees { get; set; }

        public Meeting()
        {
            Attendees = new List<Attendee>();
        }

        public override string ToString()
        {
            return "Name: " + Name + "\nResponsible person: " + ResponsiblePerson + "\nDescription: " + Description + "\n Category: " + Category +
                    "\nType: " + Type + "\nStart date: " + StartDate + "\nEndDate: " + EndDate;
        }
    }
}
