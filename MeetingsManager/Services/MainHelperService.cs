using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingsManager.Services
{
    public class MainHelperService
    {
        private FilteringService filteringService  = new FilteringService();
        private MeetingService meetingService = new MeetingService();
        public void PrintChoices()
        {
            Console.WriteLine("Welcome to Meetings Management system");
            Console.WriteLine("1) Press 1 to show all meetings\n" +
                              "2) Press 2 to create a new meeting\n" +
                              "3) Press 3 to delete a meeting\n" +
                              "4) Press 4 to add a person to a meeting\n" +
                              "5) Press 5 to remove a person from a meeting\n" +
                              "6) Press 6 to filter by description\n" +
                              "7) Press 7 to filter by responsible person\n" +
                              "8) Press 8 to filter by category\n" +
                              "9) Press 9 to filter by type\n" +
                              "10) Press 10 to filter by date (meetings happen after the given date)\n" +
                              "11) Press 11 to show meetings that have more than 3 people\n" +
                              "12) Press 12 to exit the program\n");
        }

        public void PrintMeetings()
        {
           var meetings =  filteringService.ShowAll();

            if (meetings.Count == 0)
            {
                Console.WriteLine("No meetings were found");
            }
            else
            {
                foreach (var meeting in meetings)
                {
                    Console.WriteLine(meeting.ToString());
                }
            }
        }
        public async Task CreateMeeting()
        {
            Console.WriteLine("Enter meeting's name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter responsible person's name");
            string responsiblePerson = Console.ReadLine();
            Console.WriteLine("Enter meeting's description");
            string description = Console.ReadLine();
            Console.WriteLine("Enter meeting's category \n" +
                "0 - CodeMonkey\n" +
                "1 - Hub\n" +
                "2 - Short\n" +
                "3 - TeamBuilding\n");
            string category = Console.ReadLine();
            Console.WriteLine("Enter meeting's type\n" +
                "0 - Live" +
                "1 - InPerson\n");
            string type = Console.ReadLine();
            Console.WriteLine("End meeting's start date (use MM/dd/yyyy h:mm format)");
            string startDate = Console.ReadLine();
            Console.WriteLine("End meeting's end date (use MM/dd/yyyy h:mm format)");
            string endDate = Console.ReadLine();

           await meetingService.CreateMeetingAsync(name, responsiblePerson, description, category, type, startDate, endDate);

        }
        public async Task DeleteMeeting()
        {
            Console.WriteLine("Enter meeting's name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter responsible person's name");
            string responsiblePerson = Console.ReadLine();

          await  meetingService.DeleteMeetingAsync(name, responsiblePerson);
        }
        public void FilterByDescription()
        {
            Console.WriteLine("Enter meeting's description or a part of it");
            string description = Console.ReadLine();

            var meetings = filteringService.FilterByDescription(description);
            if (meetings.Count == 0)
            {
                Console.WriteLine("No meetings with such description were found");
            }
            else
            {
                foreach(var meeting in meetings)
                {
                    Console.WriteLine(meeting.ToString());
                }
            }
        }
        public void FilterByResponsiblePerson()
        {
            Console.WriteLine("Enter the person's responsible for the meeting name");
            string name = Console.ReadLine();

            var meetings = filteringService.FilterByResponsiblePerson(name);
            if (meetings.Count == 0)
            {
                Console.WriteLine("No meetings with such a person were found");
            }
            else
            {
                foreach (var meeting in meetings)
                {
                    Console.WriteLine(meeting.ToString());
                }
            }
        }
        public void FilterByCategory()
        {
            Console.WriteLine("Enter meeting's category you want to filter by \n" +
                "0 - CodeMonkey\n" +
                "1 - Hub\n" +
                "2 - Short\n" +
                "3 - TeamBuilding\n");
            string category = Console.ReadLine();
            var meetings = filteringService.FilterByCategory(category);
            if (meetings.Count == 0)
            {
                Console.WriteLine("No meetings of this category were found");
            }
            else
            {
                foreach (var meeting in meetings)
                {
                    Console.WriteLine(meeting.ToString());
                }
            }
        }
        public void FilterByType()
        {
            Console.WriteLine("Enter meeting's type you want to filter by\n" +
               "0 - Live" +
               "1 - InPerson\n");
            string type = Console.ReadLine();
            var meetings = filteringService.FilterByType(type);
            if (meetings.Count == 0)
            {
                Console.WriteLine("No meetings of this type were found");
            }
            else
            {
                foreach (var meeting in meetings)
                {
                    Console.WriteLine(meeting.ToString());
                }
            }
        }
        public void FilterByDate()
        {
            Console.WriteLine("End meeting's start date you want to filter meetings after (use MM/dd/yyyy h:mm format)");
            string date = Console.ReadLine();
            var meetings = filteringService.FilterAfterByDate(date);
            if (meetings.Count == 0)
            {
                Console.WriteLine("No meetings after this date were found");
            }
            else
            {
                foreach (var meeting in meetings)
                {
                    Console.WriteLine(meeting.ToString());
                }
            }
        }
        public void FilterByPeopleCount()
        {
            var meetings = filteringService.FilterByAttendees();
            if (meetings.Count == 0)
            {
                Console.WriteLine("No meetings with more than 3 people were found");
            }
            else
            {
                foreach (var meeting in meetings)
                {
                    Console.WriteLine(meeting.ToString());
                }
            }
        }
        public async Task AddPersonToMeeting()
        {
            Console.WriteLine("Enter the meeting's you want to add the person in name");
            string meetingName = Console.ReadLine();
            Console.WriteLine("Enter the person's name");
            string personName = Console.ReadLine();

           await meetingService.AddPersonToMeetingAsync(meetingName, personName);
        }
        public async Task RemovePersonFromMeeting()
        {
            Console.WriteLine("Enter the meeting's you want to remove the person in name");
            string meetingName = Console.ReadLine();
            Console.WriteLine("Enter the person's name");
            string personName = Console.ReadLine();

           await meetingService.RemovePersonFromMeetingAsync(meetingName, personName);
        }
    }
}
