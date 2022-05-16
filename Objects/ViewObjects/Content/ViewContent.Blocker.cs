using System.Collections.Generic;
using ViewObjects;

namespace ViewTo.ViewObjects
{
	public class BlockerContent : IBlockerContent
	{
		public string viewName { get; set; } = "Blocker";
		public ViewColor viewColor { get; set; }
		public List<object> objects { get; set; }
	}
}