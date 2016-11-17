// Decompiled with JetBrains decompiler
// Type: Gtk.ColorPickerDialog
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using Gdk;
using Modules.Communal.MultiLanguage;
using Mono.Unix;
using MonoDevelop.Core;
using Stetic;
using System.Collections.Generic;

namespace Gtk
{
  public class ColorPickerDialog : Dialog
  {
    private Dictionary<string, string> InfoDictionary;
    private EventBox eventbox_bg;
    private Button buttonCancel;
    private Button buttonOk;

    public ColorSelection ColorPicker { get; private set; }

    public ColorPickerDialog(Color initColor)
    {
      this.Build();
      this.buttonOk.Name = "MainButton";
      this.buttonOk.HasFocus = true;
      this.SetToDialogStyle((Window) null, true, true, true);
      if (Platform.IsWindows)
      {
        HButtonBox actionArea = this.ActionArea;
        ButtonBox.ButtonBoxChild buttonBoxChild1 = (ButtonBox.ButtonBoxChild) actionArea[(Widget) this.buttonOk];
        ButtonBox.ButtonBoxChild buttonBoxChild2 = (ButtonBox.ButtonBoxChild) actionArea[(Widget) this.buttonCancel];
        buttonBoxChild1.Position = 0;
        buttonBoxChild2.Position = 1;
      }
      this.ColorPicker = new ColorSelection();
      this.ColorPicker.PreviousColor = initColor;
      this.ColorPicker.CurrentColor = initColor;
      this.ColorPicker.HasOpacityControl = false;
      this.eventbox_bg.Add((Widget) this.ColorPicker);
      this.ColorPicker.ShowAll();
      this.InitKeys();
      this.InitMultiLanguage();
    }

    private void InitKeys()
    {
      this.InfoDictionary = new Dictionary<string, string>();
      if (LanguageOption.CurrentLanguage == LanguageType.Chinese)
      {
        this.InfoDictionary.Add("Color _name:", "颜色名称(_N)：");
        this.InfoDictionary.Add("Op_acity:", "透明度(_A)：");
        this.InfoDictionary.Add("_Blue:", "蓝(_B)：");
        this.InfoDictionary.Add("_Green:", "绿(_G)：");
        this.InfoDictionary.Add("_Red:", "红(_R)：");
        this.InfoDictionary.Add("_Value:", "值(_V)：");
        this.InfoDictionary.Add("_Saturation:", "饱和度(_S)：");
        this.InfoDictionary.Add("_Hue:", "色调(_H)：");
        this.InfoDictionary.Add("_Palette:", "调色板(_P)：");
        this.InfoDictionary.Add("Select the color you want from the outer ring. Select the darkness or lightness of that color using the inner triangle.", "在外围环中选择您要的颜色。在内部三角形中选择该颜色的明暗度。");
        this.InfoDictionary.Add("The previously-selected color, for comparison to the color you're selecting now.", "之前选择的颜色，用来与您正在选的颜色作比对。");
        this.InfoDictionary.Add("The color you've chosen.", "您所选择的颜色。");
        this.InfoDictionary.Add("Click the eyedropper, then click a color anywhere on your screen to select that color.", "单击滴管，然后点屏幕任何一处来选取该位置的颜色。");
        this.InfoDictionary.Add("You can enter an HTML-style hexadecimal color value, or simply a color name such as 'orange' in this entry.", "您可以在此栏输入 HTML 风格的十六进制颜色值，或是像“orange”这样的颜色名称。");
        this.InfoDictionary.Add("Transparency of the color.", "颜色的透明度。");
        this.InfoDictionary.Add("Amount of blue light in the color.", "颜色中的蓝色分量。");
        this.InfoDictionary.Add("Amount of green light in the color.", "颜色中的绿色分量。");
        this.InfoDictionary.Add("Amount of red light in the color.", "颜色中的红色分量。");
        this.InfoDictionary.Add("Brightness of the color.", "颜色的亮度。");
        this.InfoDictionary.Add("\"Deepness\" of the color.", "颜色的“深度”。");
        this.InfoDictionary.Add("Position on the color wheel.", "在色相环中的位置。");
        this.InfoDictionary.Add("Click this palette entry to make it the current color. To change this entry, drag a color swatch here or right-click it and select \"Save color here.\"", "单击此调色板项可以将其变为当前颜色。要更改此项，请将颜色拖曳到此处，或者用鼠标右键单击之，然后选择“在此保存颜色”。");
      }
      else
      {
        if (LanguageOption.CurrentLanguage != LanguageType.English)
          return;
        this.InfoDictionary.Add("颜色名称(_N)：", "Color _name:");
        this.InfoDictionary.Add("透明度(_A)：", "Op_acity:");
        this.InfoDictionary.Add("蓝(_B)：", "_Blue:");
        this.InfoDictionary.Add("绿(_G)：", "_Green:");
        this.InfoDictionary.Add("红(_R)：", "_Red:");
        this.InfoDictionary.Add("值(_V)：", "_Value:");
        this.InfoDictionary.Add("饱和度(_S)：", "_Saturation:");
        this.InfoDictionary.Add("色调(_H)：", "_Hue:");
        this.InfoDictionary.Add("调色板(_P)：", "_Palette:");
        this.InfoDictionary.Add("在外围环中选择您要的颜色。在内部三角形中选择该颜色的明暗度。", "Select the color you want from the outer ring. Select the darkness or lightness of that color using the inner triangle.");
        this.InfoDictionary.Add("之前选择的颜色，用来与您正在选的颜色作比对。", "The previously-selected color, for comparison to the color you're selecting now.");
        this.InfoDictionary.Add("您所选择的颜色。", "The color you've chosen.");
        this.InfoDictionary.Add("单击滴管，然后点屏幕任何一处来选取该位置的颜色。", "Click the eyedropper, then click a color anywhere on your screen to select that color.");
        this.InfoDictionary.Add("您可以在此栏输入 HTML 风格的十六进制颜色值，或是像“orange”这样的颜色名称。", "You can enter an HTML-style hexadecimal color value, or simply a color name such as 'orange' in this entry.");
        this.InfoDictionary.Add("颜色的透明度。", "Transparency of the color.");
        this.InfoDictionary.Add("颜色中的蓝色分量。", "Amount of blue light in the color.");
        this.InfoDictionary.Add("颜色中的绿色分量。", "Amount of green light in the color.");
        this.InfoDictionary.Add("颜色中的红色分量。", "Amount of red light in the color.");
        this.InfoDictionary.Add("颜色的亮度。", "Brightness of the color.");
        this.InfoDictionary.Add("颜色的“深度”。", "\"Deepness\" of the color.");
        this.InfoDictionary.Add("在色相环中的位置。", "Position on the color wheel.");
        this.InfoDictionary.Add("单击此调色板项可以将其变为当前颜色。要更改此项，请将颜色拖曳到此处，或者用鼠标右键单击之，然后选择“在此保存颜色”。", "Click this palette entry to make it the current color. To change this entry, drag a color swatch here or right-click it and select \"Save color here.\"");
      }
    }

