using System;
using Sasaki.Objects;

namespace ViewTo.ViewObjects.Structure
{

	[Serializable]
	public readonly struct CloudShell : IMetaShell
	{
		public CloudShell(Type objType, string objId, int count)
		{
			this.count = count;
			this.objId = objId;
			this.objType = objType;
		}

		public CloudShell(object objType, string objId, int count)
		{
			this.count = count;
			this.objId = objId;
			this.objType = objType?.GetType();
		}

		public Type objType { get; }
		public string objId { get; }
		public int count { get; }
	}

}