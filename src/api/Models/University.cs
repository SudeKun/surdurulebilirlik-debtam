amespace surdurulebilirlik_app.Models
{
    public class University
    {
        public int Id { get; set; }
        public int SurdurulebilirlikId { get; set; }
        public int Number { get; set; }
        public int SubTypeId { get; set; }

    }

    public class UniversityCreateDto
    {
        public int DataNameId { get; set; }   // For Surdurulebilirlik
        public int Number { get; set; }
        public int SubTypeId { get; set; }
    }
}
