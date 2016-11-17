// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSVectorString
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
    public class CSVectorString : IDisposable, IList<string>, ICollection<string>, IEnumerable<string>, IEnumerable
    {
        public sealed class CSVectorStringEnumerator : IEnumerator<string>, IDisposable, IEnumerator
        {
            private CSVectorString collectionRef;

            private int currentIndex;

            private object currentObject;

            private int currentSize;

            public string Current
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
                    return (string)this.currentObject;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return this.Current;
                }
            }

            public CSVectorStringEnumerator(CSVectorString collection)
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

        public string this[int index]
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

        public CSVectorString(IntPtr cPtr, bool cMemoryOwn)
        {
            this.swigCMemOwn = cMemoryOwn;
            this.swigCPtr = new HandleRef(this, cPtr);
        }

        public static HandleRef getCPtr(CSVectorString obj)
        {
            return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
        }

        ~CSVectorString()
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
                        CocoStudioEngineAdapterPINVOKE.delete_CSVectorString(this.swigCPtr);
                    }
                    this.swigCPtr = new HandleRef(null, IntPtr.Zero);
                }
                GC.SuppressFinalize(this);
            }
        }

        public CSVectorString(ICollection c)
            : this()
        {
            if (c == null)
            {
                throw new ArgumentNullException("c");
            }
            foreach (string x in c)
            {
                this.Add(x);
            }
        }

        public void CopyTo(string[] array)
        {
            this.CopyTo(0, array, 0, this.Count);
        }

        public void CopyTo(string[] array, int arrayIndex)
        {
            this.CopyTo(0, array, arrayIndex, this.Count);
        }

        public void CopyTo(int index, string[] array, int arrayIndex, int count)
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

        IEnumerator<string> IEnumerable<string>.GetEnumerator()
        {
            return new CSVectorString.CSVectorStringEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new CSVectorString.CSVectorStringEnumerator(this);
        }

        public CSVectorString.CSVectorStringEnumerator GetEnumerator()
        {
            return new CSVectorString.CSVectorStringEnumerator(this);
        }

        public void Clear()
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorString_Clear(this.swigCPtr);
        }

        public void Add(string x)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorString_Add(this.swigCPtr, x);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        private uint size()
        {
            return CocoStudioEngineAdapterPINVOKE.CSVectorString_size(this.swigCPtr);
        }

        private uint capacity()
        {
            return CocoStudioEngineAdapterPINVOKE.CSVectorString_capacity(this.swigCPtr);
        }

        private void reserve(uint n)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorString_reserve(this.swigCPtr, n);
        }

        public CSVectorString()
            : this(CocoStudioEngineAdapterPINVOKE.new_CSVectorString__SWIG_0(), true)
        {
        }

        public CSVectorString(CSVectorString other)
            : this(CocoStudioEngineAdapterPINVOKE.new_CSVectorString__SWIG_1(CSVectorString.getCPtr(other)), true)
        {
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public CSVectorString(int capacity)
            : this(CocoStudioEngineAdapterPINVOKE.new_CSVectorString__SWIG_2(capacity), true)
        {
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        private string getitemcopy(int index)
        {
            string result = CocoStudioEngineAdapterPINVOKE.CSVectorString_getitemcopy(this.swigCPtr, index);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
            return result;
        }

        private string getitem(int index)
        {
            string result = CocoStudioEngineAdapterPINVOKE.CSVectorString_getitem(this.swigCPtr, index);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
            return result;
        }

        private void setitem(int index, string val)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorString_setitem(this.swigCPtr, index, val);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public void AddRange(CSVectorString values)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorString_AddRange(this.swigCPtr, CSVectorString.getCPtr(values));
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public CSVectorString GetRange(int index, int count)
        {
            IntPtr intPtr = CocoStudioEngineAdapterPINVOKE.CSVectorString_GetRange(this.swigCPtr, index, count);
            CSVectorString result = (intPtr == IntPtr.Zero) ? null : new CSVectorString(intPtr, true);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
            return result;
        }

        public void Insert(int index, string x)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorString_Insert(this.swigCPtr, index, x);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public void InsertRange(int index, CSVectorString values)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorString_InsertRange(this.swigCPtr, index, CSVectorString.getCPtr(values));
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public void RemoveAt(int index)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorString_RemoveAt(this.swigCPtr, index);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public void RemoveRange(int index, int count)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorString_RemoveRange(this.swigCPtr, index, count);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public static CSVectorString Repeat(string value, int count)
        {
            IntPtr intPtr = CocoStudioEngineAdapterPINVOKE.CSVectorString_Repeat(value, count);
            CSVectorString result = (intPtr == IntPtr.Zero) ? null : new CSVectorString(intPtr, true);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
            return result;
        }

        public void Reverse()
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorString_Reverse__SWIG_0(this.swigCPtr);
        }

        public void Reverse(int index, int count)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorString_Reverse__SWIG_1(this.swigCPtr, index, count);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public void SetRange(int index, CSVectorString values)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorString_SetRange(this.swigCPtr, index, CSVectorString.getCPtr(values));
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public bool Contains(string value)
        {
            bool result = CocoStudioEngineAdapterPINVOKE.CSVectorString_Contains(this.swigCPtr, value);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
            return result;
        }

        public int IndexOf(string value)
        {
            int result = CocoStudioEngineAdapterPINVOKE.CSVectorString_IndexOf(this.swigCPtr, value);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
            return result;
        }

        public int LastIndexOf(string value)
        {
            int result = CocoStudioEngineAdapterPINVOKE.CSVectorString_LastIndexOf(this.swigCPtr, value);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
            return result;
        }

        public bool Remove(string value)
        {
            bool result = CocoStudioEngineAdapterPINVOKE.CSVectorString_Remove(this.swigCPtr, value);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
            return result;
        }
    }
}
