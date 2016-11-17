// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.FilpEditorWidget
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using Gtk;
using Modules.Communal.MultiLanguage;
using System;
using System.ComponentModel;

namespace CocoStudio.ToolKit
{
  [ToolboxItem(true)]
  public class FilpEditorWidget : BaseEditorWidget
  {
    private bool boolS = false;
    private bool boolV = false;
    private Alignment alignment1;
    private Table table1;
    private ToggleButtonImage btnS;
    private ToggleButtonImage btnV;

    public event EventHandler<BtnEvent> BtnVClick;

    public event EventHandler<BtnEvent> BtnSClick;

    public FilpEditorWidget()
    {
      this.alignment1 = new Alignment(0.5f, 0.5f, 1f, 1f);
      this.alignment1.Name = "alignment1";
      this.table1 = new Table(1U, 2U, false);
      this.table1.Name = "table1";
      this.table1.ColumnSpacing = 6U;
      this.btnS = new ToggleButtonImage();
      this.btnS.CheckedImage = ImageIcon.GetIcon("CocoStudio.DefaultResource.EditorResource.horizontalFilp.png");
      this.btnS.UnCheckedImage = ImageIcon.GetIcon("CocoStudio.DefaultResource.EditorResource.horizontalFilp.png");
      this.btnS.CanFocus = true;
      this.btnS.Name = "btnS";
      this.btnS.SetSizeRequest(22, 22);
      this.table1.Add((Widget) this.btnS);
      Table.TableChild tableChild1 = (Table.TableChild) this.table1[(Widget) this.btnS];
      tableChild1.XOptions = AttachOptions.Fill;
      tableChild1.YOptions = AttachOptions.Fill;
      this.btnV = new ToggleButtonImage();
      this.btnV.CheckedImage = ImageIcon.GetIcon("CocoStudio.DefaultResource.EditorResource.verticalFilp.png");
      this.btnV.UnCheckedImage = ImageIcon.GetIcon("CocoStudio.DefaultResource.EditorResource.verticalFilp.png");
      this.btnV.CanFocus = true;
      this.btnV.Name = "btnV";
      this.btnV.SetSizeRequest(22, 22);
      this.table1.Add((Widget) this.btnV);
      Table.TableChild tableChild2 = (Table.TableChild) this.table1[(Widget) this.btnV];
      tableChild2.LeftAttach = 1U;
      tableChild2.RightAttach = 2U;
      tableChild2.XOptions = AttachOptions.Fill;
      tableChild2.YOptions = AttachOptions.Fill;
      this.alignment1.Add((Widget) this.table1);
      this.Add((Widget) this.alignment1);
      if (this.Child != null)
        this.Child.ShowAll();
      this.Hide();
      this.ReadLanuageConfigFile();
      this.btnS.CheckChanged += new EventHandler(this.btnS_Clicked);
      this.btnV.CheckChanged += new EventHandler(this.btnV_Clicked);
    }

    private void btnV_Clicked(object sender, EventArgs e)
    {
      this.boolV = !this.boolV;
      if (this.BtnVClick == null)
        return;
      this.RaiseValueChanged((object) null, (System.Action) (() => this.BtnVClick((object) null, new BtnEvent(this.boolV))));
    }

    private void btnS_Clicked(object sender, EventArgs e)
    {
      this.boolS = !this.boolS;
      if (this.BtnSClick == null)
        return;
      this.RaiseValueChanged((object) null, (System.Action) (() => this.BtnSClick((object) null, new BtnEvent(this.boolS))));
    }

    public void SetControl(bool v, bool s)
    {
      this.btnV.SetActive(v);
      this.btnS.SetActive(s);
    }

    public override void ReadLanuageConfigFile()
    {
      this.btnS.TooltipText = LanguageInfo.Display_HFlip;
      this.btnV.TooltipText = LanguageInfo.Display_VFlip;
    }
  }
}
