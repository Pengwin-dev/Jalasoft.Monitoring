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
            "   1) Register an user.\n" +
            "   2) Register a lecture\n" +
            "   3) nothing else\n" +
            "   Waco> ");
                int opOrder = int.Parse(Console.ReadLine());



                if (opOrder == 1) RegisterUser();
                else if (opOrder == 2) RegisterLecture();
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
            Lecture l = new Lecture(firstLecture);
            
            Associate u = new Associate(ci, name, lastName, l);
            wcs.Register(u);
        }

        private void RegisterLecture()
        {
            Console.Write("Associate CI> ");
            int ci = int.Parse(Console.ReadLine());
            Console.Write("Lecture Value> ");
            double lectureValue = double.Parse(Console.ReadLine());
            Console.Write("Corresponding Month> ");
            string month = Console.ReadLine();
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

            Lecture l = new Lecture(lectureValue,month,date);
            wcs.RegisterNewLecture(ci, l);

        }
    }
}
