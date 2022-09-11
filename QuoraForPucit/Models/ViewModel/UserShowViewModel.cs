namespace QuoraForPucit.Models.ViewModel
{
    public class UserShowViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string? ProfilePicture { get; set; }
    }
}
