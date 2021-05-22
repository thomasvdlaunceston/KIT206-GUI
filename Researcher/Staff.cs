using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIT206_GroupWork.Researcher
{
	class Staff : Researcher
	{
		private Dictionary<EmploymentLevel, double> expectedPub = new Dictionary<EmploymentLevel, double>();
		public List<Student> student;
		public int numSupervisions { get { return student.Count; } }
		public float ThreeYearAverage {get; set;}
		public float performance { get; set; }

		public Staff()
		{
			student = new List<Student>();
			//I understand that students do not have an expected number of publications but for preventing errors setting to 0
			expectedPub[EmploymentLevel.Student] = 0;
			expectedPub[EmploymentLevel.A] = 0.5;
			expectedPub[EmploymentLevel.B] = 1;
			expectedPub[EmploymentLevel.C] = 2;
			expectedPub[EmploymentLevel.D] = 3.2;
			expectedPub[EmploymentLevel.E] = 4;
		}

		public void calculateThreeYearAverage(Control.PublicationsController pcontrol)
		{
			int numberOfPublications = 0;
			int CurrentYear = DateTime.Now.Year;


			int totalPublications = pcontrol.publicationCount;

			while ((CurrentYear - pcontrol.mainList[totalPublications-1].Year) <= 3)
			{
				numberOfPublications++;
				totalPublications--;
			}
			ThreeYearAverage = numberOfPublications / 3;
		}

		public void Performance(Control.PublicationsController pcontrol)
		{
			double CurrentExpectedNumber = expectedPub[GetCurrentJob().level];
			calculateThreeYearAverage(pcontrol);
			performance =  (float)(ThreeYearAverage / CurrentExpectedNumber);
		}



	}
}
