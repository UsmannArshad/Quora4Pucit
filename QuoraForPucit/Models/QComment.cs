using QuoraForPucit.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuoraForPucit
{
    public partial class QComment:Entity
    {
        public int Id { get; set; }
        [Required, StringLength(240, ErrorMessage = "Comment cannot exceeds 240 characters")]
        public string Comment { get; set; } = null!;
        public int QuestionId { get; set; }
        public int QCommenterId { get; set; }
        public string QcommenterName { get; set; } = null!;

        public virtual User QCommenter { get; set; } = null!;
        public virtual Question Question { get; set; } = null!;
    }
}
