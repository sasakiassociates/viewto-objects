using System.Collections.Generic;
using Sasaki.Objects;
using Speckle.Core.Models;
using ViewObjects;
using ViewTo.ViewObjects.Structure;

namespace ViewTo.Speckle
{

  public class ContentBundleBase : ViewObjBase, IValidate
  {

    public ContentBundleBase()
    { }

    [DetachProperty]
    public List<TargetContentBase> targets { get; set; }

    [DetachProperty]
    public List<BlockerContentBase> blockers { get; set; }

    [DetachProperty]
    public List<DesignContentBase> designs { get; set; }

    public bool isValid => targets.Valid() && blockers.Valid();
  }
}
