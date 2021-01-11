using ExamOnline.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamOnline.ViewModel
{
    public class QuestionViewModel
    {
   
        [Required]
        public string Text { get; set; }
        [Display(Name = "multiple choice")]
        public bool IsSingleAnswer { get; set; }

        public IEnumerable<Answer> Answers { get; set; }
        public QuestionViewModel()
        {
            Answers = new HashSet<Answer>();
        }
    }
}