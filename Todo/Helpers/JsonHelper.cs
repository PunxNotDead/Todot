using System.Collections.Generic;

namespace Todo.Helpers
{
	public class JsonHelper
	{
		public static object CreateErrorResponse(string error)
		{ 
			return new { errors = new string[] { error }};
		}

		public static object CreateErrorResponse(IEnumerable<string> errors)
		{ 
			return new { errors = errors };
		}
	}
}