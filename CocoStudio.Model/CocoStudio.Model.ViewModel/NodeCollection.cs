using System;
using System.Collections.Specialized;

namespace CocoStudio.Model.ViewModel
{
	public class NodeCollection : ObjectCollection<NodeObject>
	{
		private NodeObject parentObject;

		public NodeCollection(NodeObject parentObject)
		{
			this.parentObject = parentObject;
		}

		protected override void OnInsert(int index, NodeObject item)
		{
			if (item == null)
			{
				throw new ArgumentException("Child should not be null.");
			}
			this.parentObject.InsertChild(index, item);
			item.Parent = this.parentObject;
			item.AfterAdded();
			item.BindingRecorder(null);
			item.AncestorObjectChanged(item, NotifyCollectionChangedAction.Add);
		}

		protected override void OnAdd(NodeObject item)
		{
			if (item == null)
			{
				throw new ArgumentException("Child should not be null.");
			}
			this.parentObject.InsertChild(base.Count, item);
			item.Parent = this.parentObject;
			item.AfterAdded();
			item.BindingRecorder(null);
			item.AncestorObjectChanged(item, NotifyCollectionChangedAction.Add);
		}

		protected override void OnRemove(NodeObject item)
		{
			if (item == null)
			{
				throw new ArgumentException("Child should not be null.");
			}
			item.BeforeRemoved();
			item.AncestorObjectChanged(item, NotifyCollectionChangedAction.Remove);
			item.Parent = null;
			this.parentObject.RemoveChild(item);
		}
	}
}
