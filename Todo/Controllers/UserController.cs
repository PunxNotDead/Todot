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
	public class UserController : Controller
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
		public JsonResult New(UserRegistrationForm userRegistrationForm)
		{
			if (userRegistrationForm == null)
			{ 
				return Json(JsonHelper.CreateErrorResponse("Bad Request"));
			}

			if (TryValidateModel(userRegistrationForm))
			{
				var errors = new string[] { };
				var user = new User() {
					Login = userRegistrationForm.Login.Trim(),
					Name = userRegistrationForm.Name.Trim(),
					PasswordHash = PasswordHelper.CreateHash(userRegistrationForm.Password)
				};

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
			if (loginForm == null)
			{ 
				return Json(JsonHelper.CreateErrorResponse("Bad Request"));
			}

			if (TryValidateModel(loginForm))
			{
				var errors = new string[] { };

				try
				{
					var user = userRepository.Users.FirstOrDefault(b => b.Login == loginForm.Login);
					
					if (user == null || !PasswordHelper.ValidatePassword(loginForm.Password, user.PasswordHash))
					{
						errors = new string[] { "Login or password is incorrect" };
					}
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
