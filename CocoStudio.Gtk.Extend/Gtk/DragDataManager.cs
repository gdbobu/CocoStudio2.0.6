// Decompiled with JetBrains decompiler
// Type: Gtk.DragDataManager
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using Gdk;
using System;

namespace Gtk
{
  internal class DragDataManager
  {
    private static Widget sourceWidget;
    private static object data;

    public static void SetDragData(DragContext dragContext, object data)
    {
      DragDataManager.data = data;
      DragDataManager.sourceWidget = dragContext.GetSourceWidget();
    }

    public static object GetDragData(DragContext dragContext)
    {
      if (DragDataManager.sourceWidget == null && DragDataManager.data is FileDropInfo || DragDataManager.IsSameSourceWidget(dragContext))
        return DragDataManager.data;
      Console.WriteLine("Should set drag data in begin drag event. Then can get drag data.");
      return (object) null;
    }

    private static bool IsSameSourceWidget(DragContext dragContext)
    {
      return DragDataManager.sourceWidget != null && DragDataManager.sourceWidget.Equals((object) dragContext.GetSourceWidget());
    }
  }
}
