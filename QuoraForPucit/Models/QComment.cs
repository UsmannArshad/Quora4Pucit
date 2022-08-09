using System;
using System.Collections.Generic;

namespace QuoraForPucit.Models
{
    public partial class QComment
    {
        public int Id { get; set; }
        public string Comment { get; set; } = null!;
        public int QuestionId { get; set; }
        public int QCommenterId { get; set; }

        public virtual User QCommenter { get; set; } = null!;
        public virtual Question Question { get; set; } = null!;
    }
}
