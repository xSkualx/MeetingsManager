using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetingsManager.Services
{

    public class FilteringService
    {
        private FileManagerService fileManagerService = new FileManagerService();
        private List<Meeting> meetings;
        private ParseService parseService = new ParseService();

        public FilteringService()
        {
            meetings = fileManagerService.ReadMeetings();
        }
        public FilteringService(List<Meeting> _meetings)
        {
            meetings = _meetings;
        }
        public List<Meeting> ShowAll()
        {
            return meetings;
        }
        public List<Meeting> FilterByDescription (string description)
        {
            return meetings.Where(m => m.Description.Contains(description)).ToList();
        }

        public List<Meeting> FilterByResponsiblePerson (string name)
        {
            return meetings.Where(m => m.ResponsiblePerson == name).ToList();
        }
        public List<Meeting> FilterByCategory (string category)
        {
            int _category = parseService.ParseInt(category);
            return meetings.Where(m => m.Category == (Category)_category).ToList();
        }
        public List<Meeting> FilterByType (string type)
        {
            int _type = parseService.ParseInt(type);
            return meetings.Where(m => m.Type == (Type)_type).ToList(); ;
        }
        public List<Meeting> FilterAfterByDate (string date)
        {
            DateTime _date = parseService.ParseDate(date);
            return meetings.Where(m => m.StartDate >= _date).ToList();
        }
        public List<Meeting> FilterByAttendees()
        {
            return meetings.Where(m => m.Attendees.Count >= 2).ToList();
        }

    }
}
