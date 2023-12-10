using System;
using System.Collections.Generic;
using System.Linq;
using ClassStudent.Models;
using ClassStudent.Helpers;

namespace ClassStudent.Controllers
{
    public class StudentManager
    {
        private List<Student> studentsList = new List<Student>();

        public void AddStudent(Student student)
        {
            studentsList.Add(student);
        }

        public void UpdateStudent(int studentId, Student student)
        {
            int index = studentsList.FindIndex(s => s.StudentId == studentId);
            if (index != -1)
            {
                studentsList[index] = student;
            }
            else
            {
                Console.WriteLine($"Not found {studentId}");
            }
        }

        public void RemoveStudent(int studentId)
        {
            int index = studentsList.FindIndex(s => s.StudentId == studentId);
            if (index != -1)
            {
                studentsList.RemoveAt(index);
            }
            else
            {
                Console.WriteLine($"Not found {studentId}");
            }
        }

        public void DisplayStudents()
        {
            var querySyntax = from student in studentsList
                              select student;

            Console.WriteLine("List Student:");
            foreach (var student in querySyntax)
            {
                Console.WriteLine($"ID: {student.StudentId}, Name: {student.FullName}, Date: {student.DateOfBirth}, Gender: {student.Gender}, AverageScore: {student.AverageScore}, AdditionalAttribute: {student.AdditionalAttribute}");
            }
        }

        public void StudentsAbove20WithHighAverage()
        {
            var result = from student in studentsList
                         where (DateTime.Now.Year - student.DateOfBirth.Year) > 20 && student.AverageScore > 8
                         select student;

            Console.WriteLine("Sinh viên có tuổi lớn hơn 20 và điểm trung bình lớn hơn 8:");
            foreach (var student in result)
            {
                Console.WriteLine($"Mã SV: {student.StudentId}, Họ tên: {student.FullName}, Ngày sinh: {student.DateOfBirth}, Giới tính: {student.Gender}, Điểm TB: {student.AverageScore}, Thuộc tính: {student.AdditionalAttribute}");
            }
        }

        public void StudentsWithHighestAverageScore()
        {
            double maxScore = studentsList.Max(student => student.AverageScore);

            var result = from student in studentsList
                         where student.AverageScore == maxScore
                         select student;

            Console.WriteLine("Student got the highest average score");
            foreach (var student in result)
            {
                Console.WriteLine($"Mã SV: {student.StudentId}, Họ tên: {student.FullName}, Ngày sinh: {student.DateOfBirth}, Giới tính: {student.Gender}, Điểm TB: {student.AverageScore}, Thuộc tính: {student.AdditionalAttribute}");
            }
        }

        public void SortByAverageScore()
        {
            studentsList = studentsList.OrderByDescending(student => student.AverageScore).ToList();

            Console.WriteLine("Danh sách sinh viên sau khi sắp xếp theo điểm trung bình:");
            foreach (var student in studentsList)
            {
                Console.WriteLine($"Mã SV: {student.StudentId}, Họ tên: {student.FullName}, Ngày sinh: {student.DateOfBirth}, Giới tính: {student.Gender}, Điểm TB: {student.AverageScore}, Thuộc tính: {student.AdditionalAttribute}");
            }
        }

        public bool IsStudentIdExists(int studentId)
        {
            return studentsList.Any(student => student.StudentId == studentId);
        }
    }
}
