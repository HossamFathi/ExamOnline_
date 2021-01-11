using ExamOnline.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamOnline.ViewModel
{
    public class ExamViewModel
    {
        [Required]
        public string ExamName { get; set; }
        [Required]
        [Range(1 , int.MaxValue)]
        public int ExamHours { get; set; }
        [Display(Name="Questions")]
        public ICollection<int> QuestionsID { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ExamViewModel()
        {
            QuestionsID = new HashSet<int>();
            Questions = new HashSet<Question>();
        }
    }
}