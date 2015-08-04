using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using Todo.Models;
using Todo.Interfaces;
using Todo.Helpers;
using System.Data.Entity.Infrastructure;
using Todo.Models.Forms;

namespace Todo.Controllers
{
	public class UserController : JsonController
	{
		private IUserRepository userRepository = null;

		public UserController(IUserRepository repository)
		{ 
			userRepository = repository;
		}

		// GET: /Account/Register
		[AllowAnonymous]
		public ActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public JsonResult New()
		{
			var userRegistrationForm = ParseJson<UserRegistrationForm>();

			if (userRegistrationForm == null)
			{ 
				return Json(JsonHelper.CreateErrorResponse("Bad Request"));
			}

			if (TryValidateModel(userRegistrationForm))
			{
				var errors = new string[] { };
				var user = new User();
				user.Login = userRegistrationForm.Login;
				user.Name = userRegistrationForm.Name;
				user.PasswordHash = Crypto.HashPassword(userRegistrationForm.Password);

				try
				{
					userRepository.Save(user);

					return Json(new { errors = Enumerable.Empty<string>().ToArray() });
				}
				catch (DbEntityValidationException ex) //db validation errors
				{
					errors = ex.EntityValidationErrors.SelectMany(v => v.ValidationErrors).Select(e => e.ErrorMessage).ToArray<string>();
				}
				catch (DbUpdateException ex)
				{
					errors = new string[] { "Login already registered" };
				}
				catch (Exception ex)
				{
					errors = new string[] { ex.Message };
				}

				return Json(JsonHelper.CreateErrorResponse(errors));
			}
			else
			{
				var allErrors = ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage);
				return Json(JsonHelper.CreateErrorResponse(allErrors));
			}
		}

		// GET: Login
		[HttpGet]
		[ActionName("Login")]
		public ActionResult LoginRender()
		{
			return View();
		}

		// POST: Login
		[HttpPost]
		public JsonResult Login(LoginForm loginForm)
		{
			//var LoginForm = ParseJson<LoginForm>();
			if (loginForm == null)
			{ 
				return Json(JsonHelper.CreateErrorResponse("Bad Request"));
			}

			if (TryValidateModel(loginForm))
			{
				var errors = new string[] { };

				try
				{
					var user = userRepository.Users.FirstOrDefault<User>(record => record.Login == loginForm.Login && record.PasswordHash == Crypto.HashPassword(loginForm.Password));

					if (user == null)
					{
						errors = new string[] { "Login or password is incorrect" };
					}
					else
					{
						return Json(new { errors = Enumerable.Empty<string>().ToArray() });
					}
				}
				catch (DbEntityValidationException ex) //db validation errors
				{
					errors = ex.EntityValidationErrors.SelectMany(v => v.ValidationErrors).Select(e => e.ErrorMessage).ToArray<string>();
				}
				catch (DbUpdateException ex)
				{
					errors = new string[] { "Login already registered" };
				}
				catch (Exception ex)
				{
					errors = new string[] { ex.Message };
				}

				return Json(JsonHelper.CreateErrorResponse(errors));
			}
			else
			{
				var allErrors = ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage);
				return Json(JsonHelper.CreateErrorResponse(allErrors));
			}
		}
	}
}
