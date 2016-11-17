// Decompiled with JetBrains decompiler
// Type: CocoStudio.ControlLib.Windows.LoginDialog
// Assembly: CocoStudio.ControlLib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 677D14F9-F98B-4FDA-9ECD-6C6F82FD30A1
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ControlLib.dll

using CocoStudio.Basic;
using CocoStudio.ControlLib.Event;
using CocoStudio.ControlLib.Model;
using Gdk;
using Gtk;
using Modules.Communal.CocoaChina;
using Modules.Communal.MultiLanguage;
using Mono.Unix;
using MonoDevelop.Core;
using Stetic;
using System;
using System.Diagnostics;

namespace CocoStudio.ControlLib.Windows
{
  public class LoginDialog : Dialog
  {
    private const string registerUri = "http://open.cocoachina.com/login/reg1";
    private const string forgotPasswordUri = "http://open.cocoachina.com/login/forget_pass";
    private LoginInfo loginInfo;
    private EventBox evtbx_border;
    private Table table_main;
    private HBox hbox_firstRow;
    private Entry entry_Name;
    private LabelLink link_RegisterAccount;
    private HBox hbox_fourthRow;
    private Label label_remark;
    private HBox hbox_secondRow;
    private PassWordEntry entry_PassWord;
    private LabelLink link_ForgotPassword;
    private HBox hbox_thirdRow;
    private CheckButton checkbutton_password;
    private CheckButton checkbutton_AutoLogin;
    private Label label_Name;
    private Label label_PassWord;
    private Button buttonCancel;
    private Button buttonOk;

    public string RegisterUri
    {
      get
      {
        return "http://open.cocoachina.com/login/reg1";
      }
    }

    public string ForgotPasswordUri
    {
      get
      {
        return "http://open.cocoachina.com/login/forget_pass";
      }
    }

    public event EventHandler<UserLoginEventArgs> UserLoginEvent;

    public LoginDialog()
    {
      this.Build();
      this.buttonOk.Name = "MainButton";
      this.Init();
      this.InitEvevt();
      this.InitMultiLanguage();
      this.buttonOk.GrabDefault();
    }

    private void Init()
    {
      this.ChangeBtnPosion();
      this.AllowGrow = false;
      this.SetToDialogStyle((Gtk.Window) null, true, true, true);
      this.entry_PassWord.ActivatesDefault = true;
      this.entry_Name.ActivatesDefault = true;
      this.entry_PassWord.Visibility = false;
      this.entry_PassWord.InvisibleChar = '*';
      this.link_ForgotPassword.SetContent((object) this.ForgotPasswordUri);
      this.link_ForgotPassword.LeftClicked += new EventHandler<LabelClickedEventArgs>(this.OnOpenWeb);
      this.link_ForgotPassword.SetTooltip(this.ForgotPasswordUri);
      this.link_RegisterAccount.SetContent((object) this.RegisterUri);
      this.link_RegisterAccount.LeftClicked += new EventHandler<LabelClickedEventArgs>(this.OnOpenWeb);
      this.link_RegisterAccount.SetTooltip(this.RegisterUri);
      this.SetLabelStyle();
      this.loginInfo = new LoginInfo();
      if (this.loginInfo.IsRememberPassWord)
      {
        this.entry_Name.Text = this.loginInfo.UserName;
        this.entry_PassWord.Text = this.loginInfo.UserPassword;
        this.checkbutton_password.Active = this.loginInfo.IsRememberPassWord;
      }
      this.checkbutton_AutoLogin.Active = this.loginInfo.IsAutoLogin;
    }

    private void ChangeBtnPosion()
    {
      if (Platform.IsMac)
        return;
      HButtonBox actionArea = this.ActionArea;
      ButtonBox.ButtonBoxChild buttonBoxChild1 = (ButtonBox.ButtonBoxChild) actionArea[(Widget) this.buttonOk];
      ButtonBox.ButtonBoxChild buttonBoxChild2 = (ButtonBox.ButtonBoxChild) actionArea[(Widget) this.buttonCancel];
      buttonBoxChild1.Position = 0;
      buttonBoxChild2.Position = 1;
    }

