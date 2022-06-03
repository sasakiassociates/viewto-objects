using System.Collections.Generic;
using System.Linq;

namespace ViewObjects.Cloud
{
	public class ResultCloud : ViewCloud, IResultCloud
	{
		public override bool isValid
		{
			get => base.isValid && data != null && data.Any();
		}
		
		public List<IResultData> data { get; set; }
	}
}