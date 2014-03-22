using System.Collections.Generic;

namespace WinForms
{
	public class FacebookData
	{
		public string id { get; set; }

		public string name { get; set; }

		public string picture { get; set; }

		public string link { get; set; }

		public string message { get; set; }

		public string description { get; set; }

		public string created_time { get; set; }
	}

	public class Facebook
	{
		public List<FacebookData> data { get; set; }
	}
}