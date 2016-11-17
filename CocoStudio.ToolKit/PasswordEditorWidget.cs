// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.PasswordEditorWidget
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using Gtk;
using Modules.Communal.MultiLanguage;
using System;

namespace CocoStudio.ToolKit
{
  public class PasswordEditorWidget : BaseEditorWidget
  {
    private string _passwordText = string.Empty;
    private Table table2;
    private CheckButton checkBox_Password;
    private DefaultEditorGtk txt_Password;

    public event EventHandler<BoolEvent> IsCheckChanged;

    public event EventHandler<BoolEvent> TextCangede;

    public PasswordEditorWidget()
    {
      this.table2 = new Table(1U, 2U, false);
      this.table2.Name = "table2";
      this.table2.ColumnSpacing = 6U;
      this.checkBox_Password = new CheckButton();
      this.checkBox_Password.CanFocus = true;
      this.checkBox_Password.Name = "checkBox_Password";
      this.checkBox_Password.Active = true;
      this.checkBox_Password.DrawIndicator = true;
      this.checkBox_Password.UseUnderline = true;
      this.table2.Add((Widget) this.checkBox_Password);
      Table.TableChild tableChild1 = (Table.TableChild) this.table2[(Widget) this.checkBox_Password];
      tableChild1.XOptions = AttachOptions.Fill;
      tableChild1.YOptions = AttachOptions.Fill;
      this.txt_Password = new DefaultEditorGtk();
      this.txt_Password.WidthRequest = 10;
      this.txt_Password.CanFocus = true;
      this.txt_Password.Name = "txt_Password";
      this.txt_Password.IsEditable = true;
      this.txt_Password.MaxLength = 1;
      this.txt_Password.InvisibleChar = '●';
      this.table2.Add((Widget) this.txt_Password);
      Table.TableChild tableChild2 = (Table.TableChild) this.table2[(Widget) this.txt_Password];
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
      this.BeforeValueChanged += new System.Action(this.BeforEvent);
      this.AfterValueChanged += new System.Action(this.AfterEvent);
      this.AfterEvent();
    }

    private void BeforEvent()
    {
      this.checkBox_Password.Clicked -= new EventHandler(this.checkBox_Password_Clicked);
      this.txt_Password.KeyReleaseEvent -= new KeyReleaseEventHandler(this.txt_Password_KeyReleaseEvent);
      this.txt_Password.FocusOutEvent -= new FocusOutEventHandler(this.txt_Password_FocusOutEvent);
    }

    private void txt_Password_KeyReleaseEvent(object o, KeyReleaseEventArgs args)
    {
      if (args.Event.Key != Gdk.Key.Return || !this.txt_Password.IsFocus)
        return;
      this.UpdateDate();
    }

    private void txt_Password_FocusOutEvent(object o, FocusOutEventArgs args)
    {
      if (string.IsNullOrEmpty(this.txt_Password.Text))
        this.txt_Password.Text = this._passwordText;
      else
        this.RaiseValueChanged((object) null, (System.Action) (() => this.UpdateDate()));
    }

    private void UpdateDate()
    {
      this.RaiseValueChanged((object) null, (System.Action) (() =>
      {
        if (!this.Retrieval(this.txt_Password.Text) || this.txt_Password.Text == this._passwordText)
          return;
        if (this.TextCangede != null)
          this.TextCangede((object) null, new BoolEvent(false, this.txt_Password.Text, 0.0));
        this._passwordText = this.txt_Password.Text;
      }));
    }

    private void AfterEvent()
    {
      this.checkBox_Password.Clicked += new EventHandler(this.checkBox_Password_Clicked);
      this.txt_Password.KeyReleaseEvent += new KeyReleaseEventHandler(this.txt_Password_KeyReleaseEvent);
      this.txt_Password.FocusOutEvent += new FocusOutEventHandler(this.txt_Password_FocusOutEvent);
    }

    public void SetControl(bool status, string text)
    {
      this.checkBox_Password.Active = status;
      this.txt_Password.Text = text;
      this._passwordText = this.txt_Password.Text;
      this.txt_Password.Sensitive = status;
    }

    private void checkBox_Password_Clicked(object sender, EventArgs e)
    {
      this.RaiseValueChanged((object) null, (System.Action) (() =>
      {
        this.txt_Password.Sensitive = this.checkBox_Password.Active;
        if (this.IsCheckChanged == null)
          return;
        this.IsCheckChanged((object) null, new BoolEvent(this.checkBox_Password.Active, "", 0.0));
      }));
    }

    private bool Retrieval(string password)
    {
      if (password == string.Empty)
        return true;
      int int32 = Convert.ToInt32(password[0]);
      return int32 > 32 && int32 < (int) sbyte.MaxValue;
    }

    public override void ReadLanuageConfigFile()
    {
      this.txt_Password.TooltipText = LanguageInfo.txt_Password;
    }
  }
}
