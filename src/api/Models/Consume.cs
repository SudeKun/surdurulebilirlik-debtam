namespace surdurulebilirlik_app.Models
{
    public class Consume
    {
        public int Id { get; set; }
        public int SurdurulebilirlikId { get; set; }
        public int Number { get; set; }
        public int Change { get; set; }
        public int SubTypeId { get; set; }
    }

    public class ConsumeCreateDto
    {
        public int DataNameId { get; set; }
        public int Number { get; set; }
        public int Change { get; set; }
        public int SubTypeId { get; set; }
    }
}
