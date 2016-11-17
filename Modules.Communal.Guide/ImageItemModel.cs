// Decompiled with JetBrains decompiler
// Type: Modules.Communal.Guide.ImageItemModel
// Assembly: Modules.Communal.Guide, Version=1.0.5464.34347, Culture=neutral, PublicKeyToken=null
// MVID: 170B36F5-747C-4B3C-9529-30988307B6DF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.Guide.dll

using CocoStudio.Model.ViewModel;
using System;
using System.Collections.Generic;

namespace Modules.Communal.Guide
{
  public class ImageItemModel : NotificationObject
  {
    public class Editor
    {
      public string MinEditorVersion { get; set; }

      public DateTime UpdateTime { get; set; }

      public ImageItemModel.EnglishVersion English { get; set; }

      public ImageItemModel.ChineseVersion Chinese { get; set; }
    }

    public class EnglishVersion
    {
      public List<ImageItemModel.Item> part { get; set; }
    }

    public class ChineseVersion
    {
      public List<ImageItemModel.Item> part { get; set; }
    }

    public class Item
    {
      public string isDisplayWebSite { get; set; }

      public string Text { get; set; }

      public string Image { get; set; }
    }
  }
}
