namespace ClassStudent.Helpers
{
    public static class InputValidator
    {
        public static bool IsValidStudentId(int studentId)
        {
            return studentId > 0;
        }

        public static bool IsValidFullName(string fullName)
        {
            return !string.IsNullOrWhiteSpace(fullName) && fullName.Length >= 3;
        }

        public static bool IsValidDateOfBirth(DateTime dateOfBirth)
        {
            return dateOfBirth < DateTime.Now;
        }

        public static bool IsValidGender(string gender)
        {
            return gender == "Male" || gender == "Female";
        }

        public static bool IsValidAverageScore(double averageScore)
        {
            return averageScore >= 0 && averageScore <= 100;
        }

    }
}
