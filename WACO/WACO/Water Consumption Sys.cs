using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WACO
{
    public class WaterConsumptionSystem
    {
        public List<User> users { get; set; }
        public WaterConsumptionSystem() { 
            users = new List<User>();
        }

        public void Register(User u)
        {
            if(users.Contains(u))
            {
                throw new Exception("There's a duplicate on the register");
            }
            else
            {
                users.Add(u);
            }
        }
    }
}
