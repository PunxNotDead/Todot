using Newtonsoft.Json;
using System;
using System.Data;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using Todo.Models;
using Todo.Interfaces;
using Todo.Helpers;

namespace Todo.Controllers
{
	public class UserController : Controller
	{
		private IUserRepository userRepository = null;

		public UserController(IUserRepository repository)
		{ 
			userRepository = repository;
		}

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

			if (user == null) { 
				return Json(JsonHelper.CreateErrorResponse("Bad Request"));
			}

			user.RegistrationDate = DateTime.Now;
			
			//ModelState.IsValid - not working without declaring model as param
			try
			{
				if (TryValidateModel(user))
				{
					user.PasswordHash = Crypto.HashPassword(user.Password);

					userRepository.Save(user);

					return Json(new { errors = Enumerable.Empty<string>().ToArray() });
				}
			}
			catch (DbEntityValidationException ex) //validation errors
			{
				return Json(JsonHelper.CreateErrorResponse(ex.EntityValidationErrors.SelectMany(v => v.ValidationErrors).Select(e => e.ErrorMessage)));
			}
			catch (Exception ex)
			{
				ModelState.AddModelError("", ex.Message);
			}

			var allErrors = ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage);
			return Json(JsonHelper.CreateErrorResponse(allErrors));
		}
	}
}