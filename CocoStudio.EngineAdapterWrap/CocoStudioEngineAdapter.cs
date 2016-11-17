// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CocoStudioEngineAdapter
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

namespace CocoStudio.EngineAdapterWrap
{
  public class CocoStudioEngineAdapter
  {
    public static readonly int CC_ENABLE_CACHE_TEXTURE_DATA = CocoStudioEngineAdapterPINVOKE.CC_ENABLE_CACHE_TEXTURE_DATA_get();
    public static readonly int CC_REBIND_INDICES_BUFFER = CocoStudioEngineAdapterPINVOKE.CC_REBIND_INDICES_BUFFER_get();
    public static readonly string CC_FORMAT_PRINTF_SIZE_T = CocoStudioEngineAdapterPINVOKE.CC_FORMAT_PRINTF_SIZE_T_get();
    public static readonly int NULL = CocoStudioEngineAdapterPINVOKE.NULL_get();
    public static readonly double MATH_FLOAT_SMALL = CocoStudioEngineAdapterPINVOKE.MATH_FLOAT_SMALL_get();
    public static readonly double MATH_TOLERANCE = CocoStudioEngineAdapterPINVOKE.MATH_TOLERANCE_get();
    public static readonly double MATH_PIOVER2 = CocoStudioEngineAdapterPINVOKE.MATH_PIOVER2_get();
    public static readonly double MATH_EPSILON = CocoStudioEngineAdapterPINVOKE.MATH_EPSILON_get();

    public static string STD_STRING_EMPTY
    {
      get
      {
        return CocoStudioEngineAdapterPINVOKE.STD_STRING_EMPTY_get();
      }
    }

    public static float clampf(float value, float min_inclusive, float max_inclusive)
    {
      return CocoStudioEngineAdapterPINVOKE.clampf(value, min_inclusive, max_inclusive);
    }

    public static string CocosGUIVersion()
    {
      return CocoStudioEngineAdapterPINVOKE.CocosGUIVersion();
    }
  }
}
