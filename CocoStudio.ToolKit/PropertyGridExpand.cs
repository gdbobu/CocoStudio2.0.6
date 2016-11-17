// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.PropertyGridExpand
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using CocoStudio.Model;
using Gtk;
using Modules.Communal.MultiLanguage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CocoStudio.ToolKit
{
    public class PropertyGridExpand
    {
        private EditorManager em;

        private PropertyGrid objectParent;

        private Table expandTable;

        private List<string> category = new List<string>();

        public Table ExpandTable
        {
            get
            {
                return this.expandTable;
            }
        }

        public PropertyGridExpand(EditorManager editorManager, PropertyGrid parent)
        {
            this.em = editorManager;
            this.objectParent = parent;
        }

        internal void Populate(object objectItem, List<PropertyItem> itemList, int type = 0, object instance = null)
        {
            if (itemList.Count == 0 || objectItem == null)
            {
                this.expandTable = new Table(1u, 1u, false);
            }
            else
            {
                itemList.Sort((PropertyItem a, PropertyItem b) => a.Calegory.CompareTo(b.Calegory));
                List<string> list = new List<string>();
                List<CatagoryAttribute> list2 = new List<CatagoryAttribute>();
                Attribute[] customAttributes = Attribute.GetCustomAttributes(objectItem.GetType(), true);
                for (int i = 0; i < customAttributes.Length; i++)
                {
                    Attribute attribute = customAttributes[i];
                    if (attribute is CatagoryAttribute)
                    {
                        list2.Add(attribute as CatagoryAttribute);
                    }
                }
                list2.Sort((CatagoryAttribute a, CatagoryAttribute b) => a.Order.CompareTo(b.Order));
                list2.RemoveAll((CatagoryAttribute w) => w.Group != type);
                if (itemList.FirstOrDefault<PropertyItem>().InstanceList.Count > 1)
                {
                    list2.RemoveAll((CatagoryAttribute w) => w.Group == 1);
                }
                using (List<CatagoryAttribute>.Enumerator enumerator = list2.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        CatagoryAttribute item = enumerator.Current;
                        PropertyItem propertyItem = itemList.FirstOrDefault((PropertyItem w) => w.Calegory == item.Catatory);
                        if (propertyItem != null)
                        {
                            list.Add(item.Catatory);
                        }
                    }
                }
                this.expandTable = new Table((uint)list.Count, 1u, false);
                uint num = 0u;
                using (List<string>.Enumerator enumerator2 = list.GetEnumerator())
                {
                    while (enumerator2.MoveNext())
                    {
                        string item = enumerator2.Current;
                        List<PropertyItem> list3 = (from w in itemList
                                                    where w.Calegory == item
                                                    select w).ToList<PropertyItem>();
                        if (list3 != null)
                        {
                            list3.Sort((PropertyItem a, PropertyItem b) => (a.PropertyOrder ?? -10).CompareTo(b.PropertyOrder ?? -10));
                            Widget widget;
                            if (objectItem is IPropertyTitle)
                            {
                                CustomExpender customExpender = this.CreateExpand(LanguageOption.GetValueBykey(item), list3);
                                customExpender.ExpandCategory = item;
                                customExpender.ExpandChanged += new EventHandler<ExpandEvent>(this.expand_ExpandChanged);
                                widget = customExpender;
                                customExpender.Expanded = (this.category.FirstOrDefault((string w) => w == item) == null);
                                widget.CanFocus = true;
                            }
                            else
                            {
                                widget = this.CreateTable(LanguageOption.GetValueBykey(item), list3);
                            }
                            this.expandTable.Attach(widget, 0u, 1u, num, num + 1u, AttachOptions.Expand | AttachOptions.Fill, AttachOptions.Fill, 0u, 0u);
                            widget.Show();
                            num += 1u;
                        }
                    }
                }
            }
        }

        private void expand_ExpandChanged(object sender, ExpandEvent e)
        {
            if (e.Expand)
            {
                this.category.RemoveAll((string w) => w == e.Name);
            }
            else
            {
                this.category.Add(e.Name);
            }
        }

        private CustomExpender CreateExpand(string calegory, List<PropertyItem> propertyItem)
        {
            CustomExpender customExpender = new CustomExpender(calegory);
            Table table = new Table((uint)(propertyItem.Count + 1), 2u, false);
            Label label = new Label();
            label.HeightRequest = 16;
            table.Attach(label, 1u, 2u, 0u, 1u, AttachOptions.Expand, AttachOptions.Fill, 0u, 0u);
            label.Show();
            uint num = 1u;
            foreach (PropertyItem current in propertyItem)
            {
                ITypeEditor editor = this.em.GetEditor(current);
                Widget widget;
                if (editor == null)
                {
                    widget = current.WidgetDate;
                }
                else
                {
                    current.TypeEditor = editor;
                    widget = editor.ResolveEditor(current);
                }
                if (current.DiaplayName == "grid_sudoku_size" || current.DiaplayName == "Fill_color" || current.DiaplayName == "Display_Component_Layout")
                {
                    if (widget == null)
                    {
                        num += 1u;
                    }
                    else
                    {
                        if (widget is Entry)
                        {
                            Entry entry = widget as Entry;
                            table.Add(entry);
                            entry.Show();
                        }
                        else
                        {
                            table.Add(widget);
                        }
                        widget.Show();
                        Table.TableChild tableChild = (Table.TableChild)table[widget];
                        tableChild.LeftAttach = 0u;
                        tableChild.RightAttach = 2u;
                        tableChild.TopAttach = num;
                        tableChild.BottomAttach = num + 1u;
                        tableChild.XOptions = (AttachOptions.Expand | AttachOptions.Fill);
                        tableChild.YOptions = AttachOptions.Fill;
                        num += 1u;
                    }
                }
                else
                {
                    ContentLabel contentLabel = new ContentLabel(90);
                    contentLabel.SetLabelText(LanguageOption.GetValueBykey(current.DiaplayName));
                    table.Add(contentLabel);
                    contentLabel.Show();
                    Table.TableChild tableChild2 = (Table.TableChild)table[contentLabel];
                    tableChild2.TopAttach = num;
                    tableChild2.BottomAttach = num + 1u;
                    tableChild2.XOptions = AttachOptions.Fill;
                    tableChild2.YOptions = AttachOptions.Fill;
                    if (widget == null)
                    {
                        num += 1u;
                    }
                    else
                    {
                        Alignment alignment = new Alignment(0.5f, 0.5f, 1f, 1f);
                        if (widget is Entry)
                        {
                            Entry entry = widget as Entry;
                            alignment.BottomPadding = 16u;
                            alignment.Add(entry);
                            entry.Show();
                            alignment.Show();
                            table.Add(alignment);
                        }
                        else
                        {
                            if (widget is INumberEntry)
                            {
                                if ((widget as INumberEntry).GetMenuVisble())
                                {
                                    alignment.BottomPadding = 8u;
                                }
                                else
                                {
                                    alignment.BottomPadding = 16u;
                                }
                            }
                            else
                            {
                                alignment.BottomPadding = 16u;
                            }
                            alignment.Add(widget);
                            widget.Show();
                            alignment.Show();
                            table.Add(alignment);
                        }
                        Table.TableChild tableChild = (Table.TableChild)table[alignment];
                        tableChild.LeftAttach = 1u;
                        tableChild.RightAttach = 2u;
                        tableChild.TopAttach = num;
                        tableChild.BottomAttach = num + 1u;
                        tableChild.XOptions = (AttachOptions.Expand | AttachOptions.Fill);
                        tableChild.YOptions = AttachOptions.Fill;
                        num += 1u;
                    }
                }
            }
            customExpender.Add(table);
            table.Show();
            table.ColumnSpacing = 10u;
            return customExpender;
        }

        private EventBox CreateTable(string calegory, List<PropertyItem> propertyItem)
        {
            EventBox eventBox = new EventBox();
            Table table = new Table((uint)(propertyItem.Count + 1), 2u, false);
            Label label = new Label();
            label.HeightRequest = 16;
            table.Attach(label, 1u, 2u, 0u, 1u, AttachOptions.Expand, AttachOptions.Fill, 0u, 0u);
            label.Show();
            uint num = 1u;
            foreach (PropertyItem current in propertyItem)
            {
                ITypeEditor editor = this.em.GetEditor(current);
                Widget widget;
                if (editor == null)
                {
                    widget = current.WidgetDate;
                }
                else
                {
                    current.TypeEditor = editor;
                    widget = editor.ResolveEditor(current);
                }
                if (current.DiaplayName == "grid_sudoku_size" || current.DiaplayName == "Fill_color")
                {
                    if (widget == null)
                    {
                        num += 1u;
                    }
                    else
                    {
                        if (widget is Entry)
                        {
                            Entry entry = widget as Entry;
                            table.Add(entry);
                            entry.Show();
                        }
                        else
                        {
                            table.Add(widget);
                        }
                        widget.Show();
                        Table.TableChild tableChild = (Table.TableChild)table[widget];
                        tableChild.LeftAttach = 0u;
                        tableChild.RightAttach = 2u;
                        tableChild.TopAttach = num;
                        tableChild.BottomAttach = num + 1u;
                        tableChild.XOptions = (AttachOptions.Expand | AttachOptions.Fill);
                        tableChild.YOptions = AttachOptions.Fill;
                        num += 1u;
                    }
                }
                else
                {
                    ContentLabel contentLabel = new ContentLabel(90);
                    contentLabel.SetLabelText(LanguageOption.GetValueBykey(current.DiaplayName));
                    table.Add(contentLabel);
                    contentLabel.Show();
                    Table.TableChild tableChild2 = (Table.TableChild)table[contentLabel];
                    tableChild2.TopAttach = num;
                    tableChild2.BottomAttach = num + 1u;
                    tableChild2.XOptions = AttachOptions.Fill;
                    tableChild2.YOptions = AttachOptions.Fill;
                    if (widget == null)
                    {
                        num += 1u;
                    }
                    else
                    {
                        Alignment alignment = new Alignment(0.5f, 0.5f, 1f, 1f);
                        if (widget is Entry)
                        {
                            Entry entry = widget as Entry;
                            alignment.BottomPadding = 16u;
                            alignment.Add(entry);
                            entry.Show();
                            alignment.Show();
                            table.Add(alignment);
                        }
                        else
                        {
                            if (widget is INumberEntry)
                            {
                                if ((widget as INumberEntry).GetMenuVisble())
                                {
                                    alignment.BottomPadding = 8u;
                                }
                                else
                                {
                                    alignment.BottomPadding = 16u;
                                }
                            }
                            else
                            {
                                alignment.BottomPadding = 16u;
                            }
                            alignment.Add(widget);
                            widget.Show();
                            alignment.Show();
                            table.Add(alignment);
                        }
                        Table.TableChild tableChild = (Table.TableChild)table[alignment];
                        tableChild.LeftAttach = 1u;
                        tableChild.RightAttach = 2u;
                        tableChild.TopAttach = num;
                        tableChild.BottomAttach = num + 1u;
                        tableChild.XOptions = (AttachOptions.Expand | AttachOptions.Fill);
                        tableChild.YOptions = AttachOptions.Fill;
                        num += 1u;
                    }
                }
            }
            table.ColumnSpacing = 10u;
            eventBox.Add(table);
            table.Show();
            eventBox.CanFocus = false;
            return eventBox;
        }
    }
}
