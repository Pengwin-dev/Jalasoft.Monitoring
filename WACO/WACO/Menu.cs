using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WACO
{
    public class Menu
    {
        public WaterConsumptionSystem wcs { get; set; }
        public Menu(WaterConsumptionSystem w)
        {
            wcs = w;
        }

        public void Execute() { 
            Console.WriteLine("Welcome to WACO 3.8 System ");
            
            while (true)
            {
                Console.Write(
            "\nchoose item to add:\n" +
            "   1) Register an Associate.\n" +
            "   2) Register a Lecture\n" +
            "   3) Process Payment\n" +
            "   4) Payment by Month\n"+
            "   Waco> ");
                int opOrder = int.Parse(Console.ReadLine());



                if (opOrder == 1)
                {
                    try
                    {
                        RegisterUser();
                    }
                    catch (Exception ex)
                    {
                        string message = string.Empty;
                        message = ex.Message;
                        Console.WriteLine(message);
                    }
                }
                else if (opOrder == 2) {
                    try { 
                        RegisterLecture();
                    }
                    catch(Exception ex)
                    {
                        string message = string.Empty;
                        message = ex.Message;
                        Console.WriteLine(message);
                    }
                }

                else if (opOrder == 3) break;
            }
        }



        private void RegisterUser()
        {
            Console.Write("Associate CI> ");
            int ci = int.Parse(Console.ReadLine());
            Console.Write("Associate name> ");
            string name = Console.ReadLine();
            Console.Write("Associate last name> ");
            string lastName = Console.ReadLine();
            Console.Write("Associate Base lecture> ");
            double firstLecture = double.Parse(Console.ReadLine());
            Associate u = new Associate(ci, name, lastName, firstLecture);
            wcs.Register(u);
        }

        private void RegisterLecture()
        {
            Console.Write("Associate CI> ");
            int ci = int.Parse(Console.ReadLine());
            Console.Write("Lecture Value> ");
            double lectureValue = double.Parse(Console.ReadLine());
            //Console.Write("Corresponding Month> ");
            //string month = Console.ReadLine();
            //Console.Write("Date Time> Year");
            //int Year = int.Parse(Console.ReadLine());
            //Console.Write("Date Time> Month");
            //int Month = int.Parse(Console.ReadLine());
            //Console.Write("Date Time> Day");
            //int Day = int.Parse(Console.ReadLine());
            //Console.Write("Date Time> Hour");
            //int Hour = int.Parse(Console.ReadLine());
            //Console.Write("Date Time> Min");
            //int Min = int.Parse(Console.ReadLine());
            //Console.Write("Date Time> Sec");
            //int Sec = int.Parse(Console.ReadLine());
            DateTime date = DateTime.UtcNow;
            wcs.RegisterNewLecture(new Lecture(ci,lectureValue));
            //Lecture l = new Lecture(lectureValue, month, date);
        }
    }
}