    private void SetLabelStyle()
    {
      this.link_ForgotPassword.SetLabelAlign(0.0f, 0.5f);
      this.link_RegisterAccount.SetLabelAlign(0.0f, 0.5f);
      this.link_ForgotPassword.SetFontSize(LabelStyleSetting.LoginLinkSize);
      this.link_RegisterAccount.SetFontSize(LabelStyleSetting.LoginLinkSize);
    }

    private void InitMultiLanguage()
    {
      this.Title = LanguageInfo.Login;
      this.label_Name.Text = LanguageInfo.UserName;
      this.label_PassWord.Text = LanguageInfo.UserPassWord;
      this.label_remark.Text = LanguageInfo.LoginRemark;
      this.buttonOk.Label = LanguageInfo.Login;
      this.buttonCancel.Label = LanguageInfo.Dialog_ButtonCancel;
      this.entry_Name.TooltipText = LanguageInfo.UserNameTip;
      this.entry_PassWord.TooltipText = LanguageInfo.UserPassWordTip;
      this.link_ForgotPassword.SetLabelText(LanguageInfo.ForgotPassword);
      this.link_RegisterAccount.SetLabelText(LanguageInfo.RegisteredAccount);
      this.checkbutton_password.Label = LanguageInfo.RememberPassWord;
      this.checkbutton_AutoLogin.Label = LanguageInfo.AutoLogin;
    }

    private void InitEvevt()
    {
      this.entry_PassWord.Changed += new EventHandler(this.entry_PassWord_Changed);
      this.buttonOk.Clicked += new EventHandler(this.buttonOk_Clicked);
      this.buttonCancel.Clicked += new EventHandler(this.buttonCancel_Clicked);
      this.WidgetEvent += new WidgetEventHandler(this.LoginDialog_WidgetEvent);
      this.checkbutton_password.Clicked += new EventHandler(this.checkbutton_password_Clicked);
      this.checkbutton_AutoLogin.Clicked += new EventHandler(this.checkbutton_AutoLogin_Clicked);
    }

    private void SaveInfo()
    {
      this.loginInfo.IsRememberPassWord = this.checkbutton_password.Active;
      this.loginInfo.IsAutoLogin = this.checkbutton_AutoLogin.Active;
      this.loginInfo.UserName = this.entry_Name.Text;
      this.loginInfo.UserPassword = this.entry_PassWord.Text;
    }

    private void entry_PassWord_Changed(object sender, EventArgs e)
    {
      this.buttonOk.Sensitive = ProjectViewModel.IsMatchToLogin(this.entry_PassWord.Text);
    }

    private void buttonOk_Clicked(object sender, EventArgs e)
    {
      string info = string.Empty;
      if (this.entry_Name.Text == string.Empty)
        info = LanguageInfo.UserNameTip;
      else if (this.entry_PassWord.Text == string.Empty)
        info = LanguageInfo.UserPassWordTip;
      if (info != string.Empty)
      {
        MessageBox.Show(info, (Gtk.Window) this, (string) null, MessageBoxImage.Info);
        this.Run();
      }
      else
      {
        string text1 = this.entry_Name.Text;
        string text2 = this.entry_PassWord.Text;
        Login login = new Login();
        login.OnResived += new EventHandler<CocoaUserArgs>(this.login_OnResived);
        login.SyncLoginCocoaChina(text1, text2);
      }
    }

