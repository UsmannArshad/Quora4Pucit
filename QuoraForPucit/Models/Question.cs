using System;
using System.Collections.Generic;

namespace QuoraForPucit.Models
{
    public partial class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
            QComments = new HashSet<QComment>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public DateTime Time { get; set; }
        public int QuestionaireId { get; set; }
        public int? Upvote { get; set; }

        public virtual User Questionaire { get; set; } = null!;
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<QComment> QComments { get; set; }
    }
}
