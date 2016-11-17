// Decompiled with JetBrains decompiler
// Type: CocoStudio.UndoManager.ArgumentValidator
// Assembly: CocoStudio.UndoManager, Version=0.0.0.1, Culture=neutral, PublicKeyToken=null
// MVID: DCCDCB4E-BDF1-43E5-865A-77CF1074DD9D
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UndoManager.dll

using System;

namespace CocoStudio.UndoManager
{
  public static class ArgumentValidator
  {
    public static T AssertNotNull<T>(T value, string parameterName) where T : class
    {
      if ((object) value == null)
        throw new ArgumentNullException(parameterName);
      return value;
    }

    public static string AssertNotNullOrEmpty(string value, string parameterName)
    {
      if (value == null)
        throw new ArgumentNullException(parameterName);
      if (string.IsNullOrEmpty(value))
        throw new ArgumentException("Argument should not be an empty string.", parameterName);
      return value;
    }

    public static string AssertNotNullOrWhiteSpace(string value, string parameterName)
    {
      if (value == null || value.Trim().Length == 0)
        throw new ArgumentException("Parameter should not be null or white space.", parameterName);
      return value;
    }

    public static Guid AssertNotEmpty(Guid value, string parameterName)
    {
      if (value == Guid.Empty)
        throw new ArgumentException("Parameter should not be an empty Guid.", parameterName);
      return value;
    }

    public static int AssertGreaterThan(int value, int expected, string parameterName)
    {
      if (value > expected)
        return value;
      throw new ArgumentOutOfRangeException("Argument should be greater than " + (object) expected, parameterName);
    }

    public static double AssertGreaterThan(double value, double expected, string parameterName)
    {
      if (value > expected)
        return value;
      throw new ArgumentOutOfRangeException("Argument should be greater than " + (object) expected, parameterName);
    }

    public static int AssertGreaterThanOrEqual(int value, int expected, string parameterName)
    {
      if (value >= expected)
        return value;
      throw new ArgumentOutOfRangeException("Argument should be greater than or equal to " + (object) expected, parameterName);
    }

    public static double AssertGreaterThanOrEqual(double value, double expected, string parameterName)
    {
      if (value >= expected)
        return value;
      throw new ArgumentOutOfRangeException("Argument should be greater than or equal to " + (object) expected, parameterName);
    }

    public static int AssertLessThan(int value, int expected, string parameterName)
    {
      if (value >= expected)
        throw new ArgumentOutOfRangeException("Argument should be less than " + (object) expected, parameterName);
      return value;
    }

    public static double AssertLessThan(double value, double expected, string parameterName)
    {
      if (value >= expected)
        throw new ArgumentOutOfRangeException("Argument should be less than " + (object) expected, parameterName);
      return value;
    }

    public static int AssertLessThanOrEqual(int value, int expected, string parameterName)
    {
      if (value > expected)
        throw new ArgumentOutOfRangeException("Argument should be less than or equal to " + (object) expected, parameterName);
      return value;
    }

    public static double AssertLessThanOrEqual(double value, double expected, string parameterName)
    {
      if (value > expected)
        throw new ArgumentOutOfRangeException("Argument should be less than or equal to " + (object) expected, parameterName);
      return value;
    }

    public static T AssertNotNullAndOfType<T>(object value, string parameterName) where T : class
    {
      if (value == null)
        throw new ArgumentNullException(parameterName);
      T obj = value as T;
      if ((object) obj == null)
        throw new ArgumentException(string.Format("Expected argument of type " + (object) typeof (T) + ", but was " + (object) value.GetType(), (object) typeof (T), (object) value.GetType()), parameterName);
      return obj;
    }
  }
}
