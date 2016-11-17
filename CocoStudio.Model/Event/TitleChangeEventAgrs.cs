// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Event.TitleChangeEventAgrs
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

namespace CocoStudio.Model.Event
{
  public class TitleChangeEventAgrs
  {
    public string WindowTitle { get; set; }

    public object Progect { get; set; }

    public static TitleChangeEventAgrs Creat(string windowTitle, object progect = null)
    {
      return new TitleChangeEventAgrs()
      {
        WindowTitle = windowTitle,
        Progect = progect
      };
    }
  }
}
