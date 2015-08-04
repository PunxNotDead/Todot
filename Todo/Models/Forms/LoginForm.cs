using System.ComponentModel.DataAnnotations;

namespace Todo.Models.Forms
{
	public class LoginForm
	{
		[Required(ErrorMessage = "Empty Login")]
		public string Login { get; set; }
		
		[Required(ErrorMessage = "Empty Password")]
		public string Password { get; set; }
	}
}