// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.ModelObject
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace CocoStudio.Model.ViewModel
{
  public abstract class ModelObject : BaseObject, IResourceObject
  {
    private Dictionary<string, ResourceFile> resourceCollection;
    private bool isSettingValue;

    private Dictionary<string, ResourceFile> ResourceCollection
    {
      get
      {
        if (this.resourceCollection == null)
          this.resourceCollection = new Dictionary<string, ResourceFile>();
        return this.resourceCollection;
      }
    }

    protected override void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression, bool isNotifyStateChanged)
    {
      PropertyInfo propertyInfo = PropertySupport.ExtractPropertyInfo<T>(propertyExpression);
      base.RaisePropertyChanged<T>(propertyExpression, isNotifyStateChanged);
      if (this.isSettingValue || !ModelObject.CheckIsResource(propertyInfo))
        return;
      this.OnResourcesPropertyChanged(propertyInfo, false);
    }

    private static bool CheckIsResource(PropertyInfo propertyInfo)
    {
      return typeof (ResourceFile).IsAssignableFrom(propertyInfo.PropertyType);
    }

    private void OnResourcesPropertyChanged(PropertyInfo propertyInfo, bool isCheckResource = false)
    {
      ResourceFile resourceFile1;
      if (this.ResourceCollection.TryGetValue(propertyInfo.Name, out resourceFile1))
        this.UnRegisterResourceChanged(propertyInfo.Name, resourceFile1);
      ResourceFile resourceFile2 = propertyInfo.GetValue((object) this, (object[]) null) as ResourceFile;
      this.RegisterResourceChanged(propertyInfo.Name, resourceFile2);
      if (!isCheckResource || resourceFile2 == null || resourceFile2.IsValid)
        return;
      propertyInfo.SetValue((object) this, (object) null, (object[]) null);
    }

    private void RegisterResourceChanged(string propertyName, ResourceFile resourceFile)
    {
      if (resourceFile == null)
        return;
      if (!this.ResourceCollection.ContainsValue(resourceFile))
      {
        resourceFile.Deleted += new EventHandler<EventArgs>(this.OnResourceFileDeleted);
        resourceFile.NameChanged += new EventHandler<EventArgs>(this.OnResourceNameChanged);
      }
      this.ResourceCollection.Add(propertyName, resourceFile);
    }

    private void UnRegisterResourceChanged(string propertyName, ResourceFile resourceFile)
    {
      if (resourceFile != null)
      {
        resourceFile.Deleted -= new EventHandler<EventArgs>(this.OnResourceFileDeleted);
        resourceFile.NameChanged -= new EventHandler<EventArgs>(this.OnResourceNameChanged);
      }
      this.ResourceCollection.Remove(propertyName);
    }

    private void OnResourceNameChanged(object sender, EventArgs e)
    {
      ResourceFile file = sender as ResourceFile;
      foreach (PropertyInfo info in this.FindPropertyInfo(file))
        this.SetResource(info, file);
    }

    private void SetResource(PropertyInfo info, ResourceFile file)
    {
      this.isSettingValue = true;
      this.IsRaiseStateChanged = false;
      info.SetValue((object) this, (object) file, (object[]) null);
      this.IsRaiseStateChanged = true;
      this.isSettingValue = false;
    }

    private void OnResourceFileDeleted(object sender, EventArgs e)
    {
      foreach (PropertyInfo info in this.FindPropertyInfo(sender as ResourceFile))
      {
        this.UnRegisterResourceChanged(info.Name, sender as ResourceFile);
        this.SetResource(info, (ResourceFile) null);
      }
    }

    private List<PropertyInfo> FindPropertyInfo(ResourceFile file)
    {
      List<PropertyInfo> propertyInfoList = new List<PropertyInfo>();
      foreach (KeyValuePair<string, ResourceFile> resource in this.ResourceCollection)
      {
        if (resource.Value == file)
        {
          PropertyInfo property = this.GetType().GetProperty(resource.Key);
          propertyInfoList.Add(property);
        }
      }
      return propertyInfoList;
    }

    void IResourceObject.CollectResources()
    {
      if (this.resourceCollection == null)
        return;
      foreach (PropertyInfo property in this.GetType().GetProperties())
      {
        if (ModelObject.CheckIsResource(property) && !this.ResourceCollection.ContainsKey(property.Name))
          this.OnResourcesPropertyChanged(property, true);
      }
    }

    void IResourceObject.ClearResources()
    {
      if (this.resourceCollection == null)
        return;
      foreach (KeyValuePair<string, ResourceFile> keyValuePair in this.ResourceCollection.ToList<KeyValuePair<string, ResourceFile>>())
        this.UnRegisterResourceChanged(keyValuePair.Key, keyValuePair.Value);
      this.ResourceCollection.Clear();
    }
  }
}
