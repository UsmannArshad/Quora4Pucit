using System;
using System.Collections.Generic;

namespace QuoraForPucit.Models
{
    public partial class Answer
    {
        public Answer()
        {
            AComments = new HashSet<AComment>();
        }

        public int Id { get; set; }
        public string AnswerDescription { get; set; } = null!;
        public DateTime Time { get; set; }
        public int? Upvote { get; set; }
        public int AnswererId { get; set; }
        public int QuestionId { get; set; }

        public virtual User Answerer { get; set; } = null!;
        public virtual Question Question { get; set; } = null!;
        public virtual ICollection<AComment> AComments { get; set; }
    }
}
