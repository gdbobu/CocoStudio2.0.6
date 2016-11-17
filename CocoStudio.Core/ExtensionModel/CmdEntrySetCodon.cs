// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.ExtensionModel.CmdEntrySetCodon
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using Modules.Communal.MultiLanguage;
using Mono.Addins;
using MonoDevelop.Components.Commands;
using MonoDevelop.Components.Commands.ExtensionNodes;
using MonoDevelop.Core;
using System;

namespace CocoStudio.Core.ExtensionModel
{
  [ExtensionNode(Description = "修改自Mono中的ItemSetCodon，修改了一个属性的名称，并添加多语言支持")]
  internal class CmdEntrySetCodon : InstanceExtensionNode
  {
    [NodeAttribute("macLabel", "Mac平台下的显示文本")]
    private string macLabel = (string) null;
    [NodeAttribute("label", "Label of the submenu", Localizable = true)]
    private string label;
    [NodeAttribute("icon", "Icon of the submenu. The provided value must be a registered stock icon. A resource icon can also be specified using 'res:' as prefix for the name, for example: 'res:customIcon.png'")]
    private string icon;
    [NodeAttribute("autohide", "Whether the submenu should be hidden when it contains no items.")]
    private bool autohide;

    public override object CreateInstance()
    {
      if (Platform.IsMac && this.macLabel != null)
        this.label = LanguageOption.GetValueBykey(this.macLabel);
      if (this.label == null)
        this.label = this.Id;
      this.label = LanguageOption.GetValueBykey(this.label);
      this.label = StringParserService.Parse(this.label);
      if (this.icon != null)
        this.icon = CommandCodon.GetStockId(this.Addin, this.icon);
      CommandEntrySet commandEntrySet = new CommandEntrySet(this.label, (IconId) this.icon);
      commandEntrySet.CommandId = (object) this.Id;
      commandEntrySet.AutoHide = this.autohide;
      foreach (InstanceExtensionNode childNode in this.ChildNodes)
      {
        CommandEntry instance = childNode.CreateInstance() as CommandEntry;
        if (instance == null)
          throw new InvalidOperationException("Invalid ItemSet child: " + (object) childNode);
        commandEntrySet.Add(instance);
      }
      return (object) commandEntrySet;
    }
  }
}
