using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mr_FixIt.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
                if (User.IsInRole("Tenant"))
                {
                    return RedirectToAction("Index", "Tenant");
                }
                else if (User.IsInRole("Employee"))
                {
                    return RedirectToAction("Index", "Employee");
                }
                else if (User.IsInRole("Manager"))
                {
                    return RedirectToAction("Index", "Manager");
                }
                else
                {
                    return View();
                }
            }

            public ActionResult About()
            {
                ViewBag.Message = "Your application description page.";

                return View();
            }

            public ActionResult Contact()
            {
                ViewBag.Message = "Your contact page.";

                return View();
            }
        }
    }