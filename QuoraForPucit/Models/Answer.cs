using QuoraForPucit.Models;
using System;
using System.Collections.Generic;

namespace QuoraForPucit.Models
{
    public partial class Answer
    {
        public Answer()
        {
            AComments = new HashSet<AComment>();
            AnswerUpvoters = new HashSet<AnswerUpvoter>();
        }

        public int Id { get; set; }
        public string AnswerDescription { get; set; } = null!;
        public DateTime? Time { get; set; }=DateTime.Now;
        public int? Upvote { get; set; }
        public int AnswererId { get; set; }
        public int QuestionId { get; set; }
        public string AnswererName { get; set; } = null!;

        public virtual User Answerer { get; set; } = null!;
        public virtual Question Question { get; set; } = null!;
        public virtual ICollection<AComment> AComments { get; set; }
        public virtual ICollection<AnswerUpvoter> AnswerUpvoters { get; set; }
    }
}
