using System.Collections.Generic;
using Sasaki.Objects;
using Speckle.Core.Models;
using Speckle.Newtonsoft.Json;
using ViewTo.ViewObjects.Structure;

namespace ViewTo.Speckle
{

  public abstract class ViewContentBase : ViewObjBase, IValidate, INameable
  {

    public ViewContentBase()
    { }
    
    [DetachProperty]
    public List<Base> objects { get; set; }

    [JsonIgnore]
    public virtual bool isValid => objects != null;

    public string viewName { get; set; }
  }
}
