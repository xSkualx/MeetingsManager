using MeetingsManager.Services;
using System;
using System.Threading.Tasks;

namespace MeetingsManager
{
    class Program
    {
        
        static async Task Main(string[] args)
        {
            FileManagerService fileManagerService = new FileManagerService();
            fileManagerService.ManageFile();// if a file is created but empty
            fileManagerService.CreateFile();
            MainHelperService mainHelperService = new MainHelperService();
            
            
            bool logLoop = true;

            while (logLoop)
            {
                try
                {
                    mainHelperService.PrintChoices();
                    
                    int logCase = int.Parse(Console.ReadLine());

                    switch (logCase)
                    {
                        case 1:
                            mainHelperService.PrintMeetings();
                            break;
                        case 2:
                           await mainHelperService.CreateMeeting();
                            break;
                        case 3:
                           await mainHelperService.DeleteMeeting();
                            break;
                        case 4:
                           await  mainHelperService.AddPersonToMeeting();
                            break;
                        case 5:
                           await mainHelperService.RemovePersonFromMeeting();
                            break;
                        case 6:
                            mainHelperService.FilterByDescription();
                            break;
                        case 7:
                            mainHelperService.FilterByResponsiblePerson();
                            break;
                        case 8:
                            mainHelperService.FilterByCategory();
                            break;
                        case 9:
                            mainHelperService.FilterByType();
                            break;
                        case 10:
                            mainHelperService.FilterByDate();
                            break;
                        case 11:
                            mainHelperService.FilterByPeopleCount();
                            break;
                        case 12:
                            logLoop = false;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Enter a valid input...");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }

                }
                catch (FormatException)
                {
                    logLoop = true;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Try again...");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }
}
