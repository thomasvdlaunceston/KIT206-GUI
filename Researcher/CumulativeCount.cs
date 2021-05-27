using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_GroupWork.Researcher
{
    public class CumulativeCount
    {
        public int year { get; set; }
        public int numPublications { get; set; }

        public CumulativeCount(int CurrentYear, int CurrentPublications)
        {
            year = CurrentYear;
            numPublications = CurrentPublications;
        }

    }
}
