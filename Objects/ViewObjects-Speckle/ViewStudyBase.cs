﻿using System.Collections.Generic;

namespace ViewTo.Speckle
{

  public class ViewStudyBase : ViewObjBase
  {

    public ViewStudyBase()
    { }
    public string viewName { get; set; }

    public List<ViewObjBase> objs { get; set; }
  }
}