// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Editor.PlayControlWidget
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using Gtk;
using Modules.Communal.MultiLanguage;
using System;

namespace CocoStudio.Model.Editor
{
  public class PlayControlWidget : EventBox
  {
    private Table ContentTable;

    public Button PlayButton { get; private set; }

    public Button StopButton { get; private set; }

    public event EventHandler Play;

    public event EventHandler Stop;

    public PlayControlWidget()
    {
      this.ContentTable = new Table(1U, 2U, false);
      this.PlayButton = new Button();
      this.PlayButton.WidthRequest = 40;
      this.PlayButton.HeightRequest = 25;
      this.PlayButton.Label = LanguageInfo.Command_Play;
      this.ContentTable.ColumnSpacing = 6U;
      this.StopButton = new Button();
      this.StopButton.WidthRequest = 40;
      this.StopButton.HeightRequest = 25;
      this.StopButton.Label = LanguageInfo.Command_Stop;
      this.ContentTable.Attach((Widget) this.PlayButton, 0U, 1U, 0U, 1U, AttachOptions.Fill, AttachOptions.Expand, 0U, 0U);
      this.ContentTable.Attach((Widget) this.StopButton, 1U, 2U, 0U, 1U, AttachOptions.Fill, AttachOptions.Expand, 0U, 0U);
      this.PlayButton.Show();
      this.StopButton.Show();
      this.Add((Widget) this.ContentTable);
      this.ContentTable.Show();
      this.PlayButton.Clicked += new EventHandler(this.play_Clicked);
      this.StopButton.Clicked += new EventHandler(this.stop_Clicked);
      this.ShowAll();
    }

    private void stop_Clicked(object sender, EventArgs e)
    {
      if (this.Stop == null)
        return;
      this.Stop((object) this, (EventArgs) null);
    }

    private void play_Clicked(object sender, EventArgs e)
    {
      if (this.Play == null)
        return;
      this.Play((object) this, (EventArgs) null);
    }
  }
}
