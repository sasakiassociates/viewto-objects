﻿using System.Collections.Generic;
using System.Linq;
using Sasaki.Objects;
using ViewObjects;

namespace ViewTo.ViewObjects
{

	public class Rig : IRig, IValidate
	{
		public List<IRigParam> globalParams { get; set; }

		public List<ViewColor> globalColors { get; set; }
		public Dictionary<string, CloudPoint[]> clouds { get; set; }

		public bool isValid
		{
			get => globalParams.Valid() && globalColors.Valid() && clouds != null && clouds.Any();
		}
	}
}