using System;
using System.ComponentModel.DataAnnotations;

namespace Todo.Models.Forms
{
	public class UserRegistrationForm
	{
		[Required(ErrorMessage = "Empty Name")]
		[MaxLength(64, ErrorMessage = "Max Name length is 64 symbols")]
		public string Name { get; set; }
		
		[Required(ErrorMessage = "Empty Login")]
		[MaxLength(64, ErrorMessage = "Max Login length is 64 symbols")]
		public string Login { get; set; }
		
		[Required(ErrorMessage = "Empty Password")]
		[MaxLength(64, ErrorMessage = "Max Password length is 64 symbols")]
		[MinLength(8, ErrorMessage = "Min Password length is 8 symbols")]
		public string Password { get; set; }

		[Required(ErrorMessage = "Passwords confirmation requred")]
		[MaxLength(64, ErrorMessage = "Min Password Confirmation length is 8 symbols")]
		[MinLength(8, ErrorMessage = "Min Password Confirmation length is 8 symbols")]
		[CompareAttribute("Password", ErrorMessage = "Passwords don't match.")]
		public string Password2 { get; set; }
	}
}