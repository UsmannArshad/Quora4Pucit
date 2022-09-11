using System;
using System.Collections.Generic;

namespace QuoraForPucit.Models
{
    public partial class AComment:Entity
    {
        public int Id { get; set; }
        public string Comment { get; set; } = null!;
        public int AnswerId { get; set; }
        public int UserId { get; set; }

        public virtual Answer Answer { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
