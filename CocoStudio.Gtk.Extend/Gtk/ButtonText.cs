// Decompiled with JetBrains decompiler
// Type: Gtk.ButtonText
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

namespace Gtk
{
  public class ButtonText
  {
    public MessageBoxButton ButtonType { get; private set; }

    public string OKText { get; private set; }

    public string CancelText { get; private set; }

    public string NoText { get; private set; }

    public ButtonText(string okText, MessageBoxButton buttonType = MessageBoxButton.OK)
    {
      if (buttonType != MessageBoxButton.Close)
        buttonType = MessageBoxButton.OK;
      this.ButtonType = buttonType;
      this.OKText = string.Empty;
      this.NoText = string.Empty;
      this.CancelText = string.Empty;
      if (string.IsNullOrEmpty(okText))
        return;
      this.OKText = okText;
    }

    public ButtonText(string okText, string cancelText, MessageBoxButton buttonType = MessageBoxButton.OKCancel)
    {
      if (buttonType != MessageBoxButton.YesNo)
        buttonType = MessageBoxButton.OKCancel;
      this.ButtonType = buttonType;
      this.OKText = string.Empty;
      this.NoText = string.Empty;
      this.CancelText = string.Empty;
      if (!string.IsNullOrEmpty(okText))
        this.OKText = okText;
      if (string.IsNullOrEmpty(cancelText))
        return;
      this.CancelText = cancelText;
    }

    public ButtonText(string yesText, string noText, string cancelText)
    {
      this.ButtonType = MessageBoxButton.YesNoCancel;
      this.OKText = string.Empty;
      this.NoText = string.Empty;
      this.CancelText = string.Empty;
      if (!string.IsNullOrEmpty(yesText))
        this.OKText = yesText;
      if (!string.IsNullOrEmpty(noText))
        this.NoText = noText;
      if (string.IsNullOrEmpty(cancelText))
        return;
      this.CancelText = cancelText;
    }
  }
}
