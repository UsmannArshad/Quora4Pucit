using System;
using System.Collections.Generic;

namespace QuoraForPucit.Models
{
    public partial class User
    {
        public User()
        {
            AComments = new HashSet<AComment>();
            Answers = new HashSet<Answer>();
            QComments = new HashSet<QComment>();
            Questions = new HashSet<Question>();
        }

        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string? Github { get; set; }
        public string? Twitter { get; set; }
        public string? Website { get; set; }
        public byte[]? ProfilePicture { get; set; }

        public virtual ICollection<AComment> AComments { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<QComment> QComments { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
