using ExamOnline.Models;
using ExamOnline.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExamOnline.Logic
{
    public class ExamLogic
    {
        private readonly OnlineExaminationDBEntities _Context;
        public ExamLogic()
        {
            _Context = new OnlineExaminationDBEntities();
        }
        public Exam Create(ExamViewModel Exam)
        {

            if (Exam == null)
                return null;
            if (Exam.QuestionsID == null || Exam.QuestionsID.Count() == 0)
            {
                return null;
            }


            var exam = AddExam(Exam);
            AddExamQuestion(Exam.QuestionsID, exam);
            
            if (_Context.SaveChanges() > 0)
            {
                return exam;
            }
            return null;
        }

        private void AddExamQuestion(ICollection<int> questionsID, Exam exam)
        {
            List<ExamQuestion> ExamQuestions = new List<ExamQuestion>();
                 
            foreach (var QuestionID in questionsID)
            {
                ExamQuestion examQuestion = new ExamQuestion
                {
                    ExamID = exam.ID,
                    QuestionID = QuestionID
                };
                ExamQuestions.Add(examQuestion);
            }

            _Context.ExamQuestions.AddRange(ExamQuestions);

        }

        private Exam AddExam(ExamViewModel exam)
        {
          
            Exam Exam = new Exam
            {
                ExamName = exam.ExamName,
                ExamHours = exam.ExamHours,
                
            };
            _Context.Exams.Add(Exam);
            return Exam;

        }

        public IEnumerable<Exam> GetExams()
        {

            return _Context.Exams.ToList();
        }
        public Exam GetExam(int ExamID)
        {

            return _Context.Exams.Where(Exam => Exam.ID == ExamID).Include("ExamQuestions").SingleOrDefault(); ;
        }
        public ExamViewModel GetExamViewModel()
        {

            ExamViewModel exam = new ExamViewModel();
            exam.Questions = _Context.Questions.ToList();
            return exam;
        }



    }
}