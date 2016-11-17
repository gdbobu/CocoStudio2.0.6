// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.GeneralTitle
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using Gtk;
using Modules.Communal.MultiLanguage;
using MonoDevelop.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace CocoStudio.ToolKit
{
  public class GeneralTitle
  {
    public HBox hBox = new HBox();
    private EditorManager contentEM;
    private ImageView _imageWidget;
    private Table labelTable;

    public Table TitleTable { get; set; }

    private Table ThirdTable { get; set; }

    public GeneralTitle(EditorManager em)
    {
      this.contentEM = em;
      this.hBox = new HBox();
      this._imageWidget = new ImageView();
      this.TitleTable = new Table(1U, 1U, false);
      Table table = new Table(2U, 1U, false);
      table.Attach((Widget) this._imageWidget, 0U, 1U, 0U, 1U, AttachOptions.Shrink, AttachOptions.Fill, 0U, 0U);
      this._imageWidget.Show();
      this.labelTable = new Table(2U, 1U, false);
      table.RowSpacing = 6U;
      table.Attach((Widget) this.labelTable, 0U, 1U, 1U, 2U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.labelTable.Show();
      table.Show();
      table.WidthRequest = 38;
      Alignment alignment1 = new Alignment(0.5f, 0.5f, 1f, 1f);
      alignment1.LeftPadding = 15U;
      alignment1.TopPadding = 15U;
      alignment1.RightPadding = 15U;
      alignment1.Add((Widget) table);
      alignment1.ShowAll();
      this.hBox.Add((Widget) alignment1);
      Box.BoxChild boxChild1 = this.hBox[(Widget) alignment1] as Box.BoxChild;
      boxChild1.Position = 0;
      boxChild1.Expand = false;
      boxChild1.Fill = false;
      VSeparator vseparator = new VSeparator();
      Alignment alignment2 = new Alignment(0.5f, 0.5f, 1f, 1f);
      alignment2.LeftPadding = 8U;
      alignment2.TopPadding = 8U;
      alignment2.BottomPadding = 8U;
      alignment2.Add((Widget) vseparator);
      alignment2.ShowAll();
      vseparator.Show();
      this.hBox.Add((Widget) alignment2);
      Box.BoxChild boxChild2 = this.hBox[(Widget) alignment2] as Box.BoxChild;
      boxChild2.Position = 1;
      boxChild2.Expand = false;
      boxChild2.Fill = false;
      this.ThirdTable = new Table(2U, 2U, false);
      this.ThirdTable.RowSpacing = 16U;
      this.ThirdTable.ColumnSpacing = 10U;
      Alignment alignment3 = new Alignment(0.5f, 0.5f, 1f, 1f);
      alignment3.LeftPadding = 1U;
      alignment3.TopPadding = 16U;
      alignment3.BottomPadding = 16U;
      alignment3.RightPadding = 30U;
      alignment3.Add((Widget) this.ThirdTable);
      alignment3.ShowAll();
      this.ThirdTable.Show();
      this.hBox.Add((Widget) alignment3);
      Box.BoxChild boxChild3 = this.hBox[(Widget) this.ThirdTable] as Box.BoxChild;
      boxChild3.Position = 2;
      boxChild3.Expand = true;
      boxChild3.Fill = true;
      this.hBox.ShowAll();
    }

    public void SetImage(object current, int num = 1, string rootType = "")
    {
      string str1 = string.Empty;
      if (current != null)
        str1 = current.GetType().Name;
      if (string.IsNullOrEmpty(str1))
        str1 = "MultiObject";
      this._imageWidget.Image = ImageIcon.GetIcon("CocoStudio.DefaultResource.ComponentResource." + str1.Substring(0, str1.Length - 6) + ".png");
      this._imageWidget.ShowAll();
      if (num > 1)
      {
        Label label = new Label();
        this.labelTable.Attach((Widget) label, 0U, 1U, 0U, 1U, AttachOptions.Expand, AttachOptions.Fill, 0U, 0U);
        label.Show();
        label.Text = string.Format("{0}{1}", (object) num, (object) LanguageInfo.ImageText);
      }
      else
      {
        foreach (object customAttribute in current.GetType().GetCustomAttributes(false))
        {
          if (customAttribute is DisplayNameAttribute)
          {
            string str2 = LanguageOption.GetValueBykey((customAttribute as DisplayNameAttribute).DisplayName);
            if (!string.IsNullOrEmpty(rootType))
              str2 = rootType;
            if (str2.Length > 8)
            {
              Label label1 = new Label();
              Label label2 = new Label();
              this.labelTable.Attach((Widget) label1, 0U, 1U, 0U, 1U, AttachOptions.Expand, AttachOptions.Fill, 0U, 0U);
              this.labelTable.Attach((Widget) label2, 0U, 1U, 1U, 2U, AttachOptions.Expand, AttachOptions.Fill, 0U, 0U);
              label1.Show();
              label2.Show();
              int num1 = 0;
              for (int index = 1; index < str2.Length; ++index)
              {
                if ((int) str2[index] >= 65 && (int) str2[index] <= 90)
                {
                  num1 = index;
                  break;
                }
              }
              label1.Text = str2.Substring(0, num1);
              label2.Text = str2.Substring(num1, str2.Length - num1);
              break;
            }
            Label label = new Label();
            this.labelTable.Attach((Widget) label, 0U, 1U, 0U, 1U, AttachOptions.Expand, AttachOptions.Fill, 0U, 0U);
            label.Show();
            label.Text = str2;
            break;
          }
        }
      }
    }

    public void SetControl(List<PropertyItem> list)
    {
      foreach (Widget child in this.ThirdTable.Children)
        this.ThirdTable.Remove(child);
      if (list.FirstOrDefault<PropertyItem>((Func<PropertyItem, bool>) (w => w.DiaplayName == "Display_Name")) != null)
      {
        ContentLabel contentLabel = new ContentLabel(68);
        contentLabel.SetLabelText(LanguageOption.GetValueBykey(list[0].DiaplayName));
        this.ThirdTable.Attach((Widget) contentLabel, 0U, 1U, 0U, 1U, AttachOptions.Shrink, AttachOptions.Fill, 0U, 0U);
        this.contentEM.GetEditor(list[0]);
        Widget widgetDate = list[0].WidgetDate;
        widgetDate.WidthRequest = 162;
        this.ThirdTable.Attach(widgetDate, 1U, 2U, 0U, 1U, AttachOptions.Expand | AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      }
      PropertyItem propertyItem = list.FirstOrDefault<PropertyItem>((Func<PropertyItem, bool>) (w => w.DiaplayName == "Display_Target"));
      if (propertyItem != null)
      {
        ContentLabel contentLabel = new ContentLabel(68);
        contentLabel.SetLabelText(LanguageOption.GetValueBykey(list[1].DiaplayName));
        this.ThirdTable.Attach((Widget) contentLabel, 0U, 1U, 1U, 2U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
        UndoEntryIntEx undoEntryIntEx = this.contentEM.GetEditor(list[1]).ResolveEditor(propertyItem) as UndoEntryIntEx;
        undoEntryIntEx.SetEntryPRoperty(true, 0, 1.0);
        undoEntryIntEx.WidthRequest = 162;
        this.ThirdTable.Attach((Widget) undoEntryIntEx, 1U, 2U, 1U, 2U, AttachOptions.Expand | AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      }
      this.ThirdTable.ShowAll();
    }
  }
}
