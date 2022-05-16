﻿using System;
using System.Collections.Generic;
using ViewObjects;
using ViewTo.ViewObjects.Structure;

namespace ViewTo.ViewObjects
{
	[Serializable]
	public class ViewerBundle : IViewerBundle
	{

		public virtual bool isValid
		{
			get => layouts.Valid();
		}
		public List<IViewerLayout> layouts { get; set; }
	}

	public class ViewerBundleLinked : IViewerBundleLinked
	{
		public List<CloudShell> linkedClouds { get; set; }
		public List<IViewerLayout> layouts { get; set; }
	}
}