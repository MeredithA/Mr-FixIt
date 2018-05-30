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

        public ActionResult Tickets()
        {
            string UserId = User.Identity.GetUserId();
            int id = (from row in context.Employees where row.UserId == UserId select row.ID).First();
            List<Ticket> model = (from row in context.Tickets where row.EmployeeId == id select row).ToList();
            return View(model);
        }

        public ActionResult EditTicket(int? id)
        {
            Ticket ticket = (from row in context.Tickets where row.ID == id select row).First();

            ViewBag.Employees = context.Employees;
            return View(ticket);
        }

        [HttpPost]
        public ActionResult EditTicket(Ticket model)
        {
            Ticket ticket = context.Tickets.Find(model.ID);
            ticket.TicketNotes = model.TicketNotes;
            ticket.Employee = context.Employees.Find(model.EmployeeId);
            ticket.UpdateNote = model.UpdateNote;
            ticket.UpdatedDate = DateTime.Now;
            ticket.EmployeeId = model.EmployeeId;
            context.SaveChanges();

            return RedirectToAction("tickets");
        }

        public ActionResult BulletinBoard()
        {
            string UserID = User.Identity.GetUserId();
            BulletinListViewModel model = new BulletinListViewModel();
            model.AllBulletins = (from row in context.BulletinBoards where row.VisableToTenants == false && row.OwnerId != UserID select row).ToList();
            model.OwnedBulletins = (from row in context.BulletinBoards where row.VisableToTenants == false && row.OwnerId == UserID select row).ToList();
            return View(model);
        }
    }
}