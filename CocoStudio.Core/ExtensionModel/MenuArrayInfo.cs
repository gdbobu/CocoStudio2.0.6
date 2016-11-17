// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.ExtensionModel.MenuArrayInfo
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using MonoDevelop.Components.Commands;
using System.Collections;

namespace CocoStudio.Core.ExtensionModel
{
  public class MenuArrayInfo : IEnumerable
  {
    private CommandArrayInfo cmdArrayInfo;

    public MenuInfo this[int n]
    {
      get
      {
        return new MenuInfo(this.cmdArrayInfo[n]);
      }
    }

    public int Count
    {
      get
      {
        return this.cmdArrayInfo.Count;
      }
    }

    public MenuInfo DefaultCommandInfo
    {
      get
      {
        return new MenuInfo(this.cmdArrayInfo.DefaultCommandInfo);
      }
    }

    public bool Bypass
    {
      get
      {
        return this.cmdArrayInfo.Bypass;
      }
      set
      {
        this.cmdArrayInfo.Bypass = value;
      }
    }

    internal MenuArrayInfo(CommandArrayInfo info)
    {
      this.cmdArrayInfo = info;
    }

    internal MenuArrayInfo(CommandInfo cmdInfo)
    {
      this.cmdArrayInfo = new CommandArrayInfo(cmdInfo);
    }

    public void Clear()
    {
      this.cmdArrayInfo.Clear();
    }

    public MenuInfo FindCommandInfo(object dataItem)
    {
      return new MenuInfo(this.cmdArrayInfo.FindCommandInfo(dataItem));
    }

    public void Insert(int index, MenuInfo info, object dataItem)
    {
      this.cmdArrayInfo.Insert(index, info.cmdInfo, dataItem);
    }

    public void Add(MenuInfo info, object dataItem)
    {
      this.cmdArrayInfo.Add(info.cmdInfo, dataItem);
    }

    public void AddSeparator()
    {
      this.cmdArrayInfo.AddSeparator();
    }

    public IEnumerator GetEnumerator()
    {
      return this.cmdArrayInfo.GetEnumerator();
    }
  }
}
