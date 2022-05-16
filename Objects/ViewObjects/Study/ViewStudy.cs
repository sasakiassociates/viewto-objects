using System.Collections.Generic;
using ViewObjects;

namespace ViewTo.ViewObjects
{
	public class ViewStudy : IViewStudy
	{
		public ViewStudy() => objs = new List<IViewObj>();

		public string viewName { get; set; }
		public bool isValid
		{
			get => viewName.Valid() && objs.Valid();
		}
		public List<IViewObj> objs { get; set; }
	}
}