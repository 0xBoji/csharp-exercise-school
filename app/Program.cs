using System;
using ClassStudent.Controllers;
using ClassStudent.Helpers;
using ClassStudent.Models;

namespace ClassStudent
{
    class Program
    {
        static void Main()
        {
            StudentManager studentManager = new StudentManager();

            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add student");
                Console.WriteLine("2. Update student");
                Console.WriteLine("3. Delete student");
                Console.WriteLine("4. Show list of students");
                Console.WriteLine("5. List students above 20 years old with average score greater than 8");
                Console.WriteLine("6. List students with the highest average score");
                Console.WriteLine("7. Sort students by average score");
                Console.WriteLine("8. Check if student ID exists");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Student newStudent = InputStudentInformationFromUser();
                        studentManager.AddStudent(newStudent);
                        break;

                    case "2":
                        Console.Write("Enter student ID to update: ");
                        if (int.TryParse(Console.ReadLine(), out int updateStudentId))
                        {
                            Student updatedStudent = InputStudentInformationFromUser();
                            studentManager.UpdateStudent(updateStudentId, updatedStudent);
                        }
                        else
                        {
                            Console.WriteLine("Invalid student ID.");
                        }
                        break;

                    case "3":
                        Console.Write("Enter student ID to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int deleteStudentId))
                        {
                            studentManager.RemoveStudent(deleteStudentId);
                        }
                        else
                        {
                            Console.WriteLine("Invalid student ID.");
                        }
                        break;

                    case "4":
                        studentManager.DisplayStudents();
                        break;

                    case "5":
                        studentManager.StudentsAbove20WithHighAverage();
                        break;

                    case "6":
                        studentManager.StudentsWithHighestAverageScore();
                        break;

                    case "7":
                        studentManager.SortByAverageScore();
                        break;

                    case "8":
                        Console.Write("Enter student ID to check: ");
                        if (int.TryParse(Console.ReadLine(), out int checkStudentId))
                        {
                            Console.WriteLine($"Student ID {checkStudentId} exists: {studentManager.IsStudentIdExists(checkStudentId)}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid student ID.");
                        }
                        break;

                    case "0":
                        // Exit
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static Student InputStudentInformationFromUser()
        {
            Console.Write("Enter student ID: ");
            int studentId;
            while (!int.TryParse(Console.ReadLine(), out studentId) || !InputValidator.IsValidStudentId(studentId))
            {
                Console.WriteLine("Invalid student ID. Please enter again.");
                Console.Write("Enter student ID: ");
            }

            Console.Write("Enter full name: ");
            string fullName = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(fullName) || !InputValidator.IsValidFullName(fullName))
            {
                Console.WriteLine("Invalid full name. Please enter again.");
                Console.Write("Enter full name: ");
                fullName = Console.ReadLine();
            }

            Console.Write("Enter date of birth (yyyy-MM-dd): ");
            DateTime dateOfBirth;
            while (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth) || !InputValidator.IsValidDateOfBirth(dateOfBirth))
            {
                Console.WriteLine("Invalid date of birth. Please enter again.");
                Console.Write("Enter date of birth (yyyy-MM-dd): ");
            }

            Console.Write("Enter gender (Male/Female): ");
            string gender = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(gender) || !InputValidator.IsValidGender(gender))
            {
                Console.WriteLine("Invalid gender. Please enter again.");
                Console.Write("Enter gender (Male/Female): ");
                gender = Console.ReadLine();
            }

            Console.Write("Enter average score: ");
            double averageScore;
            while (!double.TryParse(Console.ReadLine(), out averageScore) || !InputValidator.IsValidAverageScore(averageScore))
            {
                Console.WriteLine("Invalid average score. Please enter again.");
                Console.Write("Enter average score: ");
            }

            Console.Write("Enter additional attribute: ");
            double additionalAttribute;
            while (!double.TryParse(Console.ReadLine(), out additionalAttribute))
            {
                Console.WriteLine("Invalid additional attribute. Please enter again.");
                Console.Write("Enter additional attribute: ");
            }

            return new Student(studentId, fullName, dateOfBirth, gender, averageScore, additionalAttribute);
        }
    }
}
