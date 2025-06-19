namespace surdurulebilirlik_app.Models
{
    public class Writing
    {
        public int Id { get; set; }
        public int SurdurulebilirlikId { get; set; }
        public int Choice { get; set; }
        public int Command { get; set; }
        public int SubTypeId { get; set; }
    }

    public class WritingCreateDto
    {
        public int DataNameId { get; set; }
        public int Choice { get; set; }
        public int Command { get; set; }
        public int SubTypeId { get; set; }
    }
}
