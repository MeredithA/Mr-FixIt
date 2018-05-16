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
    public class ManagerController : Controller
    {
        ApplicationDbContext context;
        public ManagerController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Manager
        public ActionResult Index()
        {
            string UserID = User.Identity.GetUserId();
            try
            {
                Manager manager = (from row in context.Managers where row.UserId == UserID select row).First();
                return View(manager);
            }
            catch
            {
                return RedirectToAction("Create");
            }
        }
        [HttpGet]
        public ActionResult AddBuilding()
        {
            try
            {
                string UserID = User.Identity.GetUserId();
                Manager manager = (from row in context.Managers where row.UserId == UserID select row).First();
            }
            catch
            {
                return RedirectToAction("Create");
            }
            return View();
        }

        [HttpPost]
        public ActionResult AddBuilding(Building model)
        {
            string UserID = User.Identity.GetUserId();
            try
            {
                Manager manager = (from row in context.Managers where row.UserId == UserID select row).First();
                context.Buildings.Add(model);
                context.SaveChanges();
                Building building = (from row in context.Buildings where row.ID == model.ID select row).First();
                BuildingXManager junction = new BuildingXManager();
                junction.ManagerId = manager.ID;
                junction.building = building;
                junction.BuildId = model.ID;
                context.BuildingManagerJunctions.Add(junction);
                context.SaveChanges();
                return RedirectToAction("Buildings");
            }
            catch
            {
                return RedirectToAction("Create");
            }
        }

        public ActionResult Buildings()
        {
            string UserID = User.Identity.GetUserId();
            Manager manager;
            try
            {
                manager = (from row in context.Managers where row.UserId == UserID select row).First();
            }
            catch
            {
                return RedirectToAction("Create");
            }
            List<Building> model = (from row in context.BuildingManagerJunctions where row.ManagerId == manager.ID select row.building).ToList();
            return View(model);
        }

        public ActionResult EditBuilding(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Building building = context.Buildings.Find(id);
            if (building == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(context.Users, "Id", "Email", building.ID);
            return View(building);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBuilding([Bind(Include = "ID,Name,Email,Building,StreetAddress,City,State,ZipCode")] Building building)
        {
            if (ModelState.IsValid)
            {
                context.Entry(building).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Buildings");
            }
            return RedirectToAction("Buildings");
        }

        public ActionResult DeleteBuilding(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Building building = context.Buildings.Find(id);
            if (building == null)
            {
                return HttpNotFound();
            }
            return View(building);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBuilding(int id)
        {

            Building building = context.Buildings.Find(id);
            context.Buildings.Remove(building);
            context.SaveChanges();
            return RedirectToAction("Buildings");
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Manager model)
        {
            string UserId = User.Identity.GetUserId();
            model.UserId = UserId;
            model.User = (from row in context.Users where row.Id == UserId select row).First();
            model.EmailAdrress = model.User.Email;
            context.Managers.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");
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
            model.OwnerId = UserID;
            model.Owner = (from row in context.Users where row.Id == UserID select row).First();
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
            model.AllBulletins = (from row in context.BulletinBoards where  row.OwnerId != UserID select row).ToList();
            model.OwnedBulletins = (from row in context.BulletinBoards where row.OwnerId == UserID select row).ToList();
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

        public ActionResult DeleteBulletin(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BulletinBoard bulletinBoard = context.BulletinBoards.Find(id);
            if (bulletinBoard == null)
            {
                return HttpNotFound();
            }
            return View(bulletinBoard);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBulletin(BulletinBoard model)
        {

            BulletinBoard bulletin = (from row in context.BulletinBoards where model.ID == row.ID select row).First();
            context.BulletinBoards.Remove(bulletin);
            context.SaveChanges();
            return RedirectToAction("Bulletins");
        }

        public ActionResult ViewAllTickets()
        {
            return View();
        }

        public ActionResult TicketUpdateNotification()
        {
            return View();
        }
    }
}