namespace MVC5_POC.Models
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }
        public bool IsAlive { get; set; }
    }
}
