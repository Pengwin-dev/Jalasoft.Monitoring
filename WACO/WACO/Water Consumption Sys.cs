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
        public List<Associate> associates { get; set; }
        public List<Lecture> lectures { get; set; }
        public List<Payment> payments { get; set; }
        public WaterConsumptionSystem() { 
            associates = new List<Associate>();
            lectures = new List<Lecture>();
        }

        public void Register(Associate u)
        {
            
            if(checkCIAvaiable(u))
            {
                throw new Exception("There's a duplicate on the register");
                
            }
            else
            {
                associates.Add(u);
                RegisterNewLecture(new Lecture(u.Ci,u.LastLecture));
                
                Console.WriteLine("The Associate has been added");
            }
        }

        public void RegisterNewLecture(Lecture lastLecture)
        {
           
            if(lastLecture.AmountLectured >= associates.Find(e => e.Ci == lastLecture.UserCi).LastLecture) {
                lectures.Add(lastLecture);
                associates.Find(e => e.Ci == lastLecture.UserCi).LastLecture=lastLecture.AmountLectured; //changes lecture on asociate

            }
            else
            {
                throw new Exception("New Lecture cant be lower than previous one");
            }
        }

        private bool checkCIAvaiable(Associate u){
            bool ans = false;
            int ciToMatch = u.Ci;
            foreach(Associate associate in associates)
            {
                if(associate.Ci == ciToMatch) { 
                   ans = true;
                   break;
                }
            }
            return ans;
        }

        private void CalculateDebt(int ci,Lecture l)
        {

        }
    }
}
