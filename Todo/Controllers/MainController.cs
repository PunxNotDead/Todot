using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Todo.Models;
using System.Configuration;

namespace Todo.Controllers
{
    public class MainController : Controller
    {
        private UserDbContext db = new UserDbContext();

        // GET: Main
        public ActionResult Index()
        {
            var l2 = db.Users.ToList();

            return View(l2);
            
        }

        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
    }
}