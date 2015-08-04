using System.Web.Mvc;
using Newtonsoft.Json;

namespace Todo.Controllers
{
	public class JsonController : Controller
	{
		public T ParseJson<T>()
		{
			var reader = new System.IO.StreamReader(Request.InputStream);
			var json = reader.ReadToEnd();

			return JsonConvert.DeserializeObject<T>(json);
		}
	}
}