using System.ComponentModel.DataAnnotations;

namespace Todo.Models
{
	using System;
	using System.Collections.Generic;
	
	public partial class User
	{
		public User() 
		{
			RegistrationDate = DateTime.Now;
		}

		public long ID { get; set; }
		public Nullable<System.DateTime> RegistrationDate { get; set; }

		[Required(ErrorMessage = "Empty Name"), MaxLength(64)]
		public string Name { get; set; }
		
		[Required(ErrorMessage = "Empty Login"), MaxLength(64)]
		public string Login { get; set; }
		
		[MaxLength(128)]
		public string PasswordHash { get; set; }
	}
}
