using System;
using System.Collections.Generic;

namespace QuoraForPucit.Models
{
    public partial class AnswerUpvoter:Entity
    {
        public int Id { get; set; }
        public int AnswerId { get; set; }
        public int UserId { get; set; }
        public int UpvoteStatus { get; set; }

        public virtual Answer Answer { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
