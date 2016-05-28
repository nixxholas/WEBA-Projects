using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExperimentLambda
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentList = new List<Student>();
            studentList.Add(new Student() { FullName = "MANDY", Assignment1Marks = 100, Assignment2Marks = 100, MidSemesterTestMarks = 100, StudentId = 1 });
            studentList.Add(new Student() { FullName = "KEN", Assignment1Marks = 80, Assignment2Marks = 80, MidSemesterTestMarks = 90, StudentId = 2 });
            studentList.Add(new Student() { FullName = "BOB", Assignment1Marks = 90, Assignment2Marks = 90, MidSemesterTestMarks = 90, StudentId = 3 });
            studentList.Add(new Student() { FullName = "FRED", Assignment1Marks = 70, Assignment2Marks = 70, MidSemesterTestMarks = 90, StudentId = 4 });
            studentList.Add(new Student() { FullName = "JOSEPH", Assignment1Marks = 50, Assignment2Marks = 60, MidSemesterTestMarks = 70, StudentId = 5 });
            studentList.Add(new Student() { FullName = "SANDY", Assignment1Marks = 50, Assignment2Marks = 60, MidSemesterTestMarks = 60, StudentId = 6 });
            studentList.Add(new Student() { FullName = "KELLY", Assignment1Marks = 50, Assignment2Marks = 60, MidSemesterTestMarks = 50, StudentId = 7 });

            Console.WriteLine("Listing all students and their Overall Marks...");
            Console.WriteLine
                ("------------------------------------------------------------------");
            foreach (var student in studentList)
            {
                Console.WriteLine("FullName:" + student.FullName + "\t Overall Mark:" + student.OverallMarks + "\n");
            }

            Console.ReadKey();

            Console.WriteLine("Listing all students whose Overall Mark is greater than or equal to 70");
            Console.WriteLine
                ("-------------------------------------------------------------------");
            foreach (var student in studentList)
            {
                if (student.OverallMarks >= 70)
                {
                    Console.WriteLine("FullName:" + student.FullName + "\t Overall Mark:" + student.OverallMarks + "\n");
                }
            }

            Console.ReadKey();

            Console.WriteLine("List all students whose Overall Mark is >= 70 ordered by name descending");
            Console.WriteLine
                ("-------------------------------------------------------------------");
            var studentListQueryResult = studentList.Where //Where filters the student instance based on the lambda expression
                (input => input.OverallMarks >= 70); //This line shows the lambda expression
            foreach (var student in studentListQueryResult)
            {
                Console.WriteLine("FullName:" + student.FullName + "\t Overall Mark:" + student.OverallMarks + "\n");
            }

            Console.ReadKey();

            Console.WriteLine("List all students group by Grade");
            Console.WriteLine
                ("-------------------------------------------------------------------");
            var studentGroupQueryResult = studentList.GroupBy
                (input => input.OverallGrade);
            foreach (var studentGroup in studentGroupQueryResult)
            {
                foreach (var student in studentGroup)
                {
                    Console.WriteLine("FullName:" + student.FullName + "\t Overall Grade:" + student.OverallGrade + "\n");
                }
            }

            Console.ReadKey();

        }
    }
}
