// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSVectorDouble
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
    public class CSVectorDouble : IDisposable, IList<double>, ICollection<double>, IEnumerable<double>, IEnumerable
    {
        public sealed class CSVectorDoubleEnumerator : IEnumerator<double>, IDisposable, IEnumerator
        {
            private CSVectorDouble collectionRef;

            private int currentIndex;

            private object currentObject;

            private int currentSize;

            public double Current
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
                    return (double)this.currentObject;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return this.Current;
                }
            }

            public CSVectorDoubleEnumerator(CSVectorDouble collection)
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

        public double this[int index]
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

        public CSVectorDouble(IntPtr cPtr, bool cMemoryOwn)
        {
            this.swigCMemOwn = cMemoryOwn;
            this.swigCPtr = new HandleRef(this, cPtr);
        }

        public static HandleRef getCPtr(CSVectorDouble obj)
        {
            return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
        }

        ~CSVectorDouble()
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
                        CocoStudioEngineAdapterPINVOKE.delete_CSVectorDouble(this.swigCPtr);
                    }
                    this.swigCPtr = new HandleRef(null, IntPtr.Zero);
                }
                GC.SuppressFinalize(this);
            }
        }

        public CSVectorDouble(ICollection c)
            : this()
        {
            if (c == null)
            {
                throw new ArgumentNullException("c");
            }
            foreach (double x in c)
            {
                this.Add(x);
            }
        }

        public void CopyTo(double[] array)
        {
            this.CopyTo(0, array, 0, this.Count);
        }

        public void CopyTo(double[] array, int arrayIndex)
        {
            this.CopyTo(0, array, arrayIndex, this.Count);
        }

        public void CopyTo(int index, double[] array, int arrayIndex, int count)
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

        IEnumerator<double> IEnumerable<double>.GetEnumerator()
        {
            return new CSVectorDouble.CSVectorDoubleEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new CSVectorDouble.CSVectorDoubleEnumerator(this);
        }

        public CSVectorDouble.CSVectorDoubleEnumerator GetEnumerator()
        {
            return new CSVectorDouble.CSVectorDoubleEnumerator(this);
        }

        public void Clear()
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorDouble_Clear(this.swigCPtr);
        }

        public void Add(double x)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorDouble_Add(this.swigCPtr, x);
        }

        private uint size()
        {
            return CocoStudioEngineAdapterPINVOKE.CSVectorDouble_size(this.swigCPtr);
        }

        private uint capacity()
        {
            return CocoStudioEngineAdapterPINVOKE.CSVectorDouble_capacity(this.swigCPtr);
        }

        private void reserve(uint n)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorDouble_reserve(this.swigCPtr, n);
        }

        public CSVectorDouble()
            : this(CocoStudioEngineAdapterPINVOKE.new_CSVectorDouble__SWIG_0(), true)
        {
        }

        public CSVectorDouble(CSVectorDouble other)
            : this(CocoStudioEngineAdapterPINVOKE.new_CSVectorDouble__SWIG_1(CSVectorDouble.getCPtr(other)), true)
        {
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public CSVectorDouble(int capacity)
            : this(CocoStudioEngineAdapterPINVOKE.new_CSVectorDouble__SWIG_2(capacity), true)
        {
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        private double getitemcopy(int index)
        {
            double result = CocoStudioEngineAdapterPINVOKE.CSVectorDouble_getitemcopy(this.swigCPtr, index);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
            return result;
        }

        private double getitem(int index)
        {
            double result = CocoStudioEngineAdapterPINVOKE.CSVectorDouble_getitem(this.swigCPtr, index);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
            return result;
        }

        private void setitem(int index, double val)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorDouble_setitem(this.swigCPtr, index, val);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public void AddRange(CSVectorDouble values)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorDouble_AddRange(this.swigCPtr, CSVectorDouble.getCPtr(values));
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public CSVectorDouble GetRange(int index, int count)
        {
            IntPtr intPtr = CocoStudioEngineAdapterPINVOKE.CSVectorDouble_GetRange(this.swigCPtr, index, count);
            CSVectorDouble result = (intPtr == IntPtr.Zero) ? null : new CSVectorDouble(intPtr, true);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
            return result;
        }

        public void Insert(int index, double x)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorDouble_Insert(this.swigCPtr, index, x);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public void InsertRange(int index, CSVectorDouble values)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorDouble_InsertRange(this.swigCPtr, index, CSVectorDouble.getCPtr(values));
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public void RemoveAt(int index)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorDouble_RemoveAt(this.swigCPtr, index);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public void RemoveRange(int index, int count)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorDouble_RemoveRange(this.swigCPtr, index, count);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public static CSVectorDouble Repeat(double value, int count)
        {
            IntPtr intPtr = CocoStudioEngineAdapterPINVOKE.CSVectorDouble_Repeat(value, count);
            CSVectorDouble result = (intPtr == IntPtr.Zero) ? null : new CSVectorDouble(intPtr, true);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
            return result;
        }

        public void Reverse()
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorDouble_Reverse__SWIG_0(this.swigCPtr);
        }

        public void Reverse(int index, int count)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorDouble_Reverse__SWIG_1(this.swigCPtr, index, count);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public void SetRange(int index, CSVectorDouble values)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorDouble_SetRange(this.swigCPtr, index, CSVectorDouble.getCPtr(values));
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public bool Contains(double value)
        {
            return CocoStudioEngineAdapterPINVOKE.CSVectorDouble_Contains(this.swigCPtr, value);
        }

        public int IndexOf(double value)
        {
            return CocoStudioEngineAdapterPINVOKE.CSVectorDouble_IndexOf(this.swigCPtr, value);
        }

        public int LastIndexOf(double value)
        {
            return CocoStudioEngineAdapterPINVOKE.CSVectorDouble_LastIndexOf(this.swigCPtr, value);
        }

        public bool Remove(double value)
        {
            return CocoStudioEngineAdapterPINVOKE.CSVectorDouble_Remove(this.swigCPtr, value);
        }
    } 
}
