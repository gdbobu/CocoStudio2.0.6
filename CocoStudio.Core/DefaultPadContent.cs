// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.DefaultPadContent
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using Gtk;
using MonoDevelop.Ide.Gui;

namespace CocoStudio.Core
{
  public class DefaultPadContent : AbstractPadContent
  {
    protected Alignment containerBox;

    public override Widget Control
    {
      get
      {
        return (Widget) this.containerBox;
      }
    }

    protected DefaultPadContent()
    {
      this.containerBox = new Alignment(0.0f, 0.0f, 1f, 1f);
      this.containerBox.BorderWidth = 0U;
    }

    public DefaultPadContent(Widget content)
      : this()
    {
      this.containerBox.Add(content);
      this.containerBox.ShowAll();
    }

    public override void Initialize(IPadWindow window)
    {
      base.Initialize(window);
    }

    public override void RedrawContent()
    {
    }

    public override void Dispose()
    {
      this.containerBox = (Alignment) null;
    }
  }
}
