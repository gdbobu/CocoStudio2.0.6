// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.EntryComBoxEditorWidget
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using Gtk;
using Mono.Unix;
using System;
using System.ComponentModel;

namespace CocoStudio.ToolKit
{
  [ToolboxItem(true)]
  public class EntryComBoxEditorWidget : BaseEditorWidget
  {
    private bool isKeyPress = false;
    private int maxValue = 1000;
    private int minValue = 0;
    private int[] comboxList = new int[8]{ 32, 64, 128, 256, 512, 1024, 2048, 4096 };
    private int entry1 = 1;
    private int entry2 = 1;
    private Table table1;
    private ComboBoxEntry comboboxentry1;
    private ComboBoxEntry comboboxentry2;
    private Label labelOne;
    private Label labelTwo;

    public event EventHandler<EntryComboxEvent> ValueChanged;

    public EntryComBoxEditorWidget()
    {
      this.table1 = new Table(1U, 4U, false);
      this.table1.Name = "table1";
      this.table1.RowSpacing = 6U;
      this.table1.ColumnSpacing = 6U;
      this.comboboxentry1 = ComboBoxEntry.NewText();
      this.comboboxentry1.WidthRequest = 40;
      this.comboboxentry1.Name = "comboboxentry1";
      this.table1.Add((Widget) this.comboboxentry1);
      Table.TableChild tableChild1 = (Table.TableChild) this.table1[(Widget) this.comboboxentry1];
      tableChild1.LeftAttach = 1U;
      tableChild1.RightAttach = 2U;
      tableChild1.YOptions = AttachOptions.Fill;
      this.comboboxentry2 = ComboBoxEntry.NewText();
      this.comboboxentry2.WidthRequest = 40;
      this.comboboxentry2.Name = "comboboxentry2";
      this.table1.Add((Widget) this.comboboxentry2);
      Table.TableChild tableChild2 = (Table.TableChild) this.table1[(Widget) this.comboboxentry2];
      tableChild2.LeftAttach = 3U;
      tableChild2.RightAttach = 4U;
      tableChild2.YOptions = AttachOptions.Fill;
      this.labelOne = new Label();
      this.labelOne.Name = "labelOne";
      this.labelOne.Xalign = 1f;
      this.labelOne.LabelProp = Catalog.GetString("label1");
      this.table1.Add((Widget) this.labelOne);
      Table.TableChild tableChild3 = (Table.TableChild) this.table1[(Widget) this.labelOne];
      tableChild3.XOptions = AttachOptions.Fill;
      tableChild3.YOptions = AttachOptions.Fill;
      this.labelTwo = new Label();
      this.labelTwo.Name = "labelTwo";
      this.labelTwo.Xalign = 1f;
      this.labelTwo.LabelProp = Catalog.GetString("label2");
      this.table1.Add((Widget) this.labelTwo);
      Table.TableChild tableChild4 = (Table.TableChild) this.table1[(Widget) this.labelTwo];
      tableChild4.LeftAttach = 2U;
      tableChild4.RightAttach = 3U;
      tableChild4.XOptions = AttachOptions.Fill;
      tableChild4.YOptions = AttachOptions.Fill;
      this.Add((Widget) this.table1);
      if (this.Child != null)
        this.Child.ShowAll();
      this.Hide();
      this.ReadLanuageConfigFile();
      this.labelOne.Text = "W";
      this.labelTwo.Text = "H";
      ListStore listStore = new ListStore(new Type[1]{ typeof (string) });
      foreach (int combox in this.comboxList)
        listStore.AppendValues(new object[1]
        {
          (object) combox.ToString()
        });
      this.comboboxentry1.Model = (TreeModel) listStore;
      CellRendererText cellRendererText = new CellRendererText();
      this.comboboxentry1.PackStart((CellRenderer) cellRendererText, true);
      this.comboboxentry2.Model = (TreeModel) listStore;
      this.comboboxentry2.PackStart((CellRenderer) cellRendererText, true);
      this.comboboxentry1.Entry.MaxLength = 8;
      this.comboboxentry2.Entry.MaxLength = 8;
      this.comboboxentry2.HeightRequest = 25;
    }

