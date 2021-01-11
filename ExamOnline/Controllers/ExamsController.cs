using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExamOnline.Logic;
using ExamOnline.Models;
using ExamOnline.ViewModel;

namespace ExamOnline.Controllers
{
    public class ExamsController : Controller
    {
        private OnlineExaminationDBEntities db = new OnlineExaminationDBEntities();
        private readonly ExamLogic _Logic;
        public ExamsController()
        {
            _Logic = new ExamLogic();
        }
     
        public ActionResult index()
        {
           var  Exams = _Logic.GetExams();
            Dispose(true);
            return View(Exams);
        }

     
       [HttpPost]
        public ActionResult Details(int id)
        {
            if (Request.IsAjaxRequest())
            {
                Exam exam = _Logic.GetExam(id);
                return PartialView("_Details" ,exam);
            }
            return HttpNotFound();
           
        }

       
        public ActionResult Create()
        {
            ExamViewModel exam = _Logic.GetExamViewModel();
            return View(exam);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ExamName,ExamHours,QuestionsID")] ExamViewModel exam)
        {
            if (ModelState.IsValid)
            {
                if(_Logic.Create(exam)!= null )
                    return RedirectToAction("Index");
            }
            exam.Questions = db.Questions.ToList();
            return View(exam);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExamSubmit([Bind(Include = "ID,ExamName,ExamHours,QuestionsID")] ExamViewModel exam)
        {
            if (ModelState.IsValid)
            {
                if (_Logic.Create(exam) != null)
                    return RedirectToAction("Index");
            }
            exam.Questions = db.Questions.ToList();
            return View(exam);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
