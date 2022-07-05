using MeetingsManager;
using MeetingsManager.Services;

namespace MeetingsManagerTests
{
    [TestClass]
    public class UnitTest1
    {
    
        [TestMethod]
        public void TestShowAll()
        {
            List<Meeting> meetings = new List<Meeting>();
            Meeting meeting1 = new Meeting
            {
                Name = "serious meeting",
                ResponsiblePerson = "responsible person",
                Description = "descriptive description",
                Category = (Category)1,
                Type = (MeetingsManager.Type)1,
                StartDate = DateTime.Parse("07/29/2022 05:50 AM"),
                EndDate = DateTime.Parse("07/29/2022 06:50 AM")

            };
            Meeting meeting2 = new Meeting
            {
                Name = " not serious meeting",
                ResponsiblePerson = "responsible person1",
                Description = "descriptive description1",
                Category = (Category)2,
                Type = (MeetingsManager.Type)1,
                StartDate = DateTime.Parse("08/29/2022 05:50 AM"),
                EndDate = DateTime.Parse("08/29/2022 06:50 AM")
            };
            Meeting meeting3 = new Meeting
            {
                Name = " a very serious meeting",
                ResponsiblePerson = "responsible person5",
                Description = "descriptive description",
                Category = (Category)3,
                Type = (MeetingsManager.Type)1,
                StartDate = DateTime.Parse("07/10/2022 05:50 AM"),
                EndDate = DateTime.Parse("07/10/2022 06:50 AM")
            };
            meetings.Add(meeting1);
            meetings.Add(meeting2);
            meetings.Add(meeting3);




            FilteringService filteringService = new FilteringService(meetings);
            List<Meeting> expectedList = new List<Meeting>();
            List<Meeting> testList = new List<Meeting>();

            testList = filteringService.ShowAll();
            expectedList = meetings;
           
            CollectionAssert.AreEqual(expectedList, testList);


        }
        [TestMethod]
        public void TestFilterByDescription()
        {
             List<Meeting> meetings = new List<Meeting>();
            Meeting meeting1 = new Meeting
            {
                Name = "serious meeting",
                ResponsiblePerson = "responsible person",
                Description = "description",
                Category = (Category)1,
                Type = (MeetingsManager.Type)1,
                StartDate = DateTime.Parse("07/29/2022 05:50 AM"),
                EndDate = DateTime.Parse("07/29/2022 06:50 AM")

            };
            Meeting meeting2 = new Meeting
            {
                Name = " not serious meeting",
                ResponsiblePerson = "responsible person1",
                Description = "most descriptive description1",
                Category = (Category)2,
                Type = (MeetingsManager.Type)1,
                StartDate = DateTime.Parse("08/29/2022 05:50 AM"),
                EndDate = DateTime.Parse("08/29/2022 06:50 AM")
            };
            Meeting meeting3 = new Meeting
            {
                Name = " a very serious meeting",
                ResponsiblePerson = "responsible person5",
                Description = " description",
                Category = (Category)3,
                Type = (MeetingsManager.Type)1,
                StartDate = DateTime.Parse("07/10/2022 05:50 AM"),
                EndDate = DateTime.Parse("07/10/2022 06:50 AM")
            };
            meetings.Add(meeting1);
            meetings.Add(meeting2);
            meetings.Add(meeting3);




            FilteringService filteringService = new FilteringService(meetings);
            List<Meeting> expectedList = new List<Meeting>();
            List<Meeting> testList = new List<Meeting>();

            testList = filteringService.FilterByDescription("most");
            expectedList.Add(meeting2);
           
            CollectionAssert.AreEqual(expectedList, testList);
        }

        [TestMethod]
        public void TestFilterByResponsiblePerson()
        {
            List<Meeting> meetings = new List<Meeting>();
            Meeting meeting1 = new Meeting
            {
                Name = "serious meeting",
                ResponsiblePerson = "rokas",
                Description = "description",
                Category = (Category)1,
                Type = (MeetingsManager.Type)1,
                StartDate = DateTime.Parse("07/29/2022 05:50 AM"),
                EndDate = DateTime.Parse("07/29/2022 06:50 AM")

            };
            Meeting meeting2 = new Meeting
            {
                Name = " not serious meeting",
                ResponsiblePerson = "responsible person1",
                Description = "most descriptive description1",
                Category = (Category)2,
                Type = (MeetingsManager.Type)1,
                StartDate = DateTime.Parse("08/29/2022 05:50 AM"),
                EndDate = DateTime.Parse("08/29/2022 06:50 AM")
            };
            Meeting meeting3 = new Meeting
            {
                Name = " a very serious meeting",
                ResponsiblePerson = "responsible person5",
                Description = " description",
                Category = (Category)3,
                Type = (MeetingsManager.Type)1,
                StartDate = DateTime.Parse("07/10/2022 05:50 AM"),
                EndDate = DateTime.Parse("07/10/2022 06:50 AM")
            };
            meetings.Add(meeting1);
            meetings.Add(meeting2);
            meetings.Add(meeting3);




            FilteringService filteringService = new FilteringService(meetings);
            List<Meeting> expectedList = new List<Meeting>();
            List<Meeting> testList = new List<Meeting>();

            testList = filteringService.FilterByResponsiblePerson("rokas");
            expectedList.Add(meeting1);

            CollectionAssert.AreEqual(expectedList, testList);
        }



    }
}