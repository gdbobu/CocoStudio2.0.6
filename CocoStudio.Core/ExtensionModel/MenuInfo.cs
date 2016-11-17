// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.ExtensionModel.MenuInfo
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using MonoDevelop.Components.Commands;
using MonoDevelop.Core;

namespace CocoStudio.Core.ExtensionModel
{
  public class MenuInfo
  {
    internal CommandInfo cmdInfo { get; private set; }

    public Command Command
    {
      get
      {
        return this.cmdInfo.Command;
      }
    }

    public string Text
    {
      get
      {
        return this.cmdInfo.Text;
      }
      set
      {
        this.cmdInfo.Text = value;
      }
    }

    public IconId Icon
    {
      get
      {
        return this.cmdInfo.Icon;
      }
      set
      {
        this.cmdInfo.Icon = value;
      }
    }

    public string AccelKey
    {
      get
      {
        return this.cmdInfo.AccelKey;
      }
      set
      {
        this.cmdInfo.AccelKey = value;
      }
    }

    public string Description
    {
      get
      {
        return this.cmdInfo.Description;
      }
      set
      {
        this.cmdInfo.Description = value;
      }
    }

    public bool Enabled
    {
      get
      {
        return this.cmdInfo.Enabled;
      }
      set
      {
        this.cmdInfo.Enabled = value;
      }
    }

    public bool Visible
    {
      get
      {
        return this.cmdInfo.Visible;
      }
      set
      {
        this.cmdInfo.Visible = value;
      }
    }

    public bool Checked
    {
      get
      {
        return this.cmdInfo.Checked;
      }
      set
      {
        this.cmdInfo.Checked = value;
      }
    }

    public bool CheckedInconsistent
    {
      get
      {
        return this.cmdInfo.CheckedInconsistent;
      }
      set
      {
        this.cmdInfo.CheckedInconsistent = value;
      }
    }

    public bool UseMarkup
    {
      get
      {
        return this.cmdInfo.UseMarkup;
      }
      set
      {
        this.cmdInfo.UseMarkup = value;
      }
    }

    public bool Bypass
    {
      get
      {
        return this.cmdInfo.Bypass;
      }
      set
      {
        this.cmdInfo.Bypass = value;
      }
    }

    public CommandArrayInfo ArrayInfo
    {
      get
      {
        return this.cmdInfo.ArrayInfo;
      }
      internal set
      {
        this.cmdInfo.ArrayInfo = value;
      }
    }

    public object DataItem
    {
      get
      {
        return this.cmdInfo.DataItem;
      }
      internal set
      {
        this.cmdInfo.DataItem = value;
      }
    }

    public bool IsArraySeparator
    {
      get
      {
        return this.cmdInfo.IsArraySeparator;
      }
      internal set
      {
        this.cmdInfo.IsArraySeparator = value;
      }
    }

    internal MenuInfo(CommandInfo info)
    {
      this.cmdInfo = info;
    }

    internal MenuInfo(Command cmd)
    {
      this.cmdInfo = new CommandInfo(cmd);
    }

    public MenuInfo()
    {
      this.cmdInfo = new CommandInfo();
    }

    public MenuInfo(string text)
    {
      this.cmdInfo = new CommandInfo(text);
    }

    public MenuInfo(string text, bool enabled, bool checkd)
    {
      this.cmdInfo = new CommandInfo(text, enabled, checkd);
    }

    public bool HandlesItem(object item)
    {
      return this.cmdInfo.HandlesItem(item);
    }
  }
}
