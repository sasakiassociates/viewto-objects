using System.Collections.Generic;
using Objects.Geometry;
using Speckle.Newtonsoft.Json;
using ViewObjects;
using ViewTo.ViewObjects.Structure;

namespace ViewTo.Speckle
{

  public class ViewerLayoutBase : ViewObjBase, IViewerLayout
  {

    public ViewerLayoutBase()
    { }
    [JsonIgnore]
    public virtual List<IViewer> viewers =>
      new List<IViewer>
      {
        new Viewer(ViewerDirection.Front)
      };
  }

  public class ViewerLayoutBaseFocus : ViewerLayoutBase
  {

    public ViewerLayoutBaseFocus()
    { }
    public Point focusPoint { get; set; }
  }

  public class ViewerLayoutBaseNormal : ViewerLayoutBase
  {

    public string shellId;

    public ViewerLayoutBaseNormal()
    { }
  }

  public class ViewerLayoutBaseOrtho : ViewerLayoutBase
  {

    public double size;

    public ViewerLayoutBaseOrtho()
    { }
  }

  public class ViewerLayoutBaseCube : ViewerLayoutBase
  {

    public ViewerLayoutBaseCube()
    { }
    [JsonIgnore]
    public override List<IViewer> viewers =>
      new List<IViewer>
      {
        new Viewer(ViewerDirection.Front),
        new Viewer(ViewerDirection.Right),
        new Viewer(ViewerDirection.Back),
        new Viewer(ViewerDirection.Left),
        new Viewer(ViewerDirection.Up),
        new Viewer(ViewerDirection.Down)
      };
  }

  public class ViewerLayoutBaseHorizontal : ViewerLayoutBase
  {

    public ViewerLayoutBaseHorizontal()
    { }
    [JsonIgnore]
    public override List<IViewer> viewers =>
      new List<IViewer>
      {
        new Viewer(ViewerDirection.Front), new Viewer(ViewerDirection.Right), new Viewer(ViewerDirection.Back), new Viewer(ViewerDirection.Left)
      };
  }
}
