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
				{
					this.resourceCollection = new Dictionary<string, ResourceFile>();
				}
				return this.resourceCollection;
			}
		}

		protected override void RaisePropertyChanged<T>(Expression<Func<T>> propertyExpression, bool isNotifyStateChanged)
		{
			PropertyInfo propertyInfo = PropertySupport.ExtractPropertyInfo<T>(propertyExpression);
			base.RaisePropertyChanged<T>(propertyExpression, isNotifyStateChanged);
			if (!this.isSettingValue)
			{
				if (ModelObject.CheckIsResource(propertyInfo))
				{
					this.OnResourcesPropertyChanged(propertyInfo, false);
				}
			}
		}

		private static bool CheckIsResource(PropertyInfo propertyInfo)
		{
			return typeof(ResourceFile).IsAssignableFrom(propertyInfo.PropertyType);
		}

		private void OnResourcesPropertyChanged(PropertyInfo propertyInfo, bool isCheckResource = false)
		{
			ResourceFile resourceFile;
			bool flag = this.ResourceCollection.TryGetValue(propertyInfo.Name, out resourceFile);
			if (flag)
			{
				this.UnRegisterResourceChanged(propertyInfo.Name, resourceFile);
			}
			resourceFile = (propertyInfo.GetValue(this, null) as ResourceFile);
			this.RegisterResourceChanged(propertyInfo.Name, resourceFile);
			if (isCheckResource && resourceFile != null)
			{
				if (!resourceFile.IsValid)
				{
					propertyInfo.SetValue(this, null, null);
				}
			}
		}

		private void RegisterResourceChanged(string propertyName, ResourceFile resourceFile)
		{
			if (resourceFile != null)
			{
				if (!this.ResourceCollection.ContainsValue(resourceFile))
				{
					resourceFile.Deleted += new EventHandler<EventArgs>(this.OnResourceFileDeleted);
					resourceFile.NameChanged += new EventHandler<EventArgs>(this.OnResourceNameChanged);
				}
				this.ResourceCollection.Add(propertyName, resourceFile);
			}
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
			List<PropertyInfo> list = this.FindPropertyInfo(file);
			foreach (PropertyInfo current in list)
			{
				this.SetResource(current, file);
			}
		}

		private void SetResource(PropertyInfo info, ResourceFile file)
		{
			this.isSettingValue = true;
			base.IsRaiseStateChanged = false;
			info.SetValue(this, file, null);
			base.IsRaiseStateChanged = true;
			this.isSettingValue = false;
		}

		private void OnResourceFileDeleted(object sender, EventArgs e)
		{
			ResourceFile file = sender as ResourceFile;
			List<PropertyInfo> list = this.FindPropertyInfo(file);
			foreach (PropertyInfo current in list)
			{
				this.UnRegisterResourceChanged(current.Name, sender as ResourceFile);
				this.SetResource(current, null);
			}
		}

		private List<PropertyInfo> FindPropertyInfo(ResourceFile file)
		{
			List<PropertyInfo> list = new List<PropertyInfo>();
			foreach (KeyValuePair<string, ResourceFile> current in this.ResourceCollection)
			{
				if (current.Value == file)
				{
					PropertyInfo property = base.GetType().GetProperty(current.Key);
					list.Add(property);
				}
			}
			return list;
		}

		void IResourceObject.CollectResources()
		{
			if (this.resourceCollection != null)
			{
				PropertyInfo[] properties = base.GetType().GetProperties();
				PropertyInfo[] array = properties;
				for (int i = 0; i < array.Length; i++)
				{
					PropertyInfo propertyInfo = array[i];
					if (ModelObject.CheckIsResource(propertyInfo) && !this.ResourceCollection.ContainsKey(propertyInfo.Name))
					{
						this.OnResourcesPropertyChanged(propertyInfo, true);
					}
				}
			}
		}

		void IResourceObject.ClearResources()
		{
			if (this.resourceCollection != null)
			{
				List<KeyValuePair<string, ResourceFile>> list = this.ResourceCollection.ToList<KeyValuePair<string, ResourceFile>>();
				foreach (KeyValuePair<string, ResourceFile> current in list)
				{
					this.UnRegisterResourceChanged(current.Key, current.Value);
				}
				this.ResourceCollection.Clear();
			}
		}
	}
}
