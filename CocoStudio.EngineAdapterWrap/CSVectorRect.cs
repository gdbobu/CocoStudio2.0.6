// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSVectorRect
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using CocoStudio.EngineAdapterWrap.Extend;
using Gdk;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
    public class CSVectorRect : IDisposable, IEnumerable<Rectangle>, IEnumerable
    {
        public sealed class CSVectorRectEnumerator : IEnumerator<Rectangle>, IDisposable, IEnumerator
        {
            private CSVectorRect collectionRef;

            private int currentIndex;

            private object currentObject;

            private int currentSize;

            public Rectangle Current
            {
                get
                {
                    if (this.currentIndex == -1)
                    {
                        throw new InvalidOperationException("Enumeration not started.");
                    }
                    if (this.currentIndex > this.currentSize - 1)
                    {
                        throw new InvalidOperationException("Enumeration finished.");
                    }
                    if (this.currentObject == null)
                    {
                        throw new InvalidOperationException("Collection modified.");
                    }
                    return (Rectangle)this.currentObject;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return this.Current;
                }
            }

            public CSVectorRectEnumerator(CSVectorRect collection)
            {
                this.collectionRef = collection;
                this.currentIndex = -1;
                this.currentObject = null;
                this.currentSize = this.collectionRef.Count;
            }

            public bool MoveNext()
            {
                int count = this.collectionRef.Count;
                bool flag = this.currentIndex + 1 < count && count == this.currentSize;
                if (flag)
                {
                    this.currentIndex++;
                    this.currentObject = this.collectionRef[this.currentIndex];
                }
                else
                {
                    this.currentObject = null;
                }
                return flag;
            }

            public void Reset()
            {
                this.currentIndex = -1;
                this.currentObject = null;
                if (this.collectionRef.Count != this.currentSize)
                {
                    throw new InvalidOperationException("Collection modified.");
                }
            }

            public void Dispose()
            {
                this.currentIndex = -1;
                this.currentObject = null;
            }
        }

        private HandleRef swigCPtr;

        protected bool swigCMemOwn;

        public bool IsFixedSize
        {
            get
            {
                return false;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public Rectangle this[int index]
        {
            get
            {
                return this.getitem(index);
            }
            set
            {
                this.setitem(index, value);
            }
        }

        public int Capacity
        {
            get
            {
                return (int)this.capacity();
            }
            set
            {
                if ((long)value < (long)((ulong)this.size()))
                {
                    throw new ArgumentOutOfRangeException("Capacity");
                }
                this.reserve((uint)value);
            }
        }

        public int Count
        {
            get
            {
                return (int)this.size();
            }
        }

        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }

        public CSVectorRect(IntPtr cPtr, bool cMemoryOwn)
        {
            this.swigCMemOwn = cMemoryOwn;
            this.swigCPtr = new HandleRef(this, cPtr);
        }

        public static HandleRef getCPtr(CSVectorRect obj)
        {
            return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
        }

        ~CSVectorRect()
        {
            this.Dispose();
        }

        public virtual void Dispose()
        {
            lock (this)
            {
                if (this.swigCPtr.Handle != IntPtr.Zero)
                {
                    if (this.swigCMemOwn)
                    {
                        this.swigCMemOwn = false;
                        HandleRef handle = new HandleRef(null, this.swigCPtr.Handle);
                        if (this.IsContainOpenGLResource())
                        {
                            GtkInvokeHelp.BeginInvoke(delegate
                            {
                                this.swigCPtr = handle;
                                CocoStudioEngineAdapterPINVOKE.delete_CSVectorRect(this.swigCPtr);
                            });
                        }
                        else
                        {
                            CocoStudioEngineAdapterPINVOKE.delete_CSVectorRect(this.swigCPtr);
                        }
                    }
                    this.swigCPtr = new HandleRef(null, IntPtr.Zero);
                }
                System.GC.SuppressFinalize(this);
            }
        }

        public CSVectorRect(ICollection c)
            : this()
        {
            if (c == null)
            {
                throw new ArgumentNullException("c");
            }
            foreach (Rectangle x in c)
            {
                this.Add(x);
            }
        }

        public void CopyTo(Rectangle[] array)
        {
            this.CopyTo(0, array, 0, this.Count);
        }

        public void CopyTo(Rectangle[] array, int arrayIndex)
        {
            this.CopyTo(0, array, arrayIndex, this.Count);
        }

        public void CopyTo(int index, Rectangle[] array, int arrayIndex, int count)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("index", "Value is less than zero");
            }
            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("arrayIndex", "Value is less than zero");
            }
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count", "Value is less than zero");
            }
            if (array.Rank > 1)
            {
                throw new ArgumentException("Multi dimensional array.", "array");
            }
            if (index + count > this.Count || arrayIndex + count > array.Length)
            {
                throw new ArgumentException("Number of elements to copy is too large.");
            }
            for (int i = 0; i < count; i++)
            {
                array.SetValue(this.getitemcopy(index + i), arrayIndex + i);
            }
        }

        IEnumerator<Rectangle> IEnumerable<Rectangle>.GetEnumerator()
        {
            return new CSVectorRect.CSVectorRectEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new CSVectorRect.CSVectorRectEnumerator(this);
        }

        public CSVectorRect.CSVectorRectEnumerator GetEnumerator()
        {
            return new CSVectorRect.CSVectorRectEnumerator(this);
        }

        public void Clear()
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorRect_Clear(this.swigCPtr);
        }

        public void Add(Rectangle x)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorRect_Add(this.swigCPtr, Rect.getCPtr(new Rect((float)x.X, (float)x.Y, (float)x.Width, (float)x.Height)));
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        private uint size()
        {
            return CocoStudioEngineAdapterPINVOKE.CSVectorRect_size(this.swigCPtr);
        }

        private uint capacity()
        {
            return CocoStudioEngineAdapterPINVOKE.CSVectorRect_capacity(this.swigCPtr);
        }

        private void reserve(uint n)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorRect_reserve(this.swigCPtr, n);
        }

        public CSVectorRect()
            : this(CocoStudioEngineAdapterPINVOKE.new_CSVectorRect__SWIG_0(), true)
        {
        }

        public CSVectorRect(CSVectorRect other)
            : this(CocoStudioEngineAdapterPINVOKE.new_CSVectorRect__SWIG_1(CSVectorRect.getCPtr(other)), true)
        {
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public CSVectorRect(int capacity)
            : this(CocoStudioEngineAdapterPINVOKE.new_CSVectorRect__SWIG_2(capacity), true)
        {
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        private Rectangle getitemcopy(int index)
        {
            IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.CSVectorRect_getitemcopy(this.swigCPtr, index);
            Rect rect = new Rect(cPtr, true);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
            if (rect.size.width < 0f || rect.size.height < 0f)
            {
                rect.origin.x = 0f;
                rect.origin.y = 0f;
                rect.size.width = 0f;
                rect.size.height = 0f;
            }
            Rectangle result = new Rectangle((int)rect.origin.x, (int)rect.origin.y, (int)rect.size.width, (int)rect.size.height);
            return result;
        }

        private Rectangle getitem(int index)
        {
            IntPtr cPtr = CocoStudioEngineAdapterPINVOKE.CSVectorRect_getitem(this.swigCPtr, index);
            Rect rect = new Rect(cPtr, false);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
            if (rect.size.width < 0f || rect.size.height < 0f)
            {
                rect.origin.x = 0f;
                rect.origin.y = 0f;
                rect.size.width = 0f;
                rect.size.height = 0f;
            }
            Rectangle result = new Rectangle((int)rect.origin.x, (int)rect.origin.y, (int)rect.size.width, (int)rect.size.height);
            return result;
        }

        private void setitem(int index, Rectangle val)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorRect_setitem(this.swigCPtr, index, Rect.getCPtr(new Rect((float)val.X, (float)val.Y, (float)val.Width, (float)val.Height)));
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public void AddRange(CSVectorRect values)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorRect_AddRange(this.swigCPtr, CSVectorRect.getCPtr(values));
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public CSVectorRect GetRange(int index, int count)
        {
            IntPtr intPtr = CocoStudioEngineAdapterPINVOKE.CSVectorRect_GetRange(this.swigCPtr, index, count);
            CSVectorRect result = (intPtr == IntPtr.Zero) ? null : new CSVectorRect(intPtr, true);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
            return result;
        }

        public void Insert(int index, Rectangle x)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorRect_Insert(this.swigCPtr, index, Rect.getCPtr(new Rect((float)x.X, (float)x.Y, (float)x.Width, (float)x.Height)));
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public void InsertRange(int index, CSVectorRect values)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorRect_InsertRange(this.swigCPtr, index, CSVectorRect.getCPtr(values));
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public void RemoveAt(int index)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorRect_RemoveAt(this.swigCPtr, index);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public void RemoveRange(int index, int count)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorRect_RemoveRange(this.swigCPtr, index, count);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public static CSVectorRect Repeat(Rectangle value, int count)
        {
            IntPtr intPtr = CocoStudioEngineAdapterPINVOKE.CSVectorRect_Repeat(Rect.getCPtr(new Rect((float)value.X, (float)value.Y, (float)value.Width, (float)value.Height)), count);
            CSVectorRect result = (intPtr == IntPtr.Zero) ? null : new CSVectorRect(intPtr, true);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
            return result;
        }

        public void Reverse()
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorRect_Reverse__SWIG_0(this.swigCPtr);
        }

        public void Reverse(int index, int count)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorRect_Reverse__SWIG_1(this.swigCPtr, index, count);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public void SetRange(int index, CSVectorRect values)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorRect_SetRange(this.swigCPtr, index, CSVectorRect.getCPtr(values));
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }
    }

}
