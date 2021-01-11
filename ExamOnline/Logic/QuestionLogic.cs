using ExamOnline.Models;
using ExamOnline.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamOnline.Logic
{
    public class QuestionLogic
    {
        private readonly OnlineExaminationDBEntities _Context;
        public QuestionLogic()
        {
            _Context = new OnlineExaminationDBEntities();
        }
        public Question Create(QuestionViewModel Question) {

            if (Question == null)
                return null ;
            if (Question.Answers == null || Question.Answers.Count() == 0) {
                return null ;
            }


           var question  = AddQuestion(Question);
            AddAnswers(Question.Answers, question);
            if (_Context.SaveChanges() > 0) {
                return question;
            }
            return null;
        }
      private Question AddQuestion(QuestionViewModel Question) {
            Question question = new Question
            {
                Text = Question.Text + " ?",
                IsSingleAnswer = !Question.IsSingleAnswer
            };
            _Context.Questions.Add(question);
            return question;
        }
        private void AddAnswers(IEnumerable<Answer> answers, Question question) {
            List<Answer> Answers = new List<Answer>();
            foreach (var answer in answers)
            {
                Answer AnswerQuestion = new Answer
                {
                    Text = answer.Text,
                    QuestionID = question.ID,
                    Question = question
                };
                Answers.Add(AnswerQuestion);
            }

            _Context.Answers.AddRange(Answers);
        }

        public void Dispose() {
            _Context.Dispose();
        }
    }
}