    public void SetMaxMin(int max, int min)
    {
      this.maxValue = max;
      this.minValue = min;
    }

    public void Init()
    {
      this.comboboxentry1.Entry.KeyReleaseEvent += new KeyReleaseEventHandler(this.Entry_KeyReleaseEvent1);
      this.comboboxentry2.Entry.KeyReleaseEvent += new KeyReleaseEventHandler(this.Entry_KeyReleaseEvent2);
      this.comboboxentry1.Entry.FocusOutEvent += new FocusOutEventHandler(this.Entry_FocusOutEvent1);
      this.comboboxentry2.Entry.FocusOutEvent += new FocusOutEventHandler(this.Entry_FocusOutEvent2);
      this.comboboxentry1.Entry.Changed += new EventHandler(this.Entry_Changed1);
      this.comboboxentry2.Entry.Changed += new EventHandler(this.Entry_Changed2);
    }

    private void Entry_TextInserted(object o, TextInsertedArgs args)
    {
      if ((int) args.Text[0] > 57 || (int) args.Text[0] < 48)
        ;
    }

    private void Entry_Changed1(object sender, EventArgs e)
    {
      if (!this.comboboxentry1.Entry.IsFocus)
      {
        this.entry1 = Convert.ToInt32(this.comboboxentry1.Entry.Text);
        if (this.ValueChanged == null)
          return;
        this.RaiseValueChanged((object) null, (System.Action) (() => this.ValueChanged((object) null, new EntryComboxEvent(0, this.entry1))));
      }
      else
      {
        for (int startIndex = 0; startIndex < this.comboboxentry1.Entry.Text.Length; ++startIndex)
        {
          if ((int) this.comboboxentry1.Entry.Text[startIndex] < 48 || (int) this.comboboxentry1.Entry.Text[startIndex] > 57)
          {
            this.comboboxentry1.Entry.Text = this.comboboxentry1.Entry.Text.Remove(startIndex, 1);
            Adjustment cursorHadjustment = this.comboboxentry1.Entry.CursorHadjustment;
          }
        }
      }
    }

    private void Entry_Changed2(object sender, EventArgs e)
    {
      if (!this.comboboxentry2.Entry.IsFocus)
      {
        this.entry2 = Convert.ToInt32(this.comboboxentry2.Entry.Text);
        if (this.ValueChanged == null)
          return;
        this.RaiseValueChanged((object) null, (System.Action) (() => this.ValueChanged((object) null, new EntryComboxEvent(1, this.entry2))));
      }
      else
      {
        for (int startIndex = 0; startIndex < this.comboboxentry2.Entry.Text.Length; ++startIndex)
        {
          if ((int) this.comboboxentry2.Entry.Text[startIndex] < 48 || (int) this.comboboxentry2.Entry.Text[startIndex] > 57)
            this.comboboxentry2.Entry.Text = this.comboboxentry2.Entry.Text.Remove(startIndex, 1);
        }
      }
    }

    private void Entry_FocusOutEvent1(object o, FocusOutEventArgs args)
    {
      if (this.isKeyPress)
      {
        if (string.IsNullOrEmpty(this.comboboxentry1.Entry.Text))
        {
          this.comboboxentry1.Entry.Text = this.entry1.ToString();
          return;
        }
        if (Convert.ToInt32(this.comboboxentry1.Entry.Text) > this.maxValue)
          this.comboboxentry1.Entry.Text = this.maxValue.ToString();
        if (Convert.ToInt32(this.comboboxentry1.Entry.Text) < this.minValue)
          this.comboboxentry1.Entry.Text = this.minValue.ToString();
        if (this.ValueChanged != null)
        {
          this.entry1 = Convert.ToInt32(this.comboboxentry1.Entry.Text);
          this.RaiseValueChanged((object) null, (System.Action) (() => this.ValueChanged((object) null, new EntryComboxEvent(0, this.entry1))));
        }
      }
      this.isKeyPress = false;
    }

