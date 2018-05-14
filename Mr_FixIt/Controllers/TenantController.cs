using Microsoft.AspNet.Identity;
using Mr_FixIt.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Mr_FixIt.Controllers
{
    public class TenantController : Controller
    {
        ApplicationDbContext context;
        public TenantController()
        {
            context = new ApplicationDbContext();
        }

        // GET: Tenant
        public ActionResult Index()
        {
            string UserID = User.Identity.GetUserId();
            try
            {
                Tenant tenant = (from row in context.Tenants where row.UserId == UserID select row).First();
                return View(tenant);
            }
            catch
            {
                return RedirectToAction("Create");
            }
        }

        public ActionResult Create()
        {
            TenantCreateViewModel model = new TenantCreateViewModel();
            model.Buildings = (from row in context.Buildings select row).ToList();
            model.BuildingList = new SelectList(model.Buildings, "ID", "Name");
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(TenantCreateViewModel model)
        {
            string userid = User.Identity.GetUserId();
            Tenant tenant = model.Tenant;
            tenant.UserId = userid;
            tenant.User = (from row in context.Users where row.Id == userid select row).First();
            tenant.Building = (from row in context.Buildings where row.ID == tenant.BuildingId select row).First();
            tenant.EmailAdrress = tenant.User.Email;
            context.Tenants.Add(tenant);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateTicket()
        {
            List<Ticket> Tickets = (from row in context.Tickets select row).ToList();
            ViewBag.BuildingList = Tickets;
            return View();
        }

        [HttpPost]
        public ActionResult CreateTicket(Ticket model)
        {
            string UserID = User.Identity.GetUserId();
            try
            {
                Tenant tenant = (from row in context.Tenants where row.UserId == UserID select row).First();
                context.Tickets.Add(model);
                context.SaveChanges();
                Ticket ticket = (from row in context.Tickets where row.ID == model.ID select row).First();
                TicketXTenant junction = new TicketXTenant();
                junction.Tenant = tenant;
                junction.TenantId = tenant.ID;
                junction.ticket = ticket;
                junction.TicketId = model.ID;
                context.TicketTenantJunctions.Add(junction);
                context.SaveChanges();
                return RedirectToAction("Tickets");
            }
            catch
            {
                return RedirectToAction("Create");
            }
        }

        public ActionResult Tickets()
        {
            string UserID = User.Identity.GetUserId();
            try
            {
                Ticket ticket = (from row in context.Tickets where row.ID == row.ID select row).First();
                return View(ticket);
            }
            catch
            {
                return RedirectToAction("CreateTicket");
            }
        }



        public ActionResult CreateBulletin()
        {
            List<Building> Buildings = (from row in context.Buildings select row).ToList();
            ViewBag.BuildingList = Buildings;
            return View();
        }

        [HttpPost]
        public ActionResult CreateBulletin(BulletinBoard model)
        {
            string UserID = User.Identity.GetUserId();
            string DatePosted = DateTime.Now.ToString();
            int buildingId = (from row in context.Tenants where row.UserId == UserID select row.BuildingId).First();
            model.VisableToTenants = true;
            model.OwnerId = UserID;
            model.Owner = (from row in context.Users where row.Id == UserID select row).First();
            model.BuildingId = buildingId;
            model.Building = (from row in context.Buildings where row.ID == buildingId select row).First();
            model.DatePosted = DatePosted;
            model.DateEdited = DatePosted;
            context.BulletinBoards.Add(model);
            context.SaveChanges();
            return RedirectToAction("Bulletins");
        }

        public ActionResult Bulletins()
        {
            string UserID = User.Identity.GetUserId();
            BulletinListViewModel model = new BulletinListViewModel();
            model.AllBulletins = (from row in context.BulletinBoards where row.VisableToTenants == true && row.OwnerId != UserID select row).ToList();
            model.OwnedBulletins = (from row in context.BulletinBoards where row.VisableToTenants == true && row.OwnerId == UserID select row).ToList();
            return View(model);
        }

        public ActionResult EditBulletin(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BulletinBoard bulletin = context.BulletinBoards.Find(id);
            if (bulletin == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(context.Users, "Id", "Email", bulletin.ID);
            return View(bulletin);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBulletin([Bind(Include = "Building,BuildingId,DateEdited,DatePosted,ID,Message,NotListBuildingName,Owner,OwnerId,Subject,VisableToTenants")] BulletinBoard bulletinBoard)
        {
            if (ModelState.IsValid)
            {
                context.Entry(bulletinBoard).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("EditBulletin");
            }
            ViewBag.UserId = new SelectList(context.Users, "Id", "Email", bulletinBoard.ID);
            return View(bulletinBoard);
        }
    }
}