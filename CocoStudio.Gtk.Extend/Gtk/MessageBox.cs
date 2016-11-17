// Decompiled with JetBrains decompiler
// Type: Gtk.MessageBox
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using Modules.Communal.MultiLanguage;
using MonoDevelop.Core;
using System.Collections.Generic;
using System.Linq;

namespace Gtk
{
  public class MessageBox
  {
    public static void Show(string info, Window parentWnd = null, string title = null, MessageBoxImage image = MessageBoxImage.Info)
    {
      int num = (int) MessageBox.Show(info, MessageBoxButton.OK, parentWnd, title, image);
    }

    public static MessageBoxResult Show(string info, MessageBoxButton btnType, Window parentWnd = null, string title = null, MessageBoxImage image = MessageBoxImage.Info)
    {
      ButtonText btnText;
      switch (btnType)
      {
        case MessageBoxButton.OK:
          btnText = new ButtonText(LanguageInfo.Dialog_ButtonOK, MessageBoxButton.OK);
          break;
        case MessageBoxButton.Close:
          btnText = new ButtonText(LanguageInfo.Dialog_ButtonClose, MessageBoxButton.Close);
          break;
        case MessageBoxButton.YesNo:
          btnText = new ButtonText(LanguageInfo.Dialog_ButtonYes, LanguageInfo.Dialog_ButtonNo, MessageBoxButton.YesNo);
          break;
        case MessageBoxButton.OKCancel:
          btnText = new ButtonText(LanguageInfo.Dialog_ButtonOK, LanguageInfo.Dialog_ButtonCancel, MessageBoxButton.OKCancel);
          break;
        case MessageBoxButton.YesNoCancel:
          btnText = new ButtonText(LanguageInfo.Dialog_ButtonYes, LanguageInfo.Dialog_ButtonNo, LanguageInfo.Dialog_ButtonCancel);
          break;
        default:
          btnText = new ButtonText(LanguageInfo.Dialog_ButtonOK, MessageBoxButton.OK);
          break;
      }
      return MessageBox.Show(info, btnText, parentWnd, title, image);
    }

    public static MessageBoxResult Show(string info, ButtonText btnText, Window parentWnd = null, string title = null, MessageBoxImage image = MessageBoxImage.Info)
    {
      if (parentWnd == null)
        parentWnd = ApplicationCurrent.MainWindow;
      if (title == null)
        title = image != MessageBoxImage.Error ? (image != MessageBoxImage.Warning ? LanguageInfo.MessageBox_Notification : LanguageInfo.MessageBox_Warning) : LanguageInfo.MessageBox_Error;
      return MessageBox.ShowMessageBox(info, btnText, parentWnd, title, image);
    }

    private static MessageBoxResult ShowMessageBox(string info, ButtonText btnText, Window parentWnd, string title, MessageBoxImage image)
    {
      info = info.Replace("{", "&#123;").Replace("}", "&#125;");
      if (btnText.ButtonType == MessageBoxButton.YesNoCancel)
        return MessageBox.ShowDialogWithThreeButton(parentWnd, info, title, btnText);
      MessageDialog messageDialog = new MessageDialog(parentWnd, DialogFlags.Modal, (MessageType) image, (ButtonsType) btnText.ButtonType, info, new object[0]);
      messageDialog.SetToDialogStyle(parentWnd, true, true, true);
      messageDialog.Title = title;
      MessageBox.SetButtonText(messageDialog, btnText);
      int num = messageDialog.Run();
      messageDialog.Destroy();
      return (MessageBoxResult) num;
    }

    private static void SetButtonText(MessageDialog dialog, ButtonText btnText)
    {
      if (dialog == null)
        return;
      switch (btnText.ButtonType)
      {
        case MessageBoxButton.OK:
        case MessageBoxButton.Close:
          (((IEnumerable<Widget>) (((IEnumerable<Widget>) dialog.VBox.Children).ElementAt<Widget>(1) as Container).Children).ElementAt<Widget>(0) as Button).Label = btnText.OKText;
          break;
        case MessageBoxButton.YesNo:
        case MessageBoxButton.OKCancel:
          Container container = ((IEnumerable<Widget>) dialog.VBox.Children).ElementAt<Widget>(1) as Container;
          if (Platform.IsWindows)
          {
            (((IEnumerable<Widget>) container.Children).ElementAt<Widget>(0) as Button).Label = btnText.CancelText;
            (((IEnumerable<Widget>) container.Children).ElementAt<Widget>(1) as Button).Label = btnText.OKText;
            break;
          }
          if (!Platform.IsMac)
            break;
          (((IEnumerable<Widget>) container.Children).ElementAt<Widget>(0) as Button).Label = btnText.OKText;
          (((IEnumerable<Widget>) container.Children).ElementAt<Widget>(1) as Button).Label = btnText.CancelText;
          break;
      }
    }

    private static MessageBoxResult ShowDialogWithThreeButton(Window parentWindow, string info, string title, ButtonText btnTxt)
    {
      MessageBoxDialog messageBoxDialog = new MessageBoxDialog(parentWindow, info, btnTxt);
      messageBoxDialog.Title = title;
      int num = messageBoxDialog.Run();
      messageBoxDialog.Destroy();
      if (num == -4)
        num = -6;
      return (MessageBoxResult) num;
    }
  }
}
