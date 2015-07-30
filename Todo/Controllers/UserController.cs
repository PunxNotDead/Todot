using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using Todo.Models;
using Ninject;

namespace Todo.Controllers
{
    public class UserController : Controller
    {
        private UserDbContext db = new UserDbContext();

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult New()
        {
            var reader = new System.IO.StreamReader(Request.InputStream);
            var json = reader.ReadToEnd();

            var user = JsonConvert.DeserializeObject<User>(json);
            user.RegistrationDate = DateTime.Now;
            user.PasswordHash = Crypto.HashPassword(user.Password);

            try
            {
                if (ModelState.IsValid)
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    return Json(new { errors = Enumerable.Empty<string>().ToArray() });
                }
            }
            catch (DbEntityValidationException ex) //validation errors
            {
                return Json(new { errors = ex.EntityValidationErrors.SelectMany(v => v.ValidationErrors).Select(e => e.ErrorMessage) });
            }
            catch (DataException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            var allErrors = ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage);
            return Json(new { errors = allErrors });
        }
    }
}