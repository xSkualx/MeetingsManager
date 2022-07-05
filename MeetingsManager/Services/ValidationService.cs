using System;
using System.Collections.Generic;
using System.Text;

namespace MeetingsManager.Services
{
    public class ValidationService
    {
        private ParseService parseService = new ParseService();

        public bool ValidateMeeting (string name, string responsiblePerson, string description, string category, string type, string startDate, string endDate)
        {
            DateTime _startDate = parseService.ParseDate(startDate);
            DateTime _endDate = parseService.ParseDate(endDate);

            int _category = parseService.ParseInt(category);
            int _type = parseService.ParseInt(type);

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(responsiblePerson) || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(category) ||
            string.IsNullOrEmpty(type) || string.IsNullOrEmpty(startDate) || string.IsNullOrEmpty(endDate))
            {
                Console.WriteLine("One or more arguments was not typed in");
                return false;
            }

            if (_startDate == DateTime.MinValue)
            {
                Console.WriteLine("Invalid start date provided!");
                return false;
            }

            if (_endDate == DateTime.MinValue)
            {
                Console.WriteLine("Invalid end date provided!");
                return false;
            }
            if (_startDate >= _endDate)
            {
                Console.WriteLine("Invalid start date provided (cannot be after end date)!");
                return false;
            }
            if (_startDate <= DateTime.Now)
            {
                Console.WriteLine("Cannot create a meeting for dates past now");
                return false;
            }

            if (_category == -1)
            {
                Console.WriteLine("Invalid category chosen");
                return false;
            }
            if (_type == -1)
            {
                Console.WriteLine("Invalid type chosen");
                return false;
            }

            return true;

        }
        public bool ValidatePersonAdded(string meetingName, string personName, Meeting meeting, List<Meeting> meetings)
        {
            if (meeting == null)
            {
                Console.WriteLine("Meeting was not found.");
                return false;
            }

            foreach (var person in meeting.Attendees)
            {
                if (person.Name == personName)
                {
                    Console.WriteLine("Person is already added");
                    return false;
                }
            }
            Meeting meetingu = new Meeting();
            foreach (var meet in meetings)
            {
                foreach (var person in meet.Attendees)
                {
                    if (person.Name == personName)
                    {
                        meetingu = meet;

                    }


                }
            }
            foreach (var meet in meetings)
            {
                if (meetingu.Name == meet.Name && meetingu.StartDate < meet.EndDate && meet.StartDate < meetingu.EndDate)
                {
                    Console.WriteLine("Person has an overlapping meeting");
                    return false;
                }
            }
           
            return true;
        }
    }
}
