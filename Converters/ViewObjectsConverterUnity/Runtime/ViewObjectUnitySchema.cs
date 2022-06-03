using UnityEngine;
using ViewObjects.Converter.Script;
using ViewObjects.Unity;

namespace ViewObjects.Converter.Unity
{
	public class ViewObjectUnitySchema : ViewObjectSchema
	{
		public override IViewStudy nativeViewStudy
		{
			get => Create<ViewStudyMono>();
		}

		public override IViewCloud nativeViewCloud
		{
			get => Create<ViewCloudMono>();
		}

		public override IResultCloud nativeResultCloud
		{
			get => Create<ResultCloudMono>();
		}

		public override IViewerLayout nativeViewerLayout
		{
			get => Create<ViewerLayoutMono>();
		}

		public override IViewerBundle nativeViewerBundle
		{
			get => Create<ViewerBundleMono>();
		}

		public override IViewerBundleLinked nativeViewerBundleLinked
		{
			get => Create<ViewerBundleLinkedMono>();
		}

		public override IViewContentBundle nativeContentBundle
		{
			get => Create<ContentBundleMono>();
		}

		public override ITargetContent nativeTargetContent
		{
			get => Create<ContentTargetMono>();
		}

		public override IBlockerContent nativeBlockerContent
		{
			get => Create<ContentBlockerMono>();
		}

		public override IDesignContent nativeDesignContent
		{
			get => Create<ContentDesignMono>();
		}

		TObj Create<TObj>() where TObj : MonoBehaviour
		{
			var obj = new GameObject().AddComponent<TObj>();
			obj.name = obj.TypeName();
			return obj;
		}
	}
}