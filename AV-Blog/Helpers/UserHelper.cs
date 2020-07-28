using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AV_Blog.Models;

namespace AV_Blog.Helpers
{
	public class UserHelper
	{
		private ApplicationDbContext db = new ApplicationDbContext();
		public string GetDisplayName(string userId)
		{
			var user = db.Users.Find(userId);
			return user.DisplayName;
		}

		public string GetFullName(string userId)
		{
			var user = db.Users.Find(userId);
			var firstName = user.FirstName;
			var lastName = user.LastName;
			return firstName + "" + lastName;
		}
	}

}