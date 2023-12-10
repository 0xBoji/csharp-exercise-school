using System;

namespace ClassStudent.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public double AverageScore { get; set; }
        public double AdditionalAttribute { get; set; }

        public Student(int studentId, string fullName, DateTime dateOfBirth, string gender, double averageScore, double additionalAttribute = 0)
        {
            StudentId = studentId;
            FullName = fullName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            AverageScore = averageScore;
            AdditionalAttribute = additionalAttribute;
        }
    }
}