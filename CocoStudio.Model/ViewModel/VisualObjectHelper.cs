// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.VisualObjectHelper
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CocoStudio.Model.ViewModel
{
  internal static class VisualObjectHelper
  {
    public static VisualObject GetChild(VisualObject rootObject, Expression<Func<VisualObject, bool>> filter)
    {
      if (rootObject == null)
        return (VisualObject) null;
      if (filter.Compile()(rootObject))
        return rootObject;
      IEnumerable<VisualObject> visualChildren = rootObject.GetVisualChildren();
      if (visualChildren == null)
        return (VisualObject) null;
      foreach (VisualObject rootObject1 in visualChildren)
      {
        VisualObject child = VisualObjectHelper.GetChild(rootObject1, filter);
        if (child != null)
          return child;
      }
      return (VisualObject) null;
    }
  }
}