    private void login_OnResived(object sender, CocoaUserArgs e)
    {
      Login login = sender as Login;
      if (login != null)
        login.OnResived -= new EventHandler<CocoaUserArgs>(this.login_OnResived);
      if (string.IsNullOrWhiteSpace(e.User.ErrorMsg))
      {
        if (this.UserLoginEvent != null)
          this.UserLoginEvent((object) this, new UserLoginEventArgs(this.Title, e.User.UserName, e.User.PassWord));
        this.SaveInfo();
        this.loginInfo.SaveXmlExprotConfiguration();
        this.Destroy();
      }
      else
        Application.Invoke((EventHandler) ((invokes, invokee) => MessageBox.Show(e.User.ErrorMsg, (Gtk.Window) this, (string) null, MessageBoxImage.Info)));
    }

    private void buttonCancel_Clicked(object sender, EventArgs e)
    {
      this.Destroy();
    }

    private void LoginDialog_WidgetEvent(object o, WidgetEventArgs args)
    {
      if (args.Event.Type != EventType.Delete)
        return;
      this.Destroy();
    }

    private void checkbutton_password_Clicked(object sender, EventArgs e)
    {
      if (this.checkbutton_password.Active)
        return;
      this.checkbutton_AutoLogin.Active = false;
    }

    private void checkbutton_AutoLogin_Clicked(object sender, EventArgs e)
    {
      if (!this.checkbutton_AutoLogin.Active)
        return;
      this.checkbutton_password.Active = true;
    }

    private void OnOpenWeb(object sender, LabelClickedEventArgs args)
    {
      try
      {
        using (Process.Start(args.LabelContent as string))
          ;
      }
      catch (Exception ex)
      {
        LogConfig.Output.Error((object) "Open web address failed.", ex);
      }
    }

