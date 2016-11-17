// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.ResourceChangedFactory
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using CocoStudio.Model;
using System;
using System.Collections.Generic;

namespace CocoStudio.Projects
{
  internal class ResourceChangedFactory
  {
    private static readonly ResourceChangedSenderEmpty defaultEmptySender = new ResourceChangedSenderEmpty();
    private static Dictionary<ResourceItem, ResourceChangedSender> senderCollection = new Dictionary<ResourceItem, ResourceChangedSender>();

    public static ResourceChangedSender GetSender(ResourceItem resourceFile, bool isDeleted = false, ResourceData oldResourceData = null)
    {
      if (ResourceChangedFactory.senderCollection.ContainsKey(resourceFile))
        return (ResourceChangedSender) ResourceChangedFactory.defaultEmptySender;
      ResourceChangedSender resourceChangedSender = new ResourceChangedSender(resourceFile, isDeleted, oldResourceData);
      ResourceChangedFactory.senderCollection[resourceFile] = resourceChangedSender;
      resourceChangedSender.Disposed += new Action<ResourceChangedSender, ResourceItem>(ResourceChangedFactory.Sender_Disposed);
      return resourceChangedSender;
    }

    private static void Sender_Disposed(ResourceChangedSender obj, ResourceItem e)
    {
      obj.Disposed -= new Action<ResourceChangedSender, ResourceItem>(ResourceChangedFactory.Sender_Disposed);
      ResourceChangedFactory.senderCollection.Remove(e);
    }
  }
}
