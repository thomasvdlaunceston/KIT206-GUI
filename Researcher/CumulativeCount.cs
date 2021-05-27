using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_GroupWork.Researcher
{
    class CumulativeCount
    {
        public int year;
        public int numPublications;

        public CumulativeCount(int CurrentYear, int CurrentPublications)
        {
            year = CurrentYear;
            numPublications = CurrentPublications;
        }

    }
}
