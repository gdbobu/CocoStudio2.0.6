// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSVectorInt
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
    public class CSVectorInt : IDisposable, IList<int>, ICollection<int>, IEnumerable<int>, IEnumerable
    {
        public sealed class CSVectorIntEnumerator : IEnumerator<int>, IDisposable, IEnumerator
        {
            private CSVectorInt collectionRef;

            private int currentIndex;

            private object currentObject;

            private int currentSize;

            public int Current
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
                    return (int)this.currentObject;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return this.Current;
                }
            }

            public CSVectorIntEnumerator(CSVectorInt collection)
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

        public int this[int index]
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

        public CSVectorInt(IntPtr cPtr, bool cMemoryOwn)
        {
            this.swigCMemOwn = cMemoryOwn;
            this.swigCPtr = new HandleRef(this, cPtr);
        }

        public static HandleRef getCPtr(CSVectorInt obj)
        {
            return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
        }

        ~CSVectorInt()
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
                        CocoStudioEngineAdapterPINVOKE.delete_CSVectorInt(this.swigCPtr);
                    }
                    this.swigCPtr = new HandleRef(null, IntPtr.Zero);
                }
                GC.SuppressFinalize(this);
            }
        }

        public CSVectorInt(ICollection c)
            : this()
        {
            if (c == null)
            {
                throw new ArgumentNullException("c");
            }
            foreach (int x in c)
            {
                this.Add(x);
            }
        }

        public void CopyTo(int[] array)
        {
            this.CopyTo(0, array, 0, this.Count);
        }

        public void CopyTo(int[] array, int arrayIndex)
        {
            this.CopyTo(0, array, arrayIndex, this.Count);
        }

        public void CopyTo(int index, int[] array, int arrayIndex, int count)
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

        public IEnumerator<int>  GetEnumerator()
        {
            return new CSVectorInt.CSVectorIntEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new CSVectorInt.CSVectorIntEnumerator(this);
        }

        public void Clear()
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorInt_Clear(this.swigCPtr);
        }

        public void Add(int x)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorInt_Add(this.swigCPtr, x);
        }

        private uint size()
        {
            return CocoStudioEngineAdapterPINVOKE.CSVectorInt_size(this.swigCPtr);
        }

        private uint capacity()
        {
            return CocoStudioEngineAdapterPINVOKE.CSVectorInt_capacity(this.swigCPtr);
        }

        private void reserve(uint n)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorInt_reserve(this.swigCPtr, n);
        }

        public CSVectorInt()
            : this(CocoStudioEngineAdapterPINVOKE.new_CSVectorInt__SWIG_0(), true)
        {
        }

        public CSVectorInt(CSVectorInt other)
            : this(CocoStudioEngineAdapterPINVOKE.new_CSVectorInt__SWIG_1(CSVectorInt.getCPtr(other)), true)
        {
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public CSVectorInt(int capacity)
            : this(CocoStudioEngineAdapterPINVOKE.new_CSVectorInt__SWIG_2(capacity), true)
        {
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        private int getitemcopy(int index)
        {
            int result = CocoStudioEngineAdapterPINVOKE.CSVectorInt_getitemcopy(this.swigCPtr, index);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
            return result;
        }

        private int getitem(int index)
        {
            int result = CocoStudioEngineAdapterPINVOKE.CSVectorInt_getitem(this.swigCPtr, index);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
            return result;
        }

        private void setitem(int index, int val)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorInt_setitem(this.swigCPtr, index, val);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public void AddRange(CSVectorInt values)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorInt_AddRange(this.swigCPtr, CSVectorInt.getCPtr(values));
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public CSVectorInt GetRange(int index, int count)
        {
            IntPtr intPtr = CocoStudioEngineAdapterPINVOKE.CSVectorInt_GetRange(this.swigCPtr, index, count);
            CSVectorInt result = (intPtr == IntPtr.Zero) ? null : new CSVectorInt(intPtr, true);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
            return result;
        }

        public void Insert(int index, int x)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorInt_Insert(this.swigCPtr, index, x);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public void InsertRange(int index, CSVectorInt values)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorInt_InsertRange(this.swigCPtr, index, CSVectorInt.getCPtr(values));
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public void RemoveAt(int index)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorInt_RemoveAt(this.swigCPtr, index);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public void RemoveRange(int index, int count)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorInt_RemoveRange(this.swigCPtr, index, count);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public static CSVectorInt Repeat(int value, int count)
        {
            IntPtr intPtr = CocoStudioEngineAdapterPINVOKE.CSVectorInt_Repeat(value, count);
            CSVectorInt result = (intPtr == IntPtr.Zero) ? null : new CSVectorInt(intPtr, true);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
            return result;
        }

        public void Reverse()
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorInt_Reverse__SWIG_0(this.swigCPtr);
        }

        public void Reverse(int index, int count)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorInt_Reverse__SWIG_1(this.swigCPtr, index, count);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public void SetRange(int index, CSVectorInt values)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorInt_SetRange(this.swigCPtr, index, CSVectorInt.getCPtr(values));
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public bool Contains(int value)
        {
            return CocoStudioEngineAdapterPINVOKE.CSVectorInt_Contains(this.swigCPtr, value);
        }

        public int IndexOf(int value)
        {
            return CocoStudioEngineAdapterPINVOKE.CSVectorInt_IndexOf(this.swigCPtr, value);
        }

        public int LastIndexOf(int value)
        {
            return CocoStudioEngineAdapterPINVOKE.CSVectorInt_LastIndexOf(this.swigCPtr, value);
        }

        public bool Remove(int value)
        {
            return CocoStudioEngineAdapterPINVOKE.CSVectorInt_Remove(this.swigCPtr, value);
        }
    }
}
