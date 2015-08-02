using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Todo.Helpers
{
	public class JsonHelper
	{
		public static object CreateErrorResponse(string error) { 
			return new { errors = new string[] { error }};
		}

		public static object CreateErrorResponse(IEnumerable<string> errors) { 
			return new { errors = errors };
		}
	}
}