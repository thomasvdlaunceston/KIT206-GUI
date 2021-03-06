using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_GroupWork.Researcher
{
	public class Position
	{
		public EmploymentLevel level { get; set; }
		public DateTime start { get; set; }
		public DateTime end { get; set; }

		private Dictionary<EmploymentLevel, string> convertTitle = new Dictionary<EmploymentLevel, string>();

		public Position()
		{
			convertTitle[EmploymentLevel.Student] = "Student";
			convertTitle[EmploymentLevel.A] = "Postdoc";
			convertTitle[EmploymentLevel.B] = "Lecturer";
			convertTitle[EmploymentLevel.C] = "Senior Lecturer";
			convertTitle[EmploymentLevel.D] = "Associate Professor";
			convertTitle[EmploymentLevel.E] = "Professor";
			convertTitle[EmploymentLevel.ALL] = "ALL";
		}

		public string title()
		{
			return convertTitle[level];
			/*switch (level)
			{
				case EmploymentLevel.Student:
					return "Student";
				case EmploymentLevel.A:
					return "Postdoc";
				case EmploymentLevel.B:
					return "Lecturer";
				case EmploymentLevel.C:
					return "Senior Lecturer";
			}*/
		}

		public string ToTitle(EmploymentLevel I)
		{
			return convertTitle[I];
		}

        public override string ToString()
        {
			string endingDate = end.ToShortDateString();
			if (end == DateTime.Today)
			{
				endingDate = "present";
			}
			return String.Format("Position: {0}  {1}-{2}", title(), start.ToShortDateString(), endingDate);
        }

    }

}