// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CSVectorFloat
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
    public class CSVectorFloat : IDisposable, IList<float>, ICollection<float>, IEnumerable<float>, IEnumerable
    {
        public sealed class CSVectorFloatEnumerator : IEnumerator<float>, IDisposable, IEnumerator
        {
            private CSVectorFloat collectionRef;

            private int currentIndex;

            private object currentObject;

            private int currentSize;

            public float Current
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
                    return (float)this.currentObject;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return this.Current;
                }
            }

            public CSVectorFloatEnumerator(CSVectorFloat collection)
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

        public float this[int index]
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

        public CSVectorFloat(IntPtr cPtr, bool cMemoryOwn)
        {
            this.swigCMemOwn = cMemoryOwn;
            this.swigCPtr = new HandleRef(this, cPtr);
        }

        public static HandleRef getCPtr(CSVectorFloat obj)
        {
            return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.swigCPtr;
        }

        ~CSVectorFloat()
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
                        CocoStudioEngineAdapterPINVOKE.delete_CSVectorFloat(this.swigCPtr);
                    }
                    this.swigCPtr = new HandleRef(null, IntPtr.Zero);
                }
                GC.SuppressFinalize(this);
            }
        }

        public CSVectorFloat(ICollection c)
            : this()
        {
            if (c == null)
            {
                throw new ArgumentNullException("c");
            }
            foreach (float x in c)
            {
                this.Add(x);
            }
        }

        public void CopyTo(float[] array)
        {
            this.CopyTo(0, array, 0, this.Count);
        }

        public void CopyTo(float[] array, int arrayIndex)
        {
            this.CopyTo(0, array, arrayIndex, this.Count);
        }

        public void CopyTo(int index, float[] array, int arrayIndex, int count)
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

        IEnumerator<float> IEnumerable<float>.GetEnumerator()
        {
            return new CSVectorFloat.CSVectorFloatEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new CSVectorFloat.CSVectorFloatEnumerator(this);
        }

        public CSVectorFloat.CSVectorFloatEnumerator GetEnumerator()
        {
            return new CSVectorFloat.CSVectorFloatEnumerator(this);
        }

        public void Clear()
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorFloat_Clear(this.swigCPtr);
        }

        public void Add(float x)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorFloat_Add(this.swigCPtr, x);
        }

        private uint size()
        {
            return CocoStudioEngineAdapterPINVOKE.CSVectorFloat_size(this.swigCPtr);
        }

        private uint capacity()
        {
            return CocoStudioEngineAdapterPINVOKE.CSVectorFloat_capacity(this.swigCPtr);
        }

        private void reserve(uint n)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorFloat_reserve(this.swigCPtr, n);
        }

        public CSVectorFloat()
            : this(CocoStudioEngineAdapterPINVOKE.new_CSVectorFloat__SWIG_0(), true)
        {
        }

        public CSVectorFloat(CSVectorFloat other)
            : this(CocoStudioEngineAdapterPINVOKE.new_CSVectorFloat__SWIG_1(CSVectorFloat.getCPtr(other)), true)
        {
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public CSVectorFloat(int capacity)
            : this(CocoStudioEngineAdapterPINVOKE.new_CSVectorFloat__SWIG_2(capacity), true)
        {
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        private float getitemcopy(int index)
        {
            float result = CocoStudioEngineAdapterPINVOKE.CSVectorFloat_getitemcopy(this.swigCPtr, index);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
            return result;
        }

        private float getitem(int index)
        {
            float result = CocoStudioEngineAdapterPINVOKE.CSVectorFloat_getitem(this.swigCPtr, index);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
            return result;
        }

        private void setitem(int index, float val)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorFloat_setitem(this.swigCPtr, index, val);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public void AddRange(CSVectorFloat values)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorFloat_AddRange(this.swigCPtr, CSVectorFloat.getCPtr(values));
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public CSVectorFloat GetRange(int index, int count)
        {
            IntPtr intPtr = CocoStudioEngineAdapterPINVOKE.CSVectorFloat_GetRange(this.swigCPtr, index, count);
            CSVectorFloat result = (intPtr == IntPtr.Zero) ? null : new CSVectorFloat(intPtr, true);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
            return result;
        }

        public void Insert(int index, float x)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorFloat_Insert(this.swigCPtr, index, x);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public void InsertRange(int index, CSVectorFloat values)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorFloat_InsertRange(this.swigCPtr, index, CSVectorFloat.getCPtr(values));
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public void RemoveAt(int index)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorFloat_RemoveAt(this.swigCPtr, index);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public void RemoveRange(int index, int count)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorFloat_RemoveRange(this.swigCPtr, index, count);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public static CSVectorFloat Repeat(float value, int count)
        {
            IntPtr intPtr = CocoStudioEngineAdapterPINVOKE.CSVectorFloat_Repeat(value, count);
            CSVectorFloat result = (intPtr == IntPtr.Zero) ? null : new CSVectorFloat(intPtr, true);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
            return result;
        }

        public void Reverse()
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorFloat_Reverse__SWIG_0(this.swigCPtr);
        }

        public void Reverse(int index, int count)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorFloat_Reverse__SWIG_1(this.swigCPtr, index, count);
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public void SetRange(int index, CSVectorFloat values)
        {
            CocoStudioEngineAdapterPINVOKE.CSVectorFloat_SetRange(this.swigCPtr, index, CSVectorFloat.getCPtr(values));
            if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Pending)
            {
                throw CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public bool Contains(float value)
        {
            return CocoStudioEngineAdapterPINVOKE.CSVectorFloat_Contains(this.swigCPtr, value);
        }

        public int IndexOf(float value)
        {
            return CocoStudioEngineAdapterPINVOKE.CSVectorFloat_IndexOf(this.swigCPtr, value);
        }

        public int LastIndexOf(float value)
        {
            return CocoStudioEngineAdapterPINVOKE.CSVectorFloat_LastIndexOf(this.swigCPtr, value);
        }

        public bool Remove(float value)
        {
            return CocoStudioEngineAdapterPINVOKE.CSVectorFloat_Remove(this.swigCPtr, value);
        }
    } 
}
