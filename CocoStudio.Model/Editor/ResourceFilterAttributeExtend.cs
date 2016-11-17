// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Editor.ResourceFilterAttributeExtend
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Projects;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CocoStudio.Model.Editor
{
  internal static class ResourceFilterAttributeExtend
  {
    public static bool CheckResource(this ResourceFilterAttribute attribute, ResourceFile resourceFile)
    {
      if (resourceFile == null)
        return false;
      ResourceData resourceData = resourceFile.GetResourceData();
      if (attribute.ResourceTypeFilter != null && !((IEnumerable<EnumResourceType>) attribute.ResourceTypeFilter).Contains<EnumResourceType>(resourceData.Type))
        return false;
      string str = Path.GetExtension(resourceData.Path);
      if (str.Length > 1)
        str = str.Substring(1);
      return ((IEnumerable<string>) attribute.FileFilter).Contains<string>(str);
    }
  }
}
