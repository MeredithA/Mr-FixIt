using Microsoft.AspNet.Identity;
using Mr_FixIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mr_FixIt.Controllers
{
    public class EmployeeController : Controller
    {
        ApplicationDbContext context;
        public EmployeeController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Employee
        public ActionResult Index()
        {
            string UserID = User.Identity.GetUserId();
            try
            {
                Employee employee = (from row in context.Employees where row.UserId == UserID select row).First();
                return View(employee);
            }
            catch
            {
                return RedirectToAction("Create");
            }

        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee model)
        {
            string UserId = User.Identity.GetUserId();
            model.UserId = UserId;
            model.User = (from row in context.Users where row.Id == UserId select row).First();
            model.EmailAdrress = model.User.Email;
            context.Employees.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }


    //public ActionResult UpdateTicket()
    //{
    //    return View("Index");
    //}

    //public ActionResult OpenTickets()
    //{
    //    return View();
    //}

    //public ActionResult UpdateTicket()
    //{
    //    return View();
    //}
}