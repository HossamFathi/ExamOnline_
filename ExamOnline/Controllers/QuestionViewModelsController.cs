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
    public class QuestionViewModelsController : Controller
    {
     
        private readonly QuestionLogic _Logic;
        public QuestionViewModelsController()
        {
            _Logic = new QuestionLogic();
        }

       
       
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Text,IsSingleAnswer,Answers")] QuestionViewModel questionViewModel)
        {
            if (ModelState.IsValid)
            {
                if(_Logic.Create(questionViewModel) != null)
                return RedirectToAction("Create" , "Exams" );
            }

            return View(questionViewModel);
        }

        
  

        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _Logic.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
