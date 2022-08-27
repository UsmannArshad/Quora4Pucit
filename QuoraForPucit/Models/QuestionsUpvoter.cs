using System;
using System.Collections.Generic;

namespace QuoraForPucit.Models
{
    public partial class QuestionsUpvoter
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }
        public int UpvoteStatus { get; set; }

        public virtual Question Question { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
