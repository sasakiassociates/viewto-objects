using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Speckle.Core.Kits;

namespace ViewTo.Speckle
{
  public class ViewToKit : ISpeckleKit
  {

    private Dictionary<string, Type> _LoadedConverters = new Dictionary<string, Type>();

    public static ViewToKit LoadKit => KitManager.GetKit(AssemblyFullName) as ViewToKit;

    public static string AssemblyFullName => AssemblyName.FullName;

    public string ConverterBaseName => "ViewObjects.Converter";

    public static AssemblyName AssemblyName => typeof(ViewObjBase).GetTypeInfo().Assembly.GetName();

    public string Description => "View To kit for converting";

    public string Name => nameof(ViewToKit);

    public string Author => "David Morgan";

    public string WebsiteOrEmail => "https://sasaki.com";

    public IEnumerable<Type> Types => Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsSubclassOf(typeof(ViewObjBase)) && !t.IsAbstract);

    public ISpeckleConverter LoadConverter(string app)
    {
      converters = GetAvailableConverters();

      if (_LoadedConverters.ContainsKey(app) && _LoadedConverters[app] != null) return Activator.CreateInstance(_LoadedConverters[app]) as ISpeckleConverter;

      try
      {
        var path = Path.Combine(KitLocation, ConverterBaseName + "." + $"{app}.dll");
        if (File.Exists(path))
        {
          var assembly = Assembly.LoadFrom(path);

          var converterClass = assembly.GetTypes().FirstOrDefault(type =>
                                                                    type.GetInterfaces().FirstOrDefault(i => i.Name == typeof(ISpeckleConverter).Name) != null
                                                                    && (Activator.CreateInstance(type) as ISpeckleConverter).GetServicedApplications()
                                                                    .Contains(app)
          );

          _LoadedConverters[app] = converterClass;
          return Activator.CreateInstance(converterClass) as ISpeckleConverter;
        }
        return null;
      }
      catch (Exception e)
      {
        return null;
      }
    }

    private List<string> converters;

    public IEnumerable<string> Converters => converters ??= GetAvailableConverters();

    public string KitLocation => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Speckle\\Kits\\ViewTo");

    public List<string> GetAvailableConverters()
    {
      var list = Directory.EnumerateFiles(KitLocation, ConverterBaseName + ".*");
      return list.ToList().Select(dllPath => dllPath.Split('.').Reverse().ToList()[1]).ToList();
    }
  }
}
