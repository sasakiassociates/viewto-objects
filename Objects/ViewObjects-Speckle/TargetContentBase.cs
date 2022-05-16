using System.Collections.Generic;
using Speckle.Core.Models;
using Speckle.Newtonsoft.Json;
using ViewObjects;
using ViewTo.ViewObjects.Structure;

namespace ViewTo.Speckle
{

  public class TargetContentBase : ViewContentBase
  {

    public TargetContentBase()
    { }
    
    public bool isolate { set; get; }
    
    public ViewColor viewColor { get; set; }

    [DetachProperty]
    public List<ViewerBundleBase> bundles { get; set; }

    [JsonIgnore]
    public override bool isValid => base.isValid && viewName.Valid();
  }
}
