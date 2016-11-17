using System;
using System.Collections.ObjectModel;

namespace CocoStudio.Model.ViewModel
{
	public class ObjectCollection<T> : ObservableCollection<T> where T : class
	{
		protected ObjectCollection()
		{
		}

		public new void Add(T item)
		{
			this.OnAdd(item);
			base.Add(item);
		}

		public new void Insert(int index, T item)
		{
			this.OnInsert(index, item);
			base.Insert(index, item);
		}

		public new void Remove(T item)
		{
			this.OnRemove(item);
			base.Remove(item);
		}

		public new void RemoveAt(int index)
		{
			T item = base[index];
			base.RemoveAt(index);
			this.OnRemove(item);
		}

		public new void Clear()
		{
			foreach (T current in this)
			{
				this.OnRemove(current);
			}
			base.Clear();
		}

		protected virtual void OnRemove(T item)
		{
			throw new NotImplementedException();
		}

		protected virtual void OnAdd(T item)
		{
			throw new NotImplementedException();
		}

		protected virtual void OnInsert(int index, T item)
		{
			throw new NotImplementedException();
		}
	}
}
