// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.UTF8Marshaler
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using System;
using System.Runtime.InteropServices;
using System.Text;

namespace CocoStudio.EngineAdapterWrap
{
  public class UTF8Marshaler : ICustomMarshaler
  {
    private static UTF8Marshaler static_instance;

    public IntPtr MarshalManagedToNative(object managedObj)
    {
      if (managedObj == null)
        return IntPtr.Zero;
      if (!(managedObj is string))
        throw new MarshalDirectiveException("UTF8Marshaler must be used on a string.");
      byte[] bytes = Encoding.UTF8.GetBytes((string) managedObj);
      IntPtr destination = Marshal.AllocHGlobal(bytes.Length + 1);
      Marshal.Copy(bytes, 0, destination, bytes.Length);
      Marshal.WriteByte(destination + bytes.Length, (byte) 0);
      return destination;
    }

    public unsafe object MarshalNativeToManaged(IntPtr pNativeData)
    {
      byte* numPtr = (byte*) (void*) pNativeData;
      while ((int) *numPtr != 0)
        ++numPtr;
      int length = (int) (numPtr - (byte*) (void*) pNativeData);
      byte[] numArray = new byte[length];
      Marshal.Copy(pNativeData, numArray, 0, length);
      return (object) Encoding.UTF8.GetString(numArray);
    }

    public void CleanUpNativeData(IntPtr pNativeData)
    {
      Marshal.FreeHGlobal(pNativeData);
    }

    public void CleanUpManagedData(object managedObj)
    {
    }

    public int GetNativeDataSize()
    {
      return -1;
    }

    public static ICustomMarshaler GetInstance(string cookie)
    {
      if (UTF8Marshaler.static_instance == null)
        return (ICustomMarshaler) (UTF8Marshaler.static_instance = new UTF8Marshaler());
      return (ICustomMarshaler) UTF8Marshaler.static_instance;
    }
  }
}
