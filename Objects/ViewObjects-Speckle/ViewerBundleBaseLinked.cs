using System.Collections.Generic;
using Speckle.Core.Models;
using Speckle.Newtonsoft.Json;
using ViewObjects;
using ViewTo.ViewObjects.Structure;

namespace ViewTo.Speckle
{
  public class ViewerBundleBaseLinked : ViewerBundleBase
  {

    public ViewerBundleBaseLinked()
    { }
    [JsonIgnore]
    public override bool isValid => base.isValid && linkedClouds.Valid();

    [DetachProperty]
    public List<ViewCloudBase> linkedClouds { get; set; }

    /// <summary>
    ///   temporary list for storing view cloud info to find
    /// </summary>
    public List<string> cloudsToFind { get; set; }
  }
}
