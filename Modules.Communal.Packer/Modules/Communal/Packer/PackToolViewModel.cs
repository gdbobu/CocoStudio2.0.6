// Decompiled with JetBrains decompiler
// Type: Modules.Communal.Packer.PackToolViewModel
// Assembly: Modules.Communal.Packer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C7209B7C-6A4B-4239-96DC-96EFD0A7660A
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.Packer.dll

using CocoStudio.Basic;
using CocoStudio.ControlLib;
using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace Modules.Communal.Packer
{
  public class PackToolViewModel
  {
    private static string ExprotConfigFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Cocos Studio", "Export");
    private string UIExprotConfigPath = Path.Combine(PackToolViewModel.ExprotConfigFolder, "UIExport.config");
    private string AnimationExprotConfigPath = Path.Combine(PackToolViewModel.ExprotConfigFolder, "AnimationExport.config");
    private string ConfigPath = string.Empty;
    public static PackToolViewModel Instance;
    private int maxSourceWidth;
    private int maxSourceHeight;
    private int paddingPixel;
    private SortFormat sortForm;
    private bool cilp;
    private string exprotPath;
    private string exportJsonPath;
    private ImageFileFormat imageForm;
    private EnumEditorIDE enumEditorID;
    private int exprotCanvas;
    private int exprotResouces;
    private float resourceScale;
    private bool formatExport;
    private bool binaryExport;

    public int MaxSourceWidth
    {
      get
      {
        return this.maxSourceWidth;
      }
      set
      {
        this.maxSourceWidth = value;
      }
    }

    public int MaxSourceHeight
    {
      get
      {
        return this.maxSourceHeight;
      }
      set
      {
        this.maxSourceHeight = value;
      }
    }

    public int PaddingPixel
    {
      get
      {
        return this.paddingPixel;
      }
      set
      {
        this.paddingPixel = value;
      }
    }

    public SortFormat SortForm
    {
      get
      {
        return this.sortForm;
      }
      set
      {
        this.sortForm = value;
      }
    }

    public bool Cilp
    {
      get
      {
        return this.cilp;
      }
      set
      {
        this.cilp = value;
      }
    }

    public string ExprotPath
    {
      get
      {
        return this.exprotPath;
      }
      set
      {
        this.exprotPath = value;
      }
    }

    public string ExportJsonPath
    {
      get
      {
        return this.exportJsonPath;
      }
      set
      {
        this.exportJsonPath = value;
      }
    }

    public ImageFileFormat ImageForm
    {
      get
      {
        return this.imageForm;
      }
      set
      {
        this.imageForm = value;
      }
    }

    public EnumEditorIDE EnumEditorID
    {
      get
      {
        return this.enumEditorID;
      }
      set
      {
        this.enumEditorID = value;
      }
    }

    public int ExprotCanvas
    {
      get
      {
        return this.exprotCanvas;
      }
      set
      {
        this.exprotCanvas = value;
      }
    }

    public int ExprotResouces
    {
      get
      {
        return this.exprotResouces;
      }
      set
      {
        this.exprotResouces = value;
      }
    }

    public float ResourceScale
    {
      get
      {
        return this.resourceScale;
      }
      set
      {
        this.resourceScale = value;
      }
    }

    public bool FormatExport
    {
      get
      {
        return this.formatExport;
      }
      set
      {
        this.formatExport = value;
      }
    }

    public bool ISExportBinaryJson
    {
      get
      {
        return this.binaryExport;
      }
      set
      {
        this.binaryExport = value;
      }
    }

    public PackToolViewModel()
    {
      this.EnumEditorID = Option.CurrentEditorIDE;
      PackToolViewModel.Instance = this;
      this.ConfigInit();
    }

    private void ConfigInit()
    {
      this.ConfigPath = this.EnumEditorID == EnumEditorIDE.Animation ? this.AnimationExprotConfigPath : this.UIExprotConfigPath;
      if (File.Exists(this.ConfigPath))
      {
        try
        {
          XmlNode node1 = XmlAnalysis.GetNode((XmlNode) XmlAnalysis.ReaderXmlFile(this.ConfigPath), "ExprotConfig");
          this.MaxSourceWidth = int.Parse(XmlAnalysis.GetNode(node1, "MaxSourceWidth").InnerText);
          this.MaxSourceHeight = int.Parse(XmlAnalysis.GetNode(node1, "MaxSourceHeight").InnerText);
          this.PaddingPixel = int.Parse(XmlAnalysis.GetNode(node1, "PaddingPixel").InnerText);
          this.Cilp = Convert.ToBoolean(XmlAnalysis.GetNode(node1, "Cilp").InnerText);
          this.SortForm = (SortFormat) Enum.Parse(typeof (SortFormat), XmlAnalysis.GetNode(node1, "SortForm").InnerText);
          this.ImageForm = (ImageFileFormat) Enum.Parse(typeof (ImageFileFormat), XmlAnalysis.GetNode(node1, "ImageForm").InnerText);
          this.ExprotPath = XmlAnalysis.GetNode(node1, "ExprotPath").InnerText;
          this.ExportJsonPath = XmlAnalysis.GetNode(node1, "ExportJsonPath").InnerText;
          this.ExprotResouces = int.Parse(XmlAnalysis.GetNode(node1, "ExprotResouces").InnerText);
          this.ExprotCanvas = int.Parse(XmlAnalysis.GetNode(node1, "ExprotCanvas").InnerText);
          this.ResourceScale = float.Parse(XmlAnalysis.GetNode(node1, "ResourceScale").InnerText);
          XmlNode node2 = XmlAnalysis.GetNode(node1, "FormatExport");
          this.FormatExport = node2 != null && Convert.ToBoolean(node2.InnerText);
        }
        catch (Exception )
        {
          this.Init();
          File.Delete(this.ConfigPath);
        }
      }
      else
        this.Init();
    }

    private void Init()
    {
      this.MaxSourceWidth = 1024;
      this.MaxSourceHeight = 1024;
      this.PaddingPixel = 2;
      this.Cilp = false;
      this.ExprotPath = string.Empty;
      this.ExportJsonPath = string.Empty;
      this.ImageForm = ImageFileFormat.Png;
      this.SortForm = SortFormat.Sample;
      this.ExprotCanvas = 1;
      this.ExprotResouces = this.EnumEditorID == EnumEditorIDE.Ui ? 1 : 2;
      this.ResourceScale = 1f;
      this.FormatExport = true;
    }

    public void SaveXmlExprotConfiguration()
    {
      if (!Directory.Exists(PackToolViewModel.ExprotConfigFolder))
        Directory.CreateDirectory(PackToolViewModel.ExprotConfigFolder);
      try
      {
        if (File.Exists(this.ConfigPath))
          File.Delete(this.ConfigPath);
        new XDocument(new object[1]
        {
          (object) new XElement((XName) "ExprotConfig", new object[12]
          {
            (object) new XElement((XName) "MaxSourceWidth", (object) this.MaxSourceWidth),
            (object) new XElement((XName) "MaxSourceHeight", (object) this.MaxSourceHeight),
            (object) new XElement((XName) "PaddingPixel", (object) this.PaddingPixel),
            (object) new XElement((XName) "Cilp", (object) this.Cilp),
            (object) new XElement((XName) "ImageForm", (object) this.ImageForm),
            (object) new XElement((XName) "SortForm", (object) this.SortForm),
            (object) new XElement((XName) "ExprotPath", (object) this.ExprotPath),
            (object) new XElement((XName) "ExportJsonPath", (object) this.ExportJsonPath),
            (object) new XElement((XName) "ExprotCanvas", (object) this.ExprotCanvas),
            (object) new XElement((XName) "ExprotResouces", (object) this.ExprotResouces),
            (object) new XElement((XName) "ResourceScale", (object) this.ResourceScale),
            (object) new XElement((XName) "FormatExport", (object) this.FormatExport)
          })
        }).Save(this.ConfigPath);
      }
      catch (Exception )
      {
      }
    }
  }
}
