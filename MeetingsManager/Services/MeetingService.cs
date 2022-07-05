using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingsManager.Services
{
   public class MeetingService
    {
        private ValidationService validationService = new ValidationService();
        private ParseService parseService = new ParseService();
        private FileManagerService fileManagerService = new FileManagerService();
        private List<Meeting> meetings;

        public MeetingService()
        {
            meetings = fileManagerService.ReadMeetings();
        }
        public async Task CreateMeetingAsync (string name, string responsiblePerson, string description, string category, string type, string startDate, string endDate)
        {
           
            bool validate = validationService.ValidateMeeting(name, responsiblePerson, description, category, type, startDate, endDate);

            if (validate)
            {
                DateTime _startDate = parseService.ParseDate(startDate);
                DateTime _endDate = parseService.ParseDate(endDate);

                int _category = parseService.ParseInt(category);
                int _type = parseService.ParseInt(type);

                var meeting = new Meeting
                {
                    Name = name,
                    ResponsiblePerson = responsiblePerson,
                    Description = description,
                    Category = (Category)_category,
                    Type = (Type)_type,
                    StartDate = _startDate,
                    EndDate = _endDate

                };

                meeting.Attendees.Add(new Attendee { Name = responsiblePerson, TimeAdded = DateTime.Now});
                meetings.Add(meeting);
                await fileManagerService.WriteMeetings(meetings);
                Console.WriteLine("Meeting successfully created ");
            }
            else
            {
                Console.WriteLine("Something went wrong. Please try again.");
                return;
            }
        }

        public async Task DeleteMeetingAsync (string meetingName, string deletorsName)
        {
            var meeting = meetings.Where(i => i.Name == meetingName && i.ResponsiblePerson == deletorsName).FirstOrDefault();

            if (meeting == null)
            {
                Console.WriteLine("Meeting was not found or you have no rights to delete it");
                return;
            }
            else
            {
                meetings.Remove(meeting);
                await fileManagerService.WriteMeetings(meetings);
                Console.WriteLine("Meeting successfully removed!");
            }
        }

        public async Task AddPersonToMeetingAsync (string meetingName, string personName)
        {
            var meeting = meetings.Where(i => i.Name == meetingName).FirstOrDefault();

            bool validate = validationService.ValidatePersonAdded(meetingName, personName, meeting, meetings);
            if (validate)
            {
                meeting.Attendees.Add(new Attendee { Name = personName, TimeAdded = DateTime.Now });
                await fileManagerService.WriteMeetings(meetings);
                Console.WriteLine("Person added.");
            }
            else
            {
                Console.WriteLine("Something went wrong. Please try again.");
                return;
            }
        }

        public async Task RemovePersonFromMeetingAsync (string meetingName, string personName)
        {
            var meeting = meetings.Where(i => i.Name == meetingName).FirstOrDefault();
            

            if (meeting == null)
            {
                Console.WriteLine("Meeting was not found.");
                return;
            }
            if (personName == meeting.ResponsiblePerson)
            {
                Console.WriteLine("Cannot remove responsible person.");
                return;
            }
            var PersonToRemove = meeting.Attendees.Where(i => i.Name == personName).FirstOrDefault();
            meeting.Attendees.Remove(PersonToRemove);
            await fileManagerService.WriteMeetings(meetings);
            Console.WriteLine("Person removed.");

        }
    }
}