    private void Entry_FocusOutEvent2(object o, FocusOutEventArgs args)
    {
      if (this.isKeyPress)
      {
        if (string.IsNullOrEmpty(this.comboboxentry2.Entry.Text))
        {
          this.comboboxentry2.Entry.Text = this.entry2.ToString();
          return;
        }
        if (Convert.ToInt32(this.comboboxentry2.Entry.Text) > this.maxValue)
          this.comboboxentry2.Entry.Text = this.maxValue.ToString();
        if (Convert.ToInt32(this.comboboxentry2.Entry.Text) < this.minValue)
          this.comboboxentry2.Entry.Text = this.minValue.ToString();
        if (this.ValueChanged != null)
        {
          this.entry2 = Convert.ToInt32(this.comboboxentry2.Entry.Text);
          this.RaiseValueChanged((object) null, (System.Action) (() => this.ValueChanged((object) null, new EntryComboxEvent(1, this.entry2))));
        }
      }
      this.isKeyPress = false;
    }

    private void Entry_KeyReleaseEvent1(object o, KeyReleaseEventArgs args)
    {
      this.isKeyPress = true;
      int num;
      switch (args.Event.Key)
      {
        case Gdk.Key.Return:
        case Gdk.Key.KP_Enter:
        case Gdk.Key.ISO_Enter:
          num = !this.comboboxentry1.Entry.IsFocus ? 1 : 0;
          break;
        default:
          num = 1;
          break;
      }
      if (num == 0 && !string.IsNullOrEmpty(this.comboboxentry1.Entry.Text))
      {
        if (Convert.ToInt32(this.comboboxentry1.Entry.Text) > this.maxValue)
          this.comboboxentry1.Entry.Text = this.maxValue.ToString();
        if (Convert.ToInt32(this.comboboxentry1.Entry.Text) < this.minValue)
          this.comboboxentry1.Entry.Text = this.minValue.ToString();
        if (this.ValueChanged != null)
        {
          this.entry1 = Convert.ToInt32(this.comboboxentry1.Entry.Text);
          this.isKeyPress = false;
          this.RaiseValueChanged((object) null, (System.Action) (() => this.ValueChanged((object) null, new EntryComboxEvent(0, this.entry1))));
        }
        this.isKeyPress = false;
      }
    }

    private void Entry_KeyReleaseEvent2(object o, KeyReleaseEventArgs args)
    {
      this.isKeyPress = true;
      int num;
      switch (args.Event.Key)
      {
        case Gdk.Key.Return:
        case Gdk.Key.KP_Enter:
        case Gdk.Key.ISO_Enter:
          num = !this.comboboxentry2.Entry.IsFocus ? 1 : 0;
          break;
        default:
          num = 1;
          break;
      }
      if (num == 0 && !string.IsNullOrEmpty(this.comboboxentry2.Entry.Text))
      {
        if (Convert.ToInt32(this.comboboxentry2.Entry.Text) > this.maxValue)
          this.comboboxentry2.Entry.Text = this.maxValue.ToString();
        if (Convert.ToInt32(this.comboboxentry2.Entry.Text) < this.minValue)
          this.comboboxentry2.Entry.Text = this.minValue.ToString();
        if (this.ValueChanged != null)
        {
          this.entry2 = Convert.ToInt32(this.comboboxentry2.Entry.Text);
          this.isKeyPress = false;
          this.RaiseValueChanged((object) null, (System.Action) (() => this.ValueChanged((object) null, new EntryComboxEvent(1, this.entry2))));
        }
        this.isKeyPress = false;
      }
    }

    public void SetControl(int width, int height)
    {
      this.comboboxentry1.Entry.Text = width.ToString();
      this.entry1 = width;
      this.comboboxentry2.Entry.Text = height.ToString();
      this.entry2 = height;
    }

    public override void ReadLanuageConfigFile()
    {
    }
  }
}
