﻿// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Editor.IListSelectEditor
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using System.Collections.Generic;

namespace CocoStudio.Model.Editor
{
  public interface IListSelectEditor
  {
    List<object> GetItems(string propertyName);

    string GetDisplayBindingPath(string propertyName);
  }
}
