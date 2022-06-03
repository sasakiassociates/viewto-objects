using Speckle.ConnectorUnity.Converter;
using Speckle.Core.Models;
using UnityEngine;
using ViewObjects.Converter.Script;
using ViewObjects.Unity;

namespace ViewObjects.Converter.Unity
{
	[CreateAssetMenu(menuName = "ViewTo/Create Converter", fileName = "ViewObjUnityConverter", order = 0)]
	public class ViewObjectsConverterUnity : ScriptableSpeckleConverter
	{

		ViewObjectConverter wrappedConverter { get; set; }

		void OnEnable()
		{
			wrappedConverter = new ViewObjectConverter
			{
				supportConverter = CreateInstance<ConverterUnity>(),
				Schema = new ViewObjectUnitySchema()
			};
		}

		public override bool CanConvertToNative(Base @base) => wrappedConverter.CanConvertToNative(@base);

		public override Base ConvertToSpeckle(object @object)
		{
			if (@object is GameObject go)
			{
				var res = go.GetComponent(typeof(ViewObjMono));
				return wrappedConverter.ConvertToSpeckle(res);
			}

			return wrappedConverter.ConvertToSpeckle(@object);
		}

		public override bool CanConvertToSpeckle(object @object)
		{
			if (@object is GameObject go)
			{
				var res = go.GetComponents(typeof(ViewObjMono));

				foreach (var comp in res)
					if (wrappedConverter.CanConvertToSpeckle(comp))
						return true;
			}

			// try to convert anyways 
			return wrappedConverter.CanConvertToSpeckle(@object);
		}

		public override object ConvertToNative(Base @base)
		{
			if (@base == null)
			{
				Debug.LogWarning("Trying to convert a null object! Beep Beep! I don't like that");
				return null;
			}

			if (wrappedConverter.CanConvertToNative(@base))
			{
				var vo = wrappedConverter.ConvertToNative(@base);
				return vo;
			}

			Debug.Log($"Converting with native kit for {@base.speckle_type}");
			return null;
		}
	}
}