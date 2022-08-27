namespace QuoraForPucit.Models.ViewModel
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string? About { get; set; }
        public string? Github { get; set; }
        public string? Twitter { get; set; }
        public string? Website { get; set; }
        public IFormFile? ProfilePicture { get; set; }
        public string? PicturePath { get; set; }
    }
}
