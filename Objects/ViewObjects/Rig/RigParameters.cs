using System.Collections.Generic;
using ViewObjects;

namespace ViewTo.ViewObjects
{
	public class RigParameters : IRigParam
	{
		/// <summary>
		///   List of bundles for different viewer objects
		/// </summary>
		public List<IViewerBundle> bundles { get; set; }
	}

	public class RigParametersIsolated : RigParameters
	{
		public List<ViewColor> colors { set; get; }
	}
}