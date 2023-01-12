using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WACO
{
    public class User
    {
        public User(int ci, string name, string lastName, int litersConsumed)
        {
            Ci = ci;
            Name = name;
            LastName = lastName;
            LitersConsumed = litersConsumed;
        }
        public int Ci { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int LitersConsumed { get; set; }
    }
}
