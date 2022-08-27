using System;
using System.ComponentModel.DataAnnotations;
namespace QuoraForPucit.Models
{
    public partial class User
    {
        public User()
        {
            AComments = new HashSet<AComment>();
            AnswerUpvoters = new HashSet<AnswerUpvoter>();
            Answers = new HashSet<Answer>();
            QComments = new HashSet<QComment>();
            Questions = new HashSet<Question>();
            QuestionsUpvoters = new HashSet<QuestionsUpvoter>();
        }
        public int Id { get; set; }
        [EmailAddress(ErrorMessage = "Provide a Valid Email"), Required(ErrorMessage = "Enter Username")]
        public string Username { get; set; } = null!;
        [RegularExpression("^(?=.*[0-9])"
                       + "(?=.*[a-z])(?=.*[A-Z])"
                       + "(?=.*[@#$%^&+=*])"
                       + "(?=\\S+$).{8,20}$", ErrorMessage ="Password must be like Aa1@ and length must be 8-20")]
        public string Password { get; set; } = null!;
        [Required(ErrorMessage = "Enter Your Name"), StringLength(30, ErrorMessage = "Name cannot exceeds thirty characters")]
        public string Name { get; set; } = null!;
        [Range(15, 100, ErrorMessage = "Age must be in between 15 and 100"), Required]
        public int Age { get; set; }
        public string? About { get; set; }
        public string? Github { get; set; }
        public string? Twitter { get; set; }
        public string? Website { get; set; }
        public string? ProfilePicture { get; set; }

        public virtual ICollection<AComment> AComments { get; set; }
        public virtual ICollection<AnswerUpvoter> AnswerUpvoters { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<QComment> QComments { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<QuestionsUpvoter> QuestionsUpvoters { get; set; }
    }
}
