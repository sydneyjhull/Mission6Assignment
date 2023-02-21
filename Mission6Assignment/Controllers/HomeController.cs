using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission6Assignment.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6Assignment.Controllers
{
    public class HomeController : Controller
    {
        //defining the scope to be any of these methods
        private MovieSubmissionContext msContext { get; set; }
        //constructor
        public HomeController(MovieSubmissionContext x)
        {
            msContext = x;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieSubmission ()
        {
            //dynamic variable to hold list of categories
            ViewBag.Categories = msContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult MovieSubmission (SubmissionResponse sr)
        {
            //if the model has all the required fields filled out
            if (ModelState.IsValid)
            {
                msContext.Add(sr);
                msContext.SaveChanges();

                return View("Confirmation", sr);
            }
            else
            {
                ViewBag.Categories = msContext.Categories.ToList();
                return View(sr);
            }
        }

        public IActionResult Podcast()
        {
            return View();
        }

        public IActionResult MovieList ()
        {
            //taking database set and putting it into a list
            var movies = msContext.Responses
                .Include(m => m.Category)
                .ToList();
            return View(movies);
        }

        [HttpGet]
        //receiving the submissionid
        public IActionResult Edit (int submissionid)
        {
            ViewBag.Categories = msContext.Categories.ToList();
            //takes the submissionid receieved and finds the matching id in the database
            var submission = msContext.Responses.Single(m => m.SubmissionId == submissionid);
            return View("MovieSubmission", submission);
        }

        [HttpPost]
        public IActionResult Edit (SubmissionResponse response)
        {
            msContext.Update(response);
            msContext.SaveChanges();
            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete (int submissionid)
        {
            var submission = msContext.Responses.Single(m => m.SubmissionId == submissionid);
            return View(submission);
        }

        [HttpPost]
        public IActionResult Delete (SubmissionResponse sr)
        {
            msContext.Responses.Remove(sr);
            msContext.SaveChanges();
            return RedirectToAction("MovieList");
        }
    }
}
