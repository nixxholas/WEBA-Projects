using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExperimentLambda
{
    class Student
    {
        public double StudentId { get; set; }
        public string FullName { get; set; }
        public double Assignment1Marks { get; set; }
        public double Assignment2Marks { get; set; }
        public double MidSemesterTestMarks { get; set; }
        public double OverallMarks
        {
            get
            {
                double overall = (this.Assignment1Marks * (0.35)) + (this.Assignment2Marks * (0.40)) + (this.MidSemesterTestMarks * (0.25));
                return overall;
            }
        }

        public String OverallGrade
        {
            get {
                double overallMarks = this.OverallMarks;
                string OverallGrade = "";
                if (OverallMarks >= 80)
                {
                    OverallGrade = "A";
                } else if (overallMarks >= 70)
                {
                    OverallGrade = "B";
                } else if (overallMarks >= 60)
                {
                    OverallGrade = "C";
                } else if (overallMarks >= 50)
                {
                    OverallGrade = "D";
                } else
                {
                    OverallGrade = "F";
                }
                return OverallGrade;
            }
        }
    }
}
