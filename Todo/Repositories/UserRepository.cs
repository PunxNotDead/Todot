﻿using System.Collections.Generic;
using System.Linq;
using Todo.Interfaces;
using Todo.Models;

namespace Todo.Repositories
{
	public class UserRepository : IUserRepository
	{
		private UserDbContext db = new UserDbContext();

		public IEnumerable<Models.User> Users
		{
			get { return db.Users.ToList(); }
		}

		public bool Save(User user)
		{ 
			db.Users.Add(user);
			db.SaveChanges();

			return true;
		}
	}
}