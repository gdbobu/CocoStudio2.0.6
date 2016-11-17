// Decompiled with JetBrains decompiler
// Type: CocoStudio.ControlLib.ProgressDialog
// Assembly: CocoStudio.ControlLib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 677D14F9-F98B-4FDA-9ECD-6C6F82FD30A1
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ControlLib.dll

using GLib;
using Gtk;
using Modules.Communal.MultiLanguage;
using Mono.Unix;
using MonoDevelop.Core;
using Pango;
using Stetic;
using System;
using System.Collections.Generic;

namespace CocoStudio.ControlLib
{
  public class ProgressDialog : Dialog
  {
    private static object SnyObject = new object();
    private int ident = 0;
    private List<TextTag> tags = new List<TextTag>();
    private Stack<string> indents = new Stack<string>();
    private TextBuffer buffer;
    private TextTag tag;
    private TextTag bold;
    private IAsyncOperation asyncOperation;
    private VBox vbox2;
    private Label label;
    private HBox hbox1;
    private ProgressBar progressBar;
    private Button btnCancel;
    private Button btnClose;
    private Expander expander;
    private ScrolledWindow GtkScrolledWindow;
    private TextView detailsTextView;
    private Label expanderLabel;
    private Button button103;

    public IAsyncOperation AsyncOperation
    {
      get
      {
        return this.asyncOperation;
      }
      set
      {
        this.asyncOperation = value;
      }
    }

    public string Message
    {
      get
      {
        return this.label.Text;
      }
      set
      {
        this.label.Text = value;
      }
    }

    public double Progress
    {
      get
      {
        return this.progressBar.Fraction;
      }
      set
      {
        this.progressBar.Fraction = value;
      }
    }

    public event EventHandler OperationCancelled;

    public ProgressDialog(bool allowCancel, bool showDetails)
      : this((Window) null, allowCancel, showDetails)
    {
    }

    public ProgressDialog(Window parent, bool allowCancel, bool showDetails)
    {
      this.Build();
      this.Title = BrandingService.ApplicationName;
      this.HasSeparator = false;
      this.ActionArea.Hide();
      this.DefaultHeight = 5;
      this.detailsTextView.WrapMode = Gtk.WrapMode.Word;
      this.TransientFor = parent;
      this.btnCancel.Visible = allowCancel;
      this.expander.Visible = showDetails;
      this.buffer = this.detailsTextView.Buffer;
      this.detailsTextView.Editable = false;
      this.bold = new TextTag("bold");
      this.bold.Weight = Weight.Bold;
      this.buffer.TagTable.Add(this.bold);
      this.tag = new TextTag("0");
      this.tag.Indent = 10;
      this.buffer.TagTable.Add(this.tag);
      this.tags.Add(this.tag);
      this.SetMultiLanguageInfo();
    }

    private void SetMultiLanguageInfo()
    {
      this.Title = LanguageInfo.Menu_File_Import;
      this.btnClose.Label = LanguageInfo.Dialog_ButtonClose;
      this.btnCancel.Label = LanguageInfo.Dialog_ButtonCancel;
      this.expanderLabel.Text = LanguageInfo.Dialog_New_ShowOuput;
      this.label.Text = LanguageInfo.Dialog_Import_Importing;
    }

    public void BeginTask(string name)
    {
      if (name != null && name.Length > 0)
      {
        this.Indent();
        this.indents.Push(name);
        this.Message = name;
      }
      else
        this.indents.Push((string) null);
      if (name == null)
        return;
      int num = (int) GLib.Timeout.Add(0U, (TimeoutHandler) (() =>
      {
        TextIter endIter = this.buffer.EndIter;
        string text = name + "\n";
        this.buffer.InsertWithTags(ref endIter, text, this.tag, this.bold);
        this.detailsTextView.ScrollMarkOnscreen(this.buffer.InsertMark);
        return false;
      }));
    }

