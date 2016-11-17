// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.TextEditorWindow
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using CocoStudio.UndoManager;
using Gdk;
using Gtk;
using Gtk.Controls;
using Modules.Communal.MultiLanguage;
using Mono.Unix;
using MonoDevelop.Core;
using Stetic;
using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace CocoStudio.ToolKit
{
  public class TextEditorWindow : Gtk.Window
  {
    private int[] comboxList = new int[17]{ 6, 7, 8, 9, 10, 11, 12, 13, 14, 16, 18, 20, 22, 24, 36, 48, 72 };
    private VBox vbox2;
    private ScrolledWindow GtkScrolledWindow;
    private TextView textview;
    private HBox hbox1;
    private SpinButton fontSizeSpinButton;
    private Button buttonCancel;
    private Button buttonOk;
    private object triggerObject;
    private string textProperty;
    private string colorType;
    private string fontSizeType;
    private ColorEx colorButtonGtk;
    private ComboBoxEntry combox;
    private Entry textEntry;
    private bool canLineFeed;
    private int fontsize;

    public object TriggerObject
    {
      get
      {
        return this.triggerObject;
      }
      set
      {
        if (this.triggerObject == value)
          return;
        this.triggerObject = value;
      }
    }

    public TextEditorWindow(object triggerobject, string textproperty = null, string color = null, string fontsize = null, bool canlinefeed = false)
      : base(Gtk.WindowType.Toplevel)
    {
      this.TypeHint = WindowTypeHint.Dialog;
      this.Resizable = false;
      this.Modal = true;
      this.TriggerObject = triggerobject;
      this.TransientFor = ApplicationCurrent.MainWindow;
      this.textProperty = textproperty;
      this.colorType = color;
      this.fontSizeType = fontsize;
      this.canLineFeed = canlinefeed;
      this.Build();
      this.InitEditor();
    }

    protected virtual void Build()
    {
      Gui.Initialize((Widget) this);
      this.Name = "CocoStudio.ToolKit.TextEditorWindow";
      this.Title = "";
      this.WindowPosition = WindowPosition.CenterOnParent;
      this.DefaultWidth = 300;
      this.vbox2 = new VBox();
      this.vbox2.Name = "vbox2";
      this.vbox2.Spacing = 6;
      this.vbox2.BorderWidth = 10U;
      this.GtkScrolledWindow = new ScrolledWindow();
      this.GtkScrolledWindow.Name = "GtkScrolledWindow";
      this.GtkScrolledWindow.ShadowType = ShadowType.In;
      this.textview = new TextView();
      this.textview.WidthRequest = 278;
      this.textview.HeightRequest = 60;
      this.textview.CanFocus = true;
      this.textview.Name = "textview";
      this.textview.LeftMargin = 6;
      this.textview.RightMargin = 6;
      this.GtkScrolledWindow.Add((Widget) this.textview);
      this.vbox2.Add((Widget) this.GtkScrolledWindow);
      ((Box.BoxChild) this.vbox2[(Widget) this.GtkScrolledWindow]).Position = 0;
      this.hbox1 = new HBox();
      this.hbox1.Name = "hbox1";
      this.hbox1.Spacing = 6;
      this.fontSizeSpinButton = new SpinButton(0.0, 100.0, 1.0);
      this.fontSizeSpinButton.WidthRequest = 50;
      this.fontSizeSpinButton.CanFocus = true;
      this.fontSizeSpinButton.Name = "fontSizeSpinButton";
      this.fontSizeSpinButton.Adjustment.PageIncrement = 10.0;
      this.fontSizeSpinButton.ClimbRate = 1.0;
      this.fontSizeSpinButton.Numeric = true;
      this.hbox1.Add((Widget) this.fontSizeSpinButton);
      Box.BoxChild boxChild1 = (Box.BoxChild) this.hbox1[(Widget) this.fontSizeSpinButton];
      boxChild1.Position = 0;
      boxChild1.Expand = false;
      boxChild1.Fill = false;
      this.buttonCancel = new Button();
      this.buttonCancel.WidthRequest = 55;
      this.buttonCancel.CanFocus = true;
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.UseUnderline = true;
      this.buttonCancel.Label = Catalog.GetString("Cancel");
      this.hbox1.Add((Widget) this.buttonCancel);
      Box.BoxChild boxChild2 = (Box.BoxChild) this.hbox1[(Widget) this.buttonCancel];
      boxChild2.PackType = PackType.End;
      boxChild2.Position = 1;
      boxChild2.Expand = false;
      boxChild2.Fill = false;
      this.buttonOk = new Button();
      this.buttonOk.WidthRequest = 55;
      this.buttonOk.CanFocus = true;
      this.buttonOk.Name = "buttonOk";
      this.buttonOk.UseUnderline = true;
      this.buttonOk.Label = Catalog.GetString("Ok");
      this.hbox1.Add((Widget) this.buttonOk);
      Box.BoxChild boxChild3 = (Box.BoxChild) this.hbox1[(Widget) this.buttonOk];
      boxChild3.PackType = PackType.End;
      boxChild3.Position = 2;
      boxChild3.Expand = false;
      boxChild3.Fill = false;
      this.vbox2.Add((Widget) this.hbox1);
      Box.BoxChild boxChild4 = (Box.BoxChild) this.vbox2[(Widget) this.hbox1];
      boxChild4.Position = 1;
      boxChild4.Expand = false;
      boxChild4.Fill = false;
      this.Add((Widget) this.vbox2);
      if (this.Child != null)
        this.Child.ShowAll();
      this.DefaultHeight = 300;
      this.Show();
    }

    private void InitEditor()
    {
      this.buttonOk.Label = LanguageInfo.Dialog_ButtonOK;
      this.buttonOk.Name = "MainButton";
      this.buttonCancel.Label = LanguageInfo.Dialog_ButtonCancel;
      this.combox = new ComboBoxEntry();
      this.combox.WidthRequest = 60;
      this.hbox1.Add((Widget) this.combox);
      Box.BoxChild boxChild1 = (Box.BoxChild) this.hbox1[(Widget) this.combox];
      this.colorButtonGtk = new ColorEx();
      this.colorButtonGtk.WidthRequest = 105;
      this.hbox1.Add((Widget) this.colorButtonGtk);
      Box.BoxChild boxChild2 = (Box.BoxChild) this.hbox1[(Widget) this.colorButtonGtk];
      this.textEntry = new Entry();
      this.textEntry.WidthRequest = 278;
      this.vbox2.Add((Widget) this.textEntry);
      ((Box.BoxChild) this.vbox2[(Widget) this.textEntry]).Position = 0;
      if (Platform.IsMac)
      {
        Box.BoxChild boxChild3 = (Box.BoxChild) this.hbox1[(Widget) this.buttonOk];
        Box.BoxChild boxChild4 = (Box.BoxChild) this.hbox1[(Widget) this.buttonCancel];
        boxChild1.Position = 1;
        boxChild2.Position = 2;
        boxChild3.Position = 3;
        boxChild4.Position = 4;
      }
      this.fontSizeSpinButton.SetRange(5.0, 100.0);
      this.ShowAll();
      this.fontSizeSpinButton.Hide();
      this.FontSizeComboxInit();
      this.InitText();
      this.InitEvent();
      this.textview.AcceptsTab = false;
    }

    private void FontSizeComboxInit()
    {
      if (this.fontSizeType == null)
      {
        this.combox.Hide();
      }
      else
      {
        this.combox.Entry.FocusOutEvent += new FocusOutEventHandler(this.Entry_FocusOutEvent);
        this.combox.Entry.MaxLength = 3;
        this.combox.Changed += new EventHandler(this.combox_Changed);
        this.fontsize = (int) this.TriggerObject.GetType().GetProperty(this.fontSizeType).GetValue(this.TriggerObject, (object[]) null);
        ListStore listStore = new ListStore(new Type[1]{ typeof (string) });
        foreach (int combox in this.comboxList)
          listStore.AppendValues(new object[1]
          {
            (object) combox.ToString()
          });
        this.combox.Model = (TreeModel) listStore;
        CellRendererText cellRendererText = new CellRendererText();
        this.combox.PackStart((CellRenderer) cellRendererText, true);
        this.combox.AddAttribute((CellRenderer) cellRendererText, "text", 0);
        int index = this.IndexCombox(this.fontsize);
        if (index == -1)
        {
          this.combox.Entry.Text = this.fontsize.ToString();
        }
        else
        {
          this.combox.Active = index;
          this.combox.Entry.Text = this.comboxList[index].ToString();
        }
      }
    }

    private void combox_Changed(object sender, EventArgs e)
    {
      ComboBoxEntry comboBoxEntry = sender as ComboBoxEntry;
      if (comboBoxEntry.Active == -1)
        return;
      comboBoxEntry.Entry.Text = this.comboxList[comboBoxEntry.Active].ToString();
    }

    private void Entry_FocusOutEvent(object o, FocusOutEventArgs args)
    {
      string text = this.combox.Entry.Text;
      if (!Regex.IsMatch(text, "^[0-9]+$"))
      {
        this.combox.Entry.Text = this.fontsize.ToString();
      }
      else
      {
        int int32 = Convert.ToInt32(text);
        if (int32 < 5)
          this.combox.Entry.Text = "5";
        else if (int32 > 100)
          this.combox.Entry.Text = "100";
      }
    }

    private int IndexCombox(int num)
    {
      for (int index = 0; index < this.comboxList.Length; ++index)
      {
        if (this.comboxList[index] == num)
          return index;
      }
      return -1;
    }

    private void InitEvent()
    {
      this.buttonOk.Clicked += new EventHandler(this.OnbuttonOk_Click);
      this.buttonCancel.Clicked += new EventHandler(this.OnbuttonCancel_Click);
      this.KeyReleaseEvent += new KeyReleaseEventHandler(this.TextEditorWindow_KeyReleaseEvent);
    }

    private void TextEditorWindow_KeyReleaseEvent(object o, KeyReleaseEventArgs args)
    {
      if (args.Event.Key == Gdk.Key.Return && !this.canLineFeed)
      {
        this.SaveAll();
        this.Destroy();
      }
      else
      {
        if (args.Event.Key != Gdk.Key.Escape)
          return;
        this.Destroy();
      }
    }

    private void fontSizeSpinButton_ChangeValue(object o, ChangeValueArgs args)
    {
    }

    private void InitText()
    {
      string str = (string) this.TriggerObject.GetType().GetProperty(this.textProperty).GetValue(this.TriggerObject, (object[]) null);
      if (this.canLineFeed)
      {
        this.textEntry.Hide();
        this.textview.Buffer.Text = str;
        this.textview.Buffer.SelectRange(this.textview.Buffer.StartIter, this.textview.Buffer.EndIter);
      }
      else
      {
        this.GtkScrolledWindow.Hide();
        this.textEntry.Text = str;
      }
      if (this.fontSizeType != null)
        ;
      if (this.colorType == null)
      {
        this.colorButtonGtk.Hide();
      }
      else
      {
        System.Drawing.Color color = (System.Drawing.Color) this.TriggerObject.GetType().GetProperty(this.colorType).GetValue(this.TriggerObject, (object[]) null);
        this.colorButtonGtk.color.Value = (object) color;
        this.colorButtonGtk.Color = color;
      }
    }

    protected void OnbuttonOk_Click(object sender, EventArgs e)
    {
      this.SaveAll();
      this.Destroy();
    }

    protected void OnbuttonCancel_Click(object sender, EventArgs e)
    {
      this.Destroy();
    }

    private void SaveAll()
    {
      using (CompositeTask.Run("编辑文本"))
      {
        PropertyInfo property = this.TriggerObject.GetType().GetProperty(this.textProperty);
        if (this.canLineFeed)
          property.SetValue(this.TriggerObject, (object) this.textview.Buffer.Text, (object[]) null);
        else
          property.SetValue(this.TriggerObject, (object) this.textEntry.Text, (object[]) null);
        if (this.fontSizeType != null)
          this.TriggerObject.GetType().GetProperty(this.fontSizeType).SetValue(this.TriggerObject, (object) Convert.ToInt32(this.combox.Entry.Text), (object[]) null);
        if (this.colorType == null)
          return;
        this.TriggerObject.GetType().GetProperty(this.colorType).SetValue(this.TriggerObject, (object) (System.Drawing.Color) this.colorButtonGtk.color.Value, (object[]) null);
      }
    }
  }
}
