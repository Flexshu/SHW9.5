using System;
#pragma warning disable

namespace DelegatesDemo
{
    class Student
    {
        public string Name;
        public double Grade;
    }

    class Program5
    {
        static Student[] FilterStudents(Student[] students, Predicate<Student> condition)
        {
            Student[] temp = new Student[students.Length];
            int index = 0;

            for (int i = 0; i < students.Length; i++)
            {
                if (condition(students[i]))
                {
                    temp[index] = students[i];
                    index++;
                }
            }

            Student[] result = new Student[index];
            for (int i = 0; i < index; i++)
            {
                result[i] = temp[i];
            }
            return result;
        }

        static void Print(string title, Student[] students)
        {
            Console.WriteLine(title + ":");
            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine(students[i].Name + " " + students[i].Grade);
            }
            Console.WriteLine();
        }

        static void Main()
        {
            Student[] students =
            {
                new Student { Name = "Alice", Grade = 80 },
                new Student { Name = "Bob", Grade = 60 },
                new Student { Name = "Anna", Grade = 90 },
                new Student { Name = "Mark", Grade = 72 }
            };

            Student[] highGrades = FilterStudents(students, s => s.Grade > 75);
            Student[] startsWithA = FilterStudents(students, s => s.Name.StartsWith("A"));

            Print("Grade > 75", highGrades);
            Print("Name starts with A", startsWithA);
        }
    }
}