    public void EndTask()
    {
      if (this.indents.Count <= 0)
        return;
      string str = this.indents.Pop();
      if (str != null)
      {
        this.Unindent();
        this.Message = str;
      }
    }

    public void WriteText(string text)
    {
      int num = (int) GLib.Timeout.Add(0U, (TimeoutHandler) (() =>
      {
        this.AddText(text);
        if (text.EndsWith("\n"))
          this.detailsTextView.ScrollMarkOnscreen(this.buffer.InsertMark);
        return false;
      }));
    }

    private void AddText(string s)
    {
      TextIter endIter = this.buffer.EndIter;
      this.buffer.InsertWithTags(ref endIter, s, new TextTag[1]{ this.tag });
    }

    private void Indent()
    {
      ++this.ident;
      if (this.ident >= this.tags.Count)
      {
        this.tag = new TextTag(this.ident.ToString());
        this.tag.Indent = 10 + 15 * (this.ident - 1);
        this.buffer.TagTable.Add(this.tag);
        this.tags.Add(this.tag);
      }
      else
        this.tag = this.tags[this.ident];
    }

    private void Unindent()
    {
      if (this.ident < 0)
        return;
      --this.ident;
      this.tag = this.tags[this.ident];
    }

    public void ShowDone(bool warnings, bool errors)
    {
      this.progressBar.Fraction = 1.0;
      this.btnCancel.Hide();
      this.btnClose.Show();
      if (errors)
        this.label.Text = LanguageInfo.Dialog_Import_Failed;
      else if (warnings)
        this.label.Text = LanguageInfo.Dialog_Import_Warring;
      else
        this.label.Text = LanguageInfo.Dialog_Import_Success;
    }

    protected void OnBtnCancelClicked(object sender, EventArgs e)
    {
      if (this.asyncOperation != null)
        this.asyncOperation.Cancel();
      if (this.OperationCancelled == null)
        return;
      this.OperationCancelled((object) this, (EventArgs) null);
    }

    private bool UpdateSize()
    {
      int width;
      int height;
      this.GetSize(out width, out height);
      this.Resize(width, 1);
      return false;
    }

    protected virtual void OnExpander1Activated(object sender, EventArgs e)
    {
      int num = (int) GLib.Timeout.Add(100U, new TimeoutHandler(this.UpdateSize));
    }

    protected virtual void OnBtnCloseClicked(object sender, EventArgs e)
    {
      this.Destroy();
    }

