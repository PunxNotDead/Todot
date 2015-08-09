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
		public string Name { get; set; }
		public Nullable<System.DateTime> RegistrationDate { get; set; }
		public string Login { get; set; }
		public string PasswordHash { get; set; }
	}
}
