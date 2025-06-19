namespace surdurulebilirlik_app.Models
{
    public class Source
    {
        public int Id { get; set; }
        public int SurdurulebilirlikId { get; set; }
        public int Number { get; set; }
        public int SubTypeId { get; set; }
    }

    public class SourceCreateDto
    {
        public int DataNameId { get; set; }   // For Surdurulebilirlik
        public int Number { get; set; }
        public int SubTypeId { get; set; }
    }
}
