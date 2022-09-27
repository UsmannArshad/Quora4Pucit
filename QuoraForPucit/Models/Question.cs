using QuoraForPucit.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuoraForPucit.Models
{
    public partial class Question:Entity
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
            QComments = new HashSet<QComment>();
            QuestionsUpvoters = new HashSet<QuestionsUpvoter>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage ="Title is Required"),StringLength(80, ErrorMessage = "Title cannot exceeds eighty characters")]
        public string Title { get; set; } = null!;
        [Required(ErrorMessage ="Description is Required")]
        public string Description { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public DateTime? Time { get; set; }=DateTime.Now;
        public int QuestionaireId { get; set; }
        public int? Upvote { get; set; }
        public string QuestionaireName { get; set; } = null!;

        public virtual User Questionaire { get; set; } = null!;
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<QComment> QComments { get; set; }
        public virtual ICollection<QuestionsUpvoter> QuestionsUpvoters { get; set; }
    }
}
