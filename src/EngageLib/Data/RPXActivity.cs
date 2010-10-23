using System.Collections.Generic;

namespace EngageLib.Data
{
	public class EngageActivity
	{
		public string Url { get; set; }
		public string Action { get; set; }
		public string UserGeneratedContent { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public IEnumerable<string> Links { get; set; }
		public IEnumerable<EngageActivityMedia> Media { get; set; }
		public IDictionary<string, object> Properties { get; set; }
	}
}