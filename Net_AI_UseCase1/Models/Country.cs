namespace Net_AI_UseCase1.Models
{
    public class Country
    {
        public Name Name { get; set; } = new ();
        public int Population { get; set; }
    }

    public class Name 
    {
        public string Common { get; set; } = "";
    }
}
