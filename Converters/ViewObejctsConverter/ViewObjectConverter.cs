using System;
using System.Collections.Generic;
using System.Linq;
using Speckle.Core.Kits;
using Speckle.Core.Models;
using ViewObjects.Speckle;

namespace ViewObjects.Converter.Script
{

	public partial class ViewObjectConverter : ISpeckleConverter
	{

		public Action<List<object>> OnViewContentConverted;
		public ViewObjectSchema Schema;
		public ISpeckleConverter supportConverter;
		
		public ViewObjectConverter()
		{ }

		public ViewObjectConverter(ViewObjectSchema schema, ISpeckleConverter converter)
		{
			Schema = schema;
			supportConverter = converter;
		}
		
		public virtual List<ApplicationPlaceholderObject> ContextObjects { get; set; } = new List<ApplicationPlaceholderObject>();

		public virtual HashSet<Exception> ConversionErrors { get; }

		public virtual string Description
		{
			get => "Converter for basic view objects";
		}

		public virtual string Name
		{
			get => nameof(ViewObjectConverter);
		}

		public virtual string Author
		{
			get => "David Morgan";
		}

		public virtual string WebsiteOrEmail
		{
			get => "https://sasaki.com";
		}

		public ProgressReport Report { get; }

		public ReceiveMode ReceiveMode { get; set; }

		public virtual void SetContextDocument(object doc)
		{ }

		public virtual IEnumerable<string> GetServicedApplications()
		{
			return new[]
			{
				VersionedHostApplications.Script
			};
		}

		public virtual void SetContextObjects(List<ApplicationPlaceholderObject> objects)
		{
			ContextObjects = objects;
		}

		public virtual void SetPreviousContextObjects(List<ApplicationPlaceholderObject> objects)
		{
			throw new NotImplementedException();
		}

		public void SetConverterSettings(object settings)
		{
			throw new NotImplementedException();
		}

		public virtual List<object> ConvertToNative(List<Base> objects) => objects.Select(ConvertToNative).ToList();

		public virtual object ConvertToNative(Base @base) => ConvertToViewObj(@base);

		public virtual Base ConvertToSpeckle(object @object) => ConvertToViewObjBase(@object);

		public List<Base> ConvertToSpeckle(List<object> objects) => objects.Select(ConvertToSpeckle).ToList();

		public bool CanConvertToSpeckle(object @object)
		{
			switch (@object)
			{
				case IViewStudy _:
					return true;
				case IViewCloud _:
					return true;
				case IViewContent _:
					return true;
				case IViewContentBundle _:
					return true;
				case IViewerBundle _:
					return true;
				case IViewerLayout _:
					return true;
				default:
					return false;
			}
		}

		public bool CanConvertToNative(Base @base)
		{
			switch (@base)
			{
				case ViewStudyBase _:
					return true;
				case ViewCloudBase _:
					return true;
				case ContentBundleBase _:
					return true;
				case ViewerBundleBase _:
					return true;
				case ViewerLayoutBase _:
					return true;
				default:
					return false;
			}
		}

		public virtual IViewObj ConvertToViewObj(Base @base)
		{
			switch (@base)
			{
				case ViewStudyBase o:
					return StudyToNative(o);
				case ResultCloudBase o:
					return ResultCloudToNative(o);
				case ViewCloudBase o:
					return ViewCloudToNative(o);
				case ContentBundleBase o:
					return ContentBundleToNative(o);
				case ViewContentBase o:
					return ViewContentToNative(o);
				case ViewerBundleBase o:
					return ViewerBundleToNative(o);
				case ViewerLayoutBase o:
					return LayoutToNative(o);
				case Base o:
					return CheckIfWrapper(o);
				default:
					throw new ArgumentOutOfRangeException(nameof(@base), @base, null);
			}
		}

		public ViewObjBase ConvertToViewObjBase(object @object)
		{
			switch (@object)
			{
				case IViewStudy o:
					return StudyToSpeckle(o);
				case IResultCloud o:
					return ResultCloudToSpeckle(o);
				case IViewCloud o:
					return ViewCloudToSpeckle(o);
				case IViewContentBundle o:
					return ContentBundleToSpeckle(o);
				case IViewContent o:
					return ViewContentToSpeckle(o);
				case IViewerBundle o:
					return ViewerBundleToSpeckle(o);
				case IViewerLayout o:
					return LayoutToSpeckle(o);
				default:
					throw new ArgumentOutOfRangeException(nameof(@object), @object, null);
			}
		}
	}
}