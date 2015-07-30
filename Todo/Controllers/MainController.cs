using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Todo.Models;
using System.Configuration;
using Ninject;
using Todo.Interfaces;

namespace Todo.Controllers
{
    public class MainController : Controller
    {
        protected IUserRepository userRepository;

        private UserDbContext db = new UserDbContext();

        public MainController(IUserRepository repository) { 
            userRepository = repository;
        }

        // GET: /Main/Index
        public ActionResult Index()
        {
            return View(userRepository.Users);
        }

        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }
    }
}