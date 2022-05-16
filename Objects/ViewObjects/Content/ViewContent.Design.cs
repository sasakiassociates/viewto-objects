using System.Collections.Generic;
using ViewObjects;

namespace ViewTo.ViewObjects
{
	public class DesignContent : IDesignContent
	{
		public string viewName { get; set; }
		public ViewColor viewColor { get; set; }
		public List<object> objects { get; set; }
	}
}