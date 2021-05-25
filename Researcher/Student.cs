using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_GroupWork.Researcher
{
    public class Student : Researcher
    {
        public string Degree { get; set; }
        public string supervisor { get; set; }

        public override string ToString()
        {
            return String.Format("{0} {1}", GivenName, FamilyName);
        }
        //string supervisior;
    }
}
