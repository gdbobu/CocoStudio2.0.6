// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.AstrictLengthEditorWidget
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using Gtk;
using System;

namespace CocoStudio.ToolKit
{
  public class AstrictLengthEditorWidget : BaseEditorWidget
  {
    private Table table2;
    private CheckButton checkBox_MaxLength;
    private UndoEntryIntEx numLength;

    public event EventHandler<BoolEvent> IsCheckChanged;

    public event EventHandler<BoolEvent> ValueCangede;

    public AstrictLengthEditorWidget()
    {
      this.table2 = new Table(1U, 2U, false);
      this.table2.Name = "table2";
      this.table2.ColumnSpacing = 6U;
      this.checkBox_MaxLength = new CheckButton();
      this.checkBox_MaxLength.CanFocus = true;
      this.checkBox_MaxLength.Name = "checkBox_MaxLength";
      this.checkBox_MaxLength.Active = true;
      this.checkBox_MaxLength.DrawIndicator = true;
      this.checkBox_MaxLength.UseUnderline = true;
      this.table2.Add((Widget) this.checkBox_MaxLength);
      Table.TableChild tableChild1 = (Table.TableChild) this.table2[(Widget) this.checkBox_MaxLength];
      tableChild1.XOptions = AttachOptions.Fill;
      tableChild1.YOptions = AttachOptions.Fill;
      this.numLength = new UndoEntryIntEx();
      this.numLength.WidthRequest = 10;
      this.numLength.CanFocus = true;
      this.numLength.Name = "spinbutton1";
      this.numLength.IsInteger = true;
      this.table2.Add((Widget) this.numLength);
      Table.TableChild tableChild2 = (Table.TableChild) this.table2[(Widget) this.numLength];
      tableChild2.TopAttach = 0U;
      tableChild2.BottomAttach = 1U;
      tableChild2.LeftAttach = 1U;
      tableChild2.RightAttach = 2U;
      tableChild2.YOptions = AttachOptions.Fill;
      this.Add((Widget) this.table2);
      if (this.Child != null)
        this.Child.ShowAll();
      this.Hide();
      this.ReadLanuageConfigFile();
      this.numLength.MinValue = 1;
      this.BeforeValueChanged += new System.Action(this.BeforEvent);
      this.AfterValueChanged += new System.Action(this.AfterEvent);
      this.AfterEvent();
    }

    public void BeforEvent()
    {
      this.checkBox_MaxLength.Clicked -= new EventHandler(this.checkBox_MaxLength_Clicked);
      this.numLength.EntryValueChanged -= new EventHandler<EntryIntEventArgs>(this.numLength_ValueChanged);
    }

    public void AfterEvent()
    {
      this.checkBox_MaxLength.Clicked += new EventHandler(this.checkBox_MaxLength_Clicked);
      this.numLength.EntryValueChanged += new EventHandler<EntryIntEventArgs>(this.numLength_ValueChanged);
    }

    public void SetControl(bool status, double num)
    {
      this.checkBox_MaxLength.Active = status;
      this.numLength.Sensitive = status;
      this.numLength.Value = num;
    }

    private void numLength_ValueChanged(object sender, EventArgs e)
    {
      this.numLength.Sensitive = this.checkBox_MaxLength.Active;
      if (this.ValueCangede == null)
        return;
      this.RaiseValueChanged((object) null, (System.Action) (() => this.ValueCangede((object) null, new BoolEvent(false, "", this.numLength.Value))));
    }

    private void checkBox_MaxLength_Clicked(object sender, EventArgs e)
    {
      this.numLength.Sensitive = this.checkBox_MaxLength.Active;
      if (this.IsCheckChanged == null)
        return;
      this.RaiseValueChanged((object) null, (System.Action) (() => this.IsCheckChanged((object) null, new BoolEvent(this.checkBox_MaxLength.Active, "", 0.0))));
    }

    public override void ReadLanuageConfigFile()
    {
    }
  }
}
