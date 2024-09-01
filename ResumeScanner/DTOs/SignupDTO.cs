namespace ResumeScanner.DTOs
{
    public class SignupDTO
    {
        public string userName { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        public string jobTitle { get; set; }
        public int yearsOfExperience { get; set; }

        public string nameOfCurrentCompany { get; set; }
        public int graduationYear { get; set; }


        public string universityName { get; set; }
        public int mastersDegreeStatus { get; set; }

        public int phdDegreeStatus { get; set; }

        public string address { get; set; }


    }
}
