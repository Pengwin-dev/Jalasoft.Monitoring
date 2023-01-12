using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WACO
{
    public class WaterConsumptionSystem
    {
        public List<Associate> users { get; set; }
        public WaterConsumptionSystem() { 
            users = new List<Associate>();
        }

        public void Register(Associate u)
        {
            
            if(users.Contains(u))
            {
                throw new Exception("There's a duplicate on the register");
            }
            else
            {
                users.Add(u);
                Console.WriteLine("The Associate has been added");
            }
        }

        public void RegisterNewLecture(int ci, Lecture lastLecture)
        {
            int aux = (int)Math.Truncate(lastLecture.AmountLectured);
            if(lastLecture.AmountLectured >= users.Find(e => e.Ci == ci).LastLecture.AmountLectured) { 
                users.Find(e => e.Ci == ci).LastLecture.AmountLectured=aux;
            }
            else
            {
                throw new Exception("New Lecture cant be lower than previous one");
            }
        }
    }
}