    protected virtual void Build()
    {
      Gui.Initialize((Widget) this);
      this.HeightRequest = 175;
      this.Name = "CocoStudio.ControlLib.Windows.LoginDialog";
      this.WindowPosition = WindowPosition.CenterOnParent;
      VBox vbox = this.VBox;
      vbox.Name = "dialog1_VBox";
      vbox.BorderWidth = 2U;
      this.evtbx_border = new EventBox();
      this.evtbx_border.Name = "evtbx_border";
      this.evtbx_border.BorderWidth = 10U;
      this.table_main = new Table(4U, 2U, false);
      this.table_main.Name = "table_main";
      this.table_main.RowSpacing = 6U;
      this.table_main.ColumnSpacing = 6U;
      this.hbox_firstRow = new HBox();
      this.hbox_firstRow.Name = "hbox_firstRow";
      this.hbox_firstRow.Spacing = 6;
      this.entry_Name = new Entry();
      this.entry_Name.WidthRequest = 250;
      this.entry_Name.CanFocus = true;
      this.entry_Name.Name = "entry_Name";
      this.entry_Name.IsEditable = true;
      this.entry_Name.InvisibleChar = '●';
      this.hbox_firstRow.Add((Widget) this.entry_Name);
      Box.BoxChild boxChild1 = (Box.BoxChild) this.hbox_firstRow[(Widget) this.entry_Name];
      boxChild1.Position = 0;
      boxChild1.Expand = false;
      this.link_RegisterAccount = new LabelLink((string) null);
      this.link_RegisterAccount.Events = EventMask.ButtonPressMask;
      this.link_RegisterAccount.Name = "link_RegisterAccount";
      this.hbox_firstRow.Add((Widget) this.link_RegisterAccount);
      Box.BoxChild boxChild2 = (Box.BoxChild) this.hbox_firstRow[(Widget) this.link_RegisterAccount];
      boxChild2.Position = 1;
      boxChild2.Expand = false;
      boxChild2.Fill = false;
      this.table_main.Add((Widget) this.hbox_firstRow);
      Table.TableChild tableChild1 = (Table.TableChild) this.table_main[(Widget) this.hbox_firstRow];
      tableChild1.LeftAttach = 1U;
      tableChild1.RightAttach = 2U;
      tableChild1.XOptions = AttachOptions.Fill;
      tableChild1.YOptions = AttachOptions.Fill;
      this.hbox_fourthRow = new HBox();
      this.hbox_fourthRow.Name = "hbox_fourthRow";
      this.hbox_fourthRow.Spacing = 6;
      this.label_remark = new Label();
      this.label_remark.Name = "label_remark";
      this.label_remark.LabelProp = Catalog.GetString("(请使用CocoaChina账号登陆)");
      this.hbox_fourthRow.Add((Widget) this.label_remark);
      Box.BoxChild boxChild3 = (Box.BoxChild) this.hbox_fourthRow[(Widget) this.label_remark];
      boxChild3.Position = 0;
      boxChild3.Expand = false;
      boxChild3.Fill = false;
      this.table_main.Add((Widget) this.hbox_fourthRow);
      Table.TableChild tableChild2 = (Table.TableChild) this.table_main[(Widget) this.hbox_fourthRow];
      tableChild2.TopAttach = 3U;
      tableChild2.BottomAttach = 4U;
      tableChild2.LeftAttach = 1U;
      tableChild2.RightAttach = 2U;
      tableChild2.XOptions = AttachOptions.Fill;
      tableChild2.YOptions = AttachOptions.Fill;
      this.hbox_secondRow = new HBox();
      this.hbox_secondRow.Name = "hbox_secondRow";
      this.hbox_secondRow.Spacing = 6;
      this.entry_PassWord = new PassWordEntry();
      this.entry_PassWord.CanFocus = true;
      this.entry_PassWord.Name = "entry_PassWord";
      this.entry_PassWord.IsEditable = true;
      this.entry_PassWord.InvisibleChar = '●';
      this.hbox_secondRow.Add((Widget) this.entry_PassWord);
      ((Box.BoxChild) this.hbox_secondRow[(Widget) this.entry_PassWord]).Position = 0;
      this.link_ForgotPassword = new LabelLink((string) null);
      this.link_ForgotPassword.Events = EventMask.ButtonPressMask;
      this.link_ForgotPassword.Name = "link_ForgotPassword";
      this.hbox_secondRow.Add((Widget) this.link_ForgotPassword);
      Box.BoxChild boxChild4 = (Box.BoxChild) this.hbox_secondRow[(Widget) this.link_ForgotPassword];
      boxChild4.Position = 1;
      boxChild4.Expand = false;
      boxChild4.Fill = false;
      this.table_main.Add((Widget) this.hbox_secondRow);
      Table.TableChild tableChild3 = (Table.TableChild) this.table_main[(Widget) this.hbox_secondRow];
      tableChild3.TopAttach = 1U;
      tableChild3.BottomAttach = 2U;
      tableChild3.LeftAttach = 1U;
      tableChild3.RightAttach = 2U;
      tableChild3.XOptions = AttachOptions.Fill;
      tableChild3.YOptions = AttachOptions.Fill;
      this.hbox_thirdRow = new HBox();
      this.hbox_thirdRow.Name = "hbox_thirdRow";
      this.hbox_thirdRow.Spacing = 6;
      this.checkbutton_password = new CheckButton();
      this.checkbutton_password.CanFocus = true;
      this.checkbutton_password.Name = "checkbutton_password";
      this.checkbutton_password.Label = Catalog.GetString("记住密码");
      this.checkbutton_password.DrawIndicator = true;
      this.checkbutton_password.UseUnderline = true;
      this.hbox_thirdRow.Add((Widget) this.checkbutton_password);
      Box.BoxChild boxChild5 = (Box.BoxChild) this.hbox_thirdRow[(Widget) this.checkbutton_password];
      boxChild5.Position = 0;
      boxChild5.Expand = false;
      this.checkbutton_AutoLogin = new CheckButton();
      this.checkbutton_AutoLogin.CanFocus = true;
      this.checkbutton_AutoLogin.Name = "checkbutton_AutoLogin";
      this.checkbutton_AutoLogin.Label = Catalog.GetString("自动登陆");
      this.checkbutton_AutoLogin.DrawIndicator = true;
      this.checkbutton_AutoLogin.UseUnderline = true;
      this.hbox_thirdRow.Add((Widget) this.checkbutton_AutoLogin);
      Box.BoxChild boxChild6 = (Box.BoxChild) this.hbox_thirdRow[(Widget) this.checkbutton_AutoLogin];
      boxChild6.Position = 1;
      boxChild6.Expand = false;
      this.table_main.Add((Widget) this.hbox_thirdRow);
      Table.TableChild tableChild4 = (Table.TableChild) this.table_main[(Widget) this.hbox_thirdRow];
      tableChild4.TopAttach = 2U;
      tableChild4.BottomAttach = 3U;
      tableChild4.LeftAttach = 1U;
      tableChild4.RightAttach = 2U;
      tableChild4.XOptions = AttachOptions.Fill;
      tableChild4.YOptions = AttachOptions.Fill;
      this.label_Name = new Label();
      this.label_Name.Name = "label_Name";
      this.label_Name.Xalign = 1f;
      this.label_Name.LabelProp = Catalog.GetString("用户名");
      this.table_main.Add((Widget) this.label_Name);
      Table.TableChild tableChild5 = (Table.TableChild) this.table_main[(Widget) this.label_Name];
      tableChild5.XOptions = AttachOptions.Fill;
      tableChild5.YOptions = AttachOptions.Fill;
      this.label_PassWord = new Label();
      this.label_PassWord.Name = "label_PassWord";
      this.label_PassWord.Xalign = 1f;
      this.label_PassWord.LabelProp = Catalog.GetString("密码");
      this.table_main.Add((Widget) this.label_PassWord);
      Table.TableChild tableChild6 = (Table.TableChild) this.table_main[(Widget) this.label_PassWord];
      tableChild6.TopAttach = 1U;
      tableChild6.BottomAttach = 2U;
      tableChild6.XOptions = AttachOptions.Fill;
      tableChild6.YOptions = AttachOptions.Fill;
      this.evtbx_border.Add((Widget) this.table_main);
      vbox.Add((Widget) this.evtbx_border);
      Box.BoxChild boxChild7 = (Box.BoxChild) vbox[(Widget) this.evtbx_border];
      boxChild7.Position = 0;
      boxChild7.Expand = false;
      boxChild7.Fill = false;
      HButtonBox actionArea = this.ActionArea;
      actionArea.Name = "dialog1_ActionArea";
      actionArea.Spacing = 10;
      actionArea.BorderWidth = 5U;
      actionArea.LayoutStyle = ButtonBoxStyle.End;
      this.buttonCancel = new Button();
      this.buttonCancel.CanDefault = true;
      this.buttonCancel.CanFocus = true;
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.UseStock = true;
      this.buttonCancel.UseUnderline = true;
      this.buttonCancel.Label = "gtk-cancel";
      this.AddActionWidget((Widget) this.buttonCancel, -6);
      ButtonBox.ButtonBoxChild buttonBoxChild1 = (ButtonBox.ButtonBoxChild) actionArea[(Widget) this.buttonCancel];
      buttonBoxChild1.Expand = false;
      buttonBoxChild1.Fill = false;
      this.buttonOk = new Button();
      this.buttonOk.CanDefault = true;
      this.buttonOk.CanFocus = true;
      this.buttonOk.Name = "buttonOk";
      this.buttonOk.UseStock = true;
      this.buttonOk.UseUnderline = true;
      this.buttonOk.Label = "gtk-ok";
      this.AddActionWidget((Widget) this.buttonOk, -5);
      ButtonBox.ButtonBoxChild buttonBoxChild2 = (ButtonBox.ButtonBoxChild) actionArea[(Widget) this.buttonOk];
      buttonBoxChild2.Position = 1;
      buttonBoxChild2.Expand = false;
      buttonBoxChild2.Fill = false;
      if (this.Child != null)
        this.Child.ShowAll();
      this.DefaultWidth = 412;
      this.DefaultHeight = 191;
      this.Show();
    }
  }
}
