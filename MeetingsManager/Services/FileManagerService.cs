using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MeetingsManager.Services
{
    
    public class FileManagerService
    {
        private string meetingsFile = "meetings.json";

       

        public List<Meeting> ReadMeetings()
        {
            string jsonString =  File.ReadAllText(meetingsFile);
            List<Meeting> meetings = JsonSerializer.Deserialize<List<Meeting>>(jsonString);
            //Thread.Sleep(1000);
            return meetings;
        }
        
        public async Task WriteMeetings (List<Meeting> meetings)
        {
            string jsonString = JsonSerializer.Serialize(meetings);
            await File.WriteAllTextAsync(meetingsFile, jsonString);
        }
        public void ManageFile()
        {
            string list = "[]";
            if (File.Exists(meetingsFile))
            {
                if (new FileInfo(meetingsFile).Length == 0)
                {
                    File.WriteAllText(meetingsFile, list);
                }
            }
            else
            {
                Console.WriteLine("File was not found");
            }
        }
        public void CreateFile()
        {
            try
            {
  
                if (!File.Exists(meetingsFile))
                {  
                    using (FileStream fs = File.Create(meetingsFile))
                    { 
                        byte[] list = new UTF8Encoding(true).GetBytes("[]");
                        fs.Write(list);
                        Console.WriteLine("file created");
                    }
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine(Ex.ToString());
            }
        }
    }
}
