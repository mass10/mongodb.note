using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace mongo1
{
	internal sealed class Util
	{
		private Util() { }

		public static string FormatJson(string s)
		{
			object unknown = JsonConvert.DeserializeObject(s);
			return JsonConvert.SerializeObject(unknown, Formatting.Indented);
		}
	}
}
