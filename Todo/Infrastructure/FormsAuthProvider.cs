using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Todo.Helpers;
using Todo.Interfaces;

namespace Todo.Infrastructure
{
	public class FormsAuthProvider : IAuthProvider
	{
		private IUserRepository userRepository = null;

		public FormsAuthProvider(IUserRepository repository)
		{
			userRepository = repository;
		}

		public bool Authenticate(string username, string password)
		{
			var user = userRepository.Users.FirstOrDefault(b => b.Login == username);
					
			if (user == null || !PasswordHelper.ValidatePassword(password, user.PasswordHash))
			{
				return false;
			}

			FormsAuthentication.SetAuthCookie(username, false);

			return true;
		}

		public void Logout()
		{
			FormsAuthentication.SignOut();
		}
	}
}