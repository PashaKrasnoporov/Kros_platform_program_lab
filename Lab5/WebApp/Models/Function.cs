namespace WebApp.Models
{
    public class Function
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Input { get; set; }
        public HashSet<string> Output { get; set; }
        public string ErrorMessage { get; set; }
    }
}
