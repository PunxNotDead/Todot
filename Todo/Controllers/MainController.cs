using System.Web.Mvc;
using Todo.Models;
using Todo.Interfaces;

namespace Todo.Controllers
{
	public class MainController : Controller
	{
		protected IUserRepository userRepository;

		public MainController(IUserRepository repository) { 
			userRepository = repository;
		}

		// GET: /Main/Index
		[Authorize]
		public ActionResult Index()
		{
			return View(userRepository.Users);
		}
	}
}