    protected virtual void Build()
    {
      Gui.Initialize((Widget) this);
      this.Name = "MonoDevelop.Ide.Gui.Dialogs.ProgressDialog";
      this.Title = "";
      this.WindowPosition = WindowPosition.CenterOnParent;
      this.Modal = true;
      VBox vbox = this.VBox;
      vbox.Name = "dialog1_VBox";
      vbox.BorderWidth = 2U;
      this.vbox2 = new VBox();
      this.vbox2.Name = "vbox2";
      this.vbox2.Spacing = 6;
      this.vbox2.BorderWidth = 12U;
      this.label = new Label();
      this.label.Name = "label";
      this.label.Xalign = 0.0f;
      this.label.LabelProp = "label";
      this.vbox2.Add((Widget) this.label);
      Box.BoxChild boxChild1 = (Box.BoxChild) this.vbox2[(Widget) this.label];
      boxChild1.Position = 0;
      boxChild1.Expand = false;
      boxChild1.Fill = false;
      this.hbox1 = new HBox();
      this.hbox1.Name = "hbox1";
      this.hbox1.Spacing = 6;
      this.progressBar = new ProgressBar();
      this.progressBar.Name = "progressBar";
      this.hbox1.Add((Widget) this.progressBar);
      ((Box.BoxChild) this.hbox1[(Widget) this.progressBar]).Position = 0;
      this.btnCancel = new Button();
      this.btnCancel.CanDefault = true;
      this.btnCancel.CanFocus = true;
      this.btnCancel.Name = "btnCancel";
      this.btnCancel.UseStock = true;
      this.btnCancel.UseUnderline = true;
      this.btnCancel.Label = "gtk-cancel";
      this.hbox1.Add((Widget) this.btnCancel);
      Box.BoxChild boxChild2 = (Box.BoxChild) this.hbox1[(Widget) this.btnCancel];
      boxChild2.Position = 1;
      boxChild2.Expand = false;
      boxChild2.Fill = false;
      this.btnClose = new Button();
      this.btnClose.CanDefault = true;
      this.btnClose.CanFocus = true;
      this.btnClose.Name = "btnClose";
      this.btnClose.UseStock = true;
      this.btnClose.UseUnderline = true;
      this.btnClose.Label = "gtk-close";
      this.hbox1.Add((Widget) this.btnClose);
      Box.BoxChild boxChild3 = (Box.BoxChild) this.hbox1[(Widget) this.btnClose];
      boxChild3.Position = 2;
      boxChild3.Expand = false;
      boxChild3.Fill = false;
      this.vbox2.Add((Widget) this.hbox1);
      Box.BoxChild boxChild4 = (Box.BoxChild) this.vbox2[(Widget) this.hbox1];
      boxChild4.Position = 1;
      boxChild4.Expand = false;
      boxChild4.Fill = false;
      this.expander = new Expander((string) null);
      this.expander.CanFocus = true;
      this.expander.Name = "expander";
      this.GtkScrolledWindow = new ScrolledWindow();
      this.GtkScrolledWindow.HeightRequest = 250;
      this.GtkScrolledWindow.Name = "GtkScrolledWindow";
      this.GtkScrolledWindow.ShadowType = ShadowType.In;
      this.detailsTextView = new TextView();
      this.detailsTextView.CanFocus = true;
      this.detailsTextView.Name = "detailsTextView";
      this.GtkScrolledWindow.Add((Widget) this.detailsTextView);
      this.expander.Add((Widget) this.GtkScrolledWindow);
      this.expanderLabel = new Label();
      this.expanderLabel.Name = "expanderLabel";
      this.expanderLabel.LabelProp = Catalog.GetString("Details");
      this.expanderLabel.UseUnderline = true;
      this.expander.LabelWidget = (Widget) this.expanderLabel;
      this.vbox2.Add((Widget) this.expander);
      ((Box.BoxChild) this.vbox2[(Widget) this.expander]).Position = 2;
      vbox.Add((Widget) this.vbox2);
      ((Box.BoxChild) vbox[(Widget) this.vbox2]).Position = 0;
      HButtonBox actionArea = this.ActionArea;
      actionArea.Name = "dialog1_ActionArea";
      actionArea.Spacing = 10;
      actionArea.BorderWidth = 5U;
      actionArea.LayoutStyle = ButtonBoxStyle.End;
      this.button103 = new Button();
      this.button103.CanFocus = true;
      this.button103.Name = "button103";
      this.button103.UseUnderline = true;
      this.button103.Label = Catalog.GetString("GtkButton");
      this.AddActionWidget((Widget) this.button103, 0);
      ButtonBox.ButtonBoxChild buttonBoxChild = (ButtonBox.ButtonBoxChild) actionArea[(Widget) this.button103];
      buttonBoxChild.Expand = false;
      buttonBoxChild.Fill = false;
      if (this.Child != null)
        this.Child.ShowAll();
      this.DefaultWidth = 544;
      this.DefaultHeight = 170;
      this.btnClose.Hide();
      actionArea.Hide();
      this.Hide();
      this.btnCancel.Clicked += new EventHandler(this.OnBtnCancelClicked);
      this.btnClose.Clicked += new EventHandler(this.OnBtnCloseClicked);
      this.expander.Activated += new EventHandler(this.OnExpander1Activated);
    }
  }
}
