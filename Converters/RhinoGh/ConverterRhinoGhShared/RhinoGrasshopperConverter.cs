using System.Collections.Generic;
using Rhino;
using Speckle.Core.Kits;
using ViewObjects.Converter.Script;

namespace ViewObjects.Converter.Rhino
{
	public partial class ViewObjRhinoConverter : ViewObjectConverter
	{

		public override string Description => "Converter for rhino/gh objects into base view objects";

		public override string Name => nameof(ViewObjRhinoConverter);

		private ISpeckleConverter defaultConverter { get; set; }

		public RhinoDoc Doc { get; set; }

		public override IEnumerable<string> GetServicedApplications()
		{
			return new[]
			{
				VersionedHostApplications.Rhino7,
			};
		}

		/// <summary>
		///   Current way of attaching default object kit to this converter
		/// </summary>
		/// <param name="doc"></param>
		public override void SetContextDocument(object doc)
		{
			Doc = (RhinoDoc)doc;

			// Note: grabs the standard object kit and loads it. This will fail if the default speckle kit is not installed on the machine
			defaultConverter = KitManager.GetDefaultKit().LoadConverter(
				RhinoApp.Version.Major == 6 ? VersionedHostApplications.Rhino6 : VersionedHostApplications.Rhino7);

			defaultConverter?.SetContextDocument(Doc);
		}
	}
}