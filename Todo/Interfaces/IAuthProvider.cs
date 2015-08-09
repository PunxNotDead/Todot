using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Interfaces
{
	public interface IAuthProvider
	{
		bool Authenticate(string username, string password);
		void Logout();
	}
}