    private void InitMultiLanguage()
    {
      this.Title = LanguageInfo.Property_ColorPicker;
      this.buttonOk.Label = LanguageInfo.Dialog_ButtonOK;
      this.buttonCancel.Label = LanguageInfo.Dialog_ButtonCancel;
      List<Widget> allChildren = this.GetAllChildren((Container) this.ColorPicker);
      List<Label> labelList = new List<Label>();
      List<Widget> widgetList = new List<Widget>();
      Button button = (Button) null;
      foreach (Widget widget in allChildren)
      {
        if (widget is Label)
          labelList.Add(widget as Label);
        if (!string.IsNullOrEmpty(widget.TooltipText))
          widgetList.Add(widget);
        if (widget.Name.Equals("GtkButton"))
          button = widget as Button;
      }
      if (Platform.IsMac && button != null)
        (button.Parent as Container).Remove((Widget) button);
      string str;
      foreach (Label label in labelList)
      {
        this.InfoDictionary.TryGetValue(label.LabelProp, out str);
        if (!string.IsNullOrEmpty(str))
          label.LabelProp = str;
      }
      foreach (Widget widget in widgetList)
      {
        this.InfoDictionary.TryGetValue(widget.TooltipText, out str);
        if (!string.IsNullOrEmpty(str))
          widget.TooltipText = str;
      }
    }

    private List<Widget> GetAllChildren(Container con)
    {
      List<Widget> widgetList = new List<Widget>();
      widgetList.Add((Widget) con);
      Widget[] children = con.Children;
      if (children != null)
      {
        foreach (Widget widget in children)
        {
          if (widget is Container)
          {
            foreach (Widget allChild in this.GetAllChildren(widget as Container))
              widgetList.Add(allChild);
          }
          else
            widgetList.Add(widget);
        }
      }
      return widgetList;
    }

    protected virtual void Build()
    {
      Gui.Initialize((Widget) this);
      this.Name = "Gtk.ColorPickerDialog";
      this.Title = Catalog.GetString("dialog1");
      this.WindowPosition = WindowPosition.CenterOnParent;
      this.Resizable = false;
      VBox vbox = this.VBox;
      vbox.Name = "dialog1_VBox";
      vbox.BorderWidth = 2U;
      this.eventbox_bg = new EventBox();
      this.eventbox_bg.Name = "eventbox_bg";
      this.eventbox_bg.BorderWidth = 12U;
      vbox.Add((Widget) this.eventbox_bg);
      ((Box.BoxChild) vbox[(Widget) this.eventbox_bg]).Position = 0;
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
      this.DefaultWidth = 535;
      this.DefaultHeight = 294;
      this.Show();
    }
  }
}
