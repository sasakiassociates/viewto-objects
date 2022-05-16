using System.Collections.Generic;
using Speckle.Newtonsoft.Json;
using ViewObjects;
using ViewTo.ViewObjects.Structure;

namespace ViewTo.Speckle
{

  public class ResultCloudBase : ViewCloudBase
  {

    public ResultCloudBase()
    { }

    [JsonIgnore]
    public override bool isValid => base.isValid && data.Valid();

    public List<IResultData> data { get; set; }
  }
}
