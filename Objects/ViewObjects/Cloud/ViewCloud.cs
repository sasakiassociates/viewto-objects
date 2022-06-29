using System;
using System.Linq;

namespace ViewObjects.Cloud
{
	public class ViewCloud : IViewCloud, IValidate
	{

		public ViewCloud() => viewID = Guid.NewGuid().ToString();

		public virtual bool isValid
		{
			get => viewPoints != null && viewPoints.Any();
		}

		public CloudPoint[] viewPoints { get; set; }
		/// <summary>
		///   Temporary get function that returns a GUID that is set when object is created
		/// </summary>
		public string viewID { get; set; }

		public int count
		{
			get => viewPoints.Valid() ? viewPoints.Length : 0;
		}
	}
}