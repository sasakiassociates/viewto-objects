using Speckle.Newtonsoft.Json;
using ViewObjects;
using ViewTo.ViewObjects.Structure;

namespace ViewTo.Speckle
{
  public class DesignContentBase : ViewContentBase
  {

    public DesignContentBase()
    { }
    [JsonIgnore]
    public override bool isValid => base.isValid && viewName.Valid();
  }
}
