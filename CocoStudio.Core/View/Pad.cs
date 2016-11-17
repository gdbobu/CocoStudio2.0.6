// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.View.Pad
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using MonoDevelop.Core;
using MonoDevelop.Ide.Codons;
using MonoDevelop.Ide.Gui;
using System;
using System.Collections.Generic;

namespace CocoStudio.Core.View
{
  public class Pad
  {
    private IPadWindow window;
    private PadCodon content;
    private MainWindow mainWindow;
    private string[] categories;

    internal PadCodon InternalContent
    {
      get
      {
        return this.content;
      }
    }

    public object Content
    {
      get
      {
        return (object) this.content;
      }
    }

    public string Title
    {
      get
      {
        return this.window.Title;
      }
    }

    public IconId Icon
    {
      get
      {
        return this.window.Icon;
      }
    }

    public string Id
    {
      get
      {
        return this.window.Id;
      }
    }

    public bool IsOpenedAutomatically { get; set; }

    public string[] Categories
    {
      get
      {
        if (this.categories == null)
        {
          CategoryNode parent = this.content.Parent as CategoryNode;
          if (parent == null)
          {
            this.categories = new string[1]
            {
              GettextCatalog.GetString("Pads")
            };
          }
          else
          {
            List<string> stringList = new List<string>();
            for (; parent != null; parent = parent.Parent as CategoryNode)
              stringList.Insert(0, parent.Name);
            this.categories = stringList.ToArray();
          }
        }
        return this.categories;
      }
    }

    public bool AutoHide
    {
      get
      {
        return this.window.AutoHide;
      }
      set
      {
        this.window.AutoHide = value;
      }
    }

    public bool Visible
    {
      get
      {
        return this.window.Visible;
      }
      set
      {
        this.window.Visible = value;
      }
    }

    public bool Sticky
    {
      get
      {
        return this.window.Sticky;
      }
      set
      {
        this.window.Sticky = value;
      }
    }

    internal IPadWindow Window
    {
      get
      {
        return this.window;
      }
    }

    internal Pad(MainWindow mainWindow, PadCodon content)
    {
      this.window = mainWindow.GetPadWindow(content);
      this.window.PadHidden += (EventHandler) ((param0, param1) => this.IsOpenedAutomatically = false);
      this.content = content;
      this.mainWindow = mainWindow;
    }

    public void BringToFront()
    {
      this.BringToFront(false);
    }

    public void BringToFront(bool grabFocus)
    {
      this.mainWindow.BringToFront(this.content);
      this.window.Activate(grabFocus);
    }

    internal IMementoCapable GetMementoCapable()
    {
      throw new NotImplementedException();
    }

    public void Destroy()
    {
      this.Visible = false;
      this.mainWindow.RemovePad(this.content);
    }
  }
}
