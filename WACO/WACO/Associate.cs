using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WACO
{
    public class Associate
    {
        public Associate(int ci, string name, string lastName, double lastLecture)
        {
            Ci = ci;
            Name = name;
            LastName = lastName;
            LastLecture = lastLecture;

        }
        public int Ci { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public double LastLecture { get; set; }
    }
}
