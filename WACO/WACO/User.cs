using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WACO
{
    public class User
    {
        public User(string name, string lastName, int litersConsumed)
        {
            Name = name;
            LastName = lastName;
            LitersConsumed = litersConsumed;
        }

        public string Name { get; set; }
        public string LastName { get; set; }
        public int LitersConsumed { get; set; }
    }
}
