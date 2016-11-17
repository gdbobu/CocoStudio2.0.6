// Decompiled with JetBrains decompiler
// Type: CocoStudio.EngineAdapterWrap.CocoStudioEngineAdapterPINVOKE
// Assembly: CocoStudio.EngineAdapterWrap, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E8108297-9417-436C-BAF0-30080D2F7BF3
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.EngineAdapterWrap.dll

using System;
using System.IO;
using System.Runtime.InteropServices;

namespace CocoStudio.EngineAdapterWrap
{
  internal class CocoStudioEngineAdapterPINVOKE
  {
    protected static CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper swigExceptionHelper = new CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper();
    protected static CocoStudioEngineAdapterPINVOKE.SWIGStringHelper swigStringHelper = new CocoStudioEngineAdapterPINVOKE.SWIGStringHelper();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorInt_Clear")]
    public static extern void CSVectorInt_Clear(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorInt_Add")]
    public static extern void CSVectorInt_Add(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorInt_size")]
    public static extern uint CSVectorInt_size(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorInt_capacity")]
    public static extern uint CSVectorInt_capacity(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorInt_reserve")]
    public static extern void CSVectorInt_reserve(HandleRef jarg1, uint jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSVectorInt__SWIG_0")]
    public static extern IntPtr new_CSVectorInt__SWIG_0();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSVectorInt__SWIG_1")]
    public static extern IntPtr new_CSVectorInt__SWIG_1(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSVectorInt__SWIG_2")]
    public static extern IntPtr new_CSVectorInt__SWIG_2(int jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorInt_getitemcopy")]
    public static extern int CSVectorInt_getitemcopy(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorInt_getitem")]
    public static extern int CSVectorInt_getitem(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorInt_setitem")]
    public static extern void CSVectorInt_setitem(HandleRef jarg1, int jarg2, int jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorInt_AddRange")]
    public static extern void CSVectorInt_AddRange(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorInt_GetRange")]
    public static extern IntPtr CSVectorInt_GetRange(HandleRef jarg1, int jarg2, int jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorInt_Insert")]
    public static extern void CSVectorInt_Insert(HandleRef jarg1, int jarg2, int jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorInt_InsertRange")]
    public static extern void CSVectorInt_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorInt_RemoveAt")]
    public static extern void CSVectorInt_RemoveAt(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorInt_RemoveRange")]
    public static extern void CSVectorInt_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorInt_Repeat")]
    public static extern IntPtr CSVectorInt_Repeat(int jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorInt_Reverse__SWIG_0")]
    public static extern void CSVectorInt_Reverse__SWIG_0(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorInt_Reverse__SWIG_1")]
    public static extern void CSVectorInt_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorInt_SetRange")]
    public static extern void CSVectorInt_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorInt_Contains")]
    public static extern bool CSVectorInt_Contains(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorInt_IndexOf")]
    public static extern int CSVectorInt_IndexOf(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorInt_LastIndexOf")]
    public static extern int CSVectorInt_LastIndexOf(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorInt_Remove")]
    public static extern bool CSVectorInt_Remove(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSVectorInt")]
    public static extern void delete_CSVectorInt(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorFloat_Clear")]
    public static extern void CSVectorFloat_Clear(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorFloat_Add")]
    public static extern void CSVectorFloat_Add(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorFloat_size")]
    public static extern uint CSVectorFloat_size(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorFloat_capacity")]
    public static extern uint CSVectorFloat_capacity(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorFloat_reserve")]
    public static extern void CSVectorFloat_reserve(HandleRef jarg1, uint jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSVectorFloat__SWIG_0")]
    public static extern IntPtr new_CSVectorFloat__SWIG_0();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSVectorFloat__SWIG_1")]
    public static extern IntPtr new_CSVectorFloat__SWIG_1(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSVectorFloat__SWIG_2")]
    public static extern IntPtr new_CSVectorFloat__SWIG_2(int jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorFloat_getitemcopy")]
    public static extern float CSVectorFloat_getitemcopy(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorFloat_getitem")]
    public static extern float CSVectorFloat_getitem(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorFloat_setitem")]
    public static extern void CSVectorFloat_setitem(HandleRef jarg1, int jarg2, float jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorFloat_AddRange")]
    public static extern void CSVectorFloat_AddRange(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorFloat_GetRange")]
    public static extern IntPtr CSVectorFloat_GetRange(HandleRef jarg1, int jarg2, int jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorFloat_Insert")]
    public static extern void CSVectorFloat_Insert(HandleRef jarg1, int jarg2, float jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorFloat_InsertRange")]
    public static extern void CSVectorFloat_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorFloat_RemoveAt")]
    public static extern void CSVectorFloat_RemoveAt(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorFloat_RemoveRange")]
    public static extern void CSVectorFloat_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorFloat_Repeat")]
    public static extern IntPtr CSVectorFloat_Repeat(float jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorFloat_Reverse__SWIG_0")]
    public static extern void CSVectorFloat_Reverse__SWIG_0(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorFloat_Reverse__SWIG_1")]
    public static extern void CSVectorFloat_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorFloat_SetRange")]
    public static extern void CSVectorFloat_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorFloat_Contains")]
    public static extern bool CSVectorFloat_Contains(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorFloat_IndexOf")]
    public static extern int CSVectorFloat_IndexOf(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorFloat_LastIndexOf")]
    public static extern int CSVectorFloat_LastIndexOf(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorFloat_Remove")]
    public static extern bool CSVectorFloat_Remove(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSVectorFloat")]
    public static extern void delete_CSVectorFloat(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorDouble_Clear")]
    public static extern void CSVectorDouble_Clear(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorDouble_Add")]
    public static extern void CSVectorDouble_Add(HandleRef jarg1, double jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorDouble_size")]
    public static extern uint CSVectorDouble_size(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorDouble_capacity")]
    public static extern uint CSVectorDouble_capacity(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorDouble_reserve")]
    public static extern void CSVectorDouble_reserve(HandleRef jarg1, uint jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSVectorDouble__SWIG_0")]
    public static extern IntPtr new_CSVectorDouble__SWIG_0();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSVectorDouble__SWIG_1")]
    public static extern IntPtr new_CSVectorDouble__SWIG_1(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSVectorDouble__SWIG_2")]
    public static extern IntPtr new_CSVectorDouble__SWIG_2(int jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorDouble_getitemcopy")]
    public static extern double CSVectorDouble_getitemcopy(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorDouble_getitem")]
    public static extern double CSVectorDouble_getitem(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorDouble_setitem")]
    public static extern void CSVectorDouble_setitem(HandleRef jarg1, int jarg2, double jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorDouble_AddRange")]
    public static extern void CSVectorDouble_AddRange(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorDouble_GetRange")]
    public static extern IntPtr CSVectorDouble_GetRange(HandleRef jarg1, int jarg2, int jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorDouble_Insert")]
    public static extern void CSVectorDouble_Insert(HandleRef jarg1, int jarg2, double jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorDouble_InsertRange")]
    public static extern void CSVectorDouble_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorDouble_RemoveAt")]
    public static extern void CSVectorDouble_RemoveAt(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorDouble_RemoveRange")]
    public static extern void CSVectorDouble_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorDouble_Repeat")]
    public static extern IntPtr CSVectorDouble_Repeat(double jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorDouble_Reverse__SWIG_0")]
    public static extern void CSVectorDouble_Reverse__SWIG_0(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorDouble_Reverse__SWIG_1")]
    public static extern void CSVectorDouble_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorDouble_SetRange")]
    public static extern void CSVectorDouble_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorDouble_Contains")]
    public static extern bool CSVectorDouble_Contains(HandleRef jarg1, double jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorDouble_IndexOf")]
    public static extern int CSVectorDouble_IndexOf(HandleRef jarg1, double jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorDouble_LastIndexOf")]
    public static extern int CSVectorDouble_LastIndexOf(HandleRef jarg1, double jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorDouble_Remove")]
    public static extern bool CSVectorDouble_Remove(HandleRef jarg1, double jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSVectorDouble")]
    public static extern void delete_CSVectorDouble(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorString_Clear")]
    public static extern void CSVectorString_Clear(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorString_Add")]
    public static extern void CSVectorString_Add(HandleRef jarg1, string jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorString_size")]
    public static extern uint CSVectorString_size(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorString_capacity")]
    public static extern uint CSVectorString_capacity(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorString_reserve")]
    public static extern void CSVectorString_reserve(HandleRef jarg1, uint jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSVectorString__SWIG_0")]
    public static extern IntPtr new_CSVectorString__SWIG_0();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSVectorString__SWIG_1")]
    public static extern IntPtr new_CSVectorString__SWIG_1(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSVectorString__SWIG_2")]
    public static extern IntPtr new_CSVectorString__SWIG_2(int jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorString_getitemcopy")]
    public static extern string CSVectorString_getitemcopy(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorString_getitem")]
    public static extern string CSVectorString_getitem(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorString_setitem")]
    public static extern void CSVectorString_setitem(HandleRef jarg1, int jarg2, string jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorString_AddRange")]
    public static extern void CSVectorString_AddRange(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorString_GetRange")]
    public static extern IntPtr CSVectorString_GetRange(HandleRef jarg1, int jarg2, int jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorString_Insert")]
    public static extern void CSVectorString_Insert(HandleRef jarg1, int jarg2, string jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorString_InsertRange")]
    public static extern void CSVectorString_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorString_RemoveAt")]
    public static extern void CSVectorString_RemoveAt(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorString_RemoveRange")]
    public static extern void CSVectorString_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorString_Repeat")]
    public static extern IntPtr CSVectorString_Repeat(string jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorString_Reverse__SWIG_0")]
    public static extern void CSVectorString_Reverse__SWIG_0(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorString_Reverse__SWIG_1")]
    public static extern void CSVectorString_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorString_SetRange")]
    public static extern void CSVectorString_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorString_Contains")]
    public static extern bool CSVectorString_Contains(HandleRef jarg1, string jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorString_IndexOf")]
    public static extern int CSVectorString_IndexOf(HandleRef jarg1, string jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorString_LastIndexOf")]
    public static extern int CSVectorString_LastIndexOf(HandleRef jarg1, string jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorString_Remove")]
    public static extern bool CSVectorString_Remove(HandleRef jarg1, string jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSVectorString")]
    public static extern void delete_CSVectorString(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CC_ENABLE_CACHE_TEXTURE_DATA_get")]
    public static extern int CC_ENABLE_CACHE_TEXTURE_DATA_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CC_REBIND_INDICES_BUFFER_get")]
    public static extern int CC_REBIND_INDICES_BUFFER_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CC_FORMAT_PRINTF_SIZE_T_get")]
    public static extern string CC_FORMAT_PRINTF_SIZE_T_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_NULL_get")]
    public static extern int NULL_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_MATH_FLOAT_SMALL_get")]
    public static extern double MATH_FLOAT_SMALL_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_MATH_TOLERANCE_get")]
    public static extern double MATH_TOLERANCE_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_MATH_PIOVER2_get")]
    public static extern double MATH_PIOVER2_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_MATH_EPSILON_get")]
    public static extern double MATH_EPSILON_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_clampf")]
    public static extern float clampf(float jarg1, float jarg2, float jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_x_set")]
    public static extern void Vec2_x_set(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_x_get")]
    public static extern float Vec2_x_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_y_set")]
    public static extern void Vec2_y_set(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_y_get")]
    public static extern float Vec2_y_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_Vec2__SWIG_0")]
    public static extern IntPtr new_Vec2__SWIG_0();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_Vec2__SWIG_1")]
    public static extern IntPtr new_Vec2__SWIG_1(float jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_Vec2__SWIG_2")]
    public static extern IntPtr new_Vec2__SWIG_2(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_Vec2__SWIG_3")]
    public static extern IntPtr new_Vec2__SWIG_3(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_Vec2")]
    public static extern void delete_Vec2(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_isZero")]
    public static extern bool Vec2_isZero(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_isOne")]
    public static extern bool Vec2_isOne(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_angle")]
    public static extern float Vec2_angle(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_add__SWIG_0")]
    public static extern void Vec2_add__SWIG_0(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_add__SWIG_1")]
    public static extern void Vec2_add__SWIG_1(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_clamp__SWIG_0")]
    public static extern void Vec2_clamp__SWIG_0(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_clamp__SWIG_1")]
    public static extern void Vec2_clamp__SWIG_1(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, HandleRef jarg4);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_distance")]
    public static extern float Vec2_distance(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_distanceSquared")]
    public static extern float Vec2_distanceSquared(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_dot__SWIG_0")]
    public static extern float Vec2_dot__SWIG_0(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_length")]
    public static extern float Vec2_length(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_lengthSquared")]
    public static extern float Vec2_lengthSquared(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_negate")]
    public static extern void Vec2_negate(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_normalize")]
    public static extern void Vec2_normalize(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_getNormalized")]
    public static extern IntPtr Vec2_getNormalized(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_scale__SWIG_0")]
    public static extern void Vec2_scale__SWIG_0(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_scale__SWIG_1")]
    public static extern void Vec2_scale__SWIG_1(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_rotate__SWIG_0")]
    public static extern void Vec2_rotate__SWIG_0(HandleRef jarg1, HandleRef jarg2, float jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_set__SWIG_0")]
    public static extern void Vec2_set__SWIG_0(HandleRef jarg1, float jarg2, float jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_set__SWIG_1")]
    public static extern void Vec2_set__SWIG_1(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_set__SWIG_2")]
    public static extern void Vec2_set__SWIG_2(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_subtract__SWIG_0")]
    public static extern void Vec2_subtract__SWIG_0(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_subtract__SWIG_1")]
    public static extern void Vec2_subtract__SWIG_1(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_smooth")]
    public static extern void Vec2_smooth(HandleRef jarg1, HandleRef jarg2, float jarg3, float jarg4);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_setPoint")]
    public static extern void Vec2_setPoint(HandleRef jarg1, float jarg2, float jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_equals")]
    public static extern bool Vec2_equals(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_fuzzyEquals")]
    public static extern bool Vec2_fuzzyEquals(HandleRef jarg1, HandleRef jarg2, float jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_getLength")]
    public static extern float Vec2_getLength(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_getLengthSq")]
    public static extern float Vec2_getLengthSq(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_getDistanceSq")]
    public static extern float Vec2_getDistanceSq(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_getDistance")]
    public static extern float Vec2_getDistance(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_getAngle__SWIG_0")]
    public static extern float Vec2_getAngle__SWIG_0(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_getAngle__SWIG_1")]
    public static extern float Vec2_getAngle__SWIG_1(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_cross")]
    public static extern float Vec2_cross(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_getPerp")]
    public static extern IntPtr Vec2_getPerp(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_getMidpoint")]
    public static extern IntPtr Vec2_getMidpoint(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_getClampPoint")]
    public static extern IntPtr Vec2_getClampPoint(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_getRPerp")]
    public static extern IntPtr Vec2_getRPerp(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_project")]
    public static extern IntPtr Vec2_project(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_rotate__SWIG_1")]
    public static extern IntPtr Vec2_rotate__SWIG_1(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_unrotate")]
    public static extern IntPtr Vec2_unrotate(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_lerp")]
    public static extern IntPtr Vec2_lerp(HandleRef jarg1, HandleRef jarg2, float jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_rotateByAngle")]
    public static extern IntPtr Vec2_rotateByAngle(HandleRef jarg1, HandleRef jarg2, float jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_forAngle")]
    public static extern IntPtr Vec2_forAngle(float jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_isLineOverlap")]
    public static extern bool Vec2_isLineOverlap(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, HandleRef jarg4);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_isLineParallel")]
    public static extern bool Vec2_isLineParallel(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, HandleRef jarg4);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_isSegmentOverlap__SWIG_0")]
    public static extern bool Vec2_isSegmentOverlap__SWIG_0(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, HandleRef jarg4, HandleRef jarg5, HandleRef jarg6);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_isSegmentOverlap__SWIG_1")]
    public static extern bool Vec2_isSegmentOverlap__SWIG_1(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, HandleRef jarg4, HandleRef jarg5);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_isSegmentOverlap__SWIG_2")]
    public static extern bool Vec2_isSegmentOverlap__SWIG_2(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, HandleRef jarg4);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_isSegmentIntersect")]
    public static extern bool Vec2_isSegmentIntersect(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, HandleRef jarg4);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_getIntersectPoint")]
    public static extern IntPtr Vec2_getIntersectPoint(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, HandleRef jarg4);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_ZERO_get")]
    public static extern IntPtr Vec2_ZERO_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_ONE_get")]
    public static extern IntPtr Vec2_ONE_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_UNIT_X_get")]
    public static extern IntPtr Vec2_UNIT_X_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_UNIT_Y_get")]
    public static extern IntPtr Vec2_UNIT_Y_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_ANCHOR_MIDDLE_get")]
    public static extern IntPtr Vec2_ANCHOR_MIDDLE_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_ANCHOR_BOTTOM_LEFT_get")]
    public static extern IntPtr Vec2_ANCHOR_BOTTOM_LEFT_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_ANCHOR_TOP_LEFT_get")]
    public static extern IntPtr Vec2_ANCHOR_TOP_LEFT_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_ANCHOR_BOTTOM_RIGHT_get")]
    public static extern IntPtr Vec2_ANCHOR_BOTTOM_RIGHT_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_ANCHOR_TOP_RIGHT_get")]
    public static extern IntPtr Vec2_ANCHOR_TOP_RIGHT_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_ANCHOR_MIDDLE_RIGHT_get")]
    public static extern IntPtr Vec2_ANCHOR_MIDDLE_RIGHT_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_ANCHOR_MIDDLE_LEFT_get")]
    public static extern IntPtr Vec2_ANCHOR_MIDDLE_LEFT_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_ANCHOR_MIDDLE_TOP_get")]
    public static extern IntPtr Vec2_ANCHOR_MIDDLE_TOP_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec2_ANCHOR_MIDDLE_BOTTOM_get")]
    public static extern IntPtr Vec2_ANCHOR_MIDDLE_BOTTOM_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec3_x_set")]
    public static extern void Vec3_x_set(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec3_x_get")]
    public static extern float Vec3_x_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec3_y_set")]
    public static extern void Vec3_y_set(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec3_y_get")]
    public static extern float Vec3_y_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec3_z_set")]
    public static extern void Vec3_z_set(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec3_z_get")]
    public static extern float Vec3_z_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_Vec3__SWIG_0")]
    public static extern IntPtr new_Vec3__SWIG_0();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_Vec3__SWIG_1")]
    public static extern IntPtr new_Vec3__SWIG_1(float jarg1, float jarg2, float jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_Vec3__SWIG_2")]
    public static extern IntPtr new_Vec3__SWIG_2(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_Vec3__SWIG_3")]
    public static extern IntPtr new_Vec3__SWIG_3(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec3_fromColor")]
    public static extern IntPtr Vec3_fromColor(uint jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_Vec3")]
    public static extern void delete_Vec3(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec3_isZero")]
    public static extern bool Vec3_isZero(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec3_isOne")]
    public static extern bool Vec3_isOne(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec3_angle")]
    public static extern float Vec3_angle(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec3_add__SWIG_0")]
    public static extern void Vec3_add__SWIG_0(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec3_add__SWIG_1")]
    public static extern void Vec3_add__SWIG_1(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec3_clamp__SWIG_0")]
    public static extern void Vec3_clamp__SWIG_0(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec3_clamp__SWIG_1")]
    public static extern void Vec3_clamp__SWIG_1(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3, HandleRef jarg4);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec3_cross__SWIG_0")]
    public static extern void Vec3_cross__SWIG_0(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec3_cross__SWIG_1")]
    public static extern void Vec3_cross__SWIG_1(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec3_distance")]
    public static extern float Vec3_distance(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec3_distanceSquared")]
    public static extern float Vec3_distanceSquared(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec3_dot__SWIG_0")]
    public static extern float Vec3_dot__SWIG_0(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec3_length")]
    public static extern float Vec3_length(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec3_lengthSquared")]
    public static extern float Vec3_lengthSquared(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec3_negate")]
    public static extern void Vec3_negate(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec3_normalize")]
    public static extern void Vec3_normalize(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec3_getNormalized")]
    public static extern IntPtr Vec3_getNormalized(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec3_scale")]
    public static extern void Vec3_scale(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec3_set__SWIG_0")]
    public static extern void Vec3_set__SWIG_0(HandleRef jarg1, float jarg2, float jarg3, float jarg4);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec3_set__SWIG_1")]
    public static extern void Vec3_set__SWIG_1(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec3_set__SWIG_2")]
    public static extern void Vec3_set__SWIG_2(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec3_subtract__SWIG_0")]
    public static extern void Vec3_subtract__SWIG_0(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec3_subtract__SWIG_1")]
    public static extern void Vec3_subtract__SWIG_1(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec3_smooth")]
    public static extern void Vec3_smooth(HandleRef jarg1, HandleRef jarg2, float jarg3, float jarg4);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec3_ZERO_get")]
    public static extern IntPtr Vec3_ZERO_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec3_ONE_get")]
    public static extern IntPtr Vec3_ONE_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec3_UNIT_X_get")]
    public static extern IntPtr Vec3_UNIT_X_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec3_UNIT_Y_get")]
    public static extern IntPtr Vec3_UNIT_Y_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Vec3_UNIT_Z_get")]
    public static extern IntPtr Vec3_UNIT_Z_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Size_width_set")]
    public static extern void Size_width_set(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Size_width_get")]
    public static extern float Size_width_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Size_height_set")]
    public static extern void Size_height_set(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Size_height_get")]
    public static extern float Size_height_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_Size__SWIG_0")]
    public static extern IntPtr new_Size__SWIG_0();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_Size__SWIG_1")]
    public static extern IntPtr new_Size__SWIG_1(float jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_Size__SWIG_2")]
    public static extern IntPtr new_Size__SWIG_2(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_Size__SWIG_3")]
    public static extern IntPtr new_Size__SWIG_3(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Size_setSize")]
    public static extern void Size_setSize(HandleRef jarg1, float jarg2, float jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Size_equals")]
    public static extern bool Size_equals(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Size_ZERO_get")]
    public static extern IntPtr Size_ZERO_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_Size")]
    public static extern void delete_Size(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Rect_origin_set")]
    public static extern void Rect_origin_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Rect_origin_get")]
    public static extern IntPtr Rect_origin_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Rect_size_set")]
    public static extern void Rect_size_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Rect_size_get")]
    public static extern IntPtr Rect_size_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_Rect__SWIG_0")]
    public static extern IntPtr new_Rect__SWIG_0();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_Rect__SWIG_1")]
    public static extern IntPtr new_Rect__SWIG_1(float jarg1, float jarg2, float jarg3, float jarg4);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_Rect__SWIG_2")]
    public static extern IntPtr new_Rect__SWIG_2(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Rect_setRect")]
    public static extern void Rect_setRect(HandleRef jarg1, float jarg2, float jarg3, float jarg4, float jarg5);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Rect_getMinX")]
    public static extern float Rect_getMinX(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Rect_getMidX")]
    public static extern float Rect_getMidX(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Rect_getMaxX")]
    public static extern float Rect_getMaxX(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Rect_getMinY")]
    public static extern float Rect_getMinY(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Rect_getMidY")]
    public static extern float Rect_getMidY(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Rect_getMaxY")]
    public static extern float Rect_getMaxY(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Rect_equals")]
    public static extern bool Rect_equals(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Rect_containsPoint")]
    public static extern bool Rect_containsPoint(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Rect_intersectsRect")]
    public static extern bool Rect_intersectsRect(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Rect_unionWithRect")]
    public static extern IntPtr Rect_unionWithRect(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Rect_ZERO_get")]
    public static extern IntPtr Rect_ZERO_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_Rect")]
    public static extern void delete_Rect(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_Color3B__SWIG_0")]
    public static extern IntPtr new_Color3B__SWIG_0();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_Color3B__SWIG_1")]
    public static extern IntPtr new_Color3B__SWIG_1(byte jarg1, byte jarg2, byte jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_Color3B__SWIG_2")]
    public static extern IntPtr new_Color3B__SWIG_2(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_Color3B__SWIG_3")]
    public static extern IntPtr new_Color3B__SWIG_3(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color3B_equals")]
    public static extern bool Color3B_equals(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color3B_r_set")]
    public static extern void Color3B_r_set(HandleRef jarg1, byte jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color3B_r_get")]
    public static extern byte Color3B_r_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color3B_g_set")]
    public static extern void Color3B_g_set(HandleRef jarg1, byte jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color3B_g_get")]
    public static extern byte Color3B_g_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color3B_b_set")]
    public static extern void Color3B_b_set(HandleRef jarg1, byte jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color3B_b_get")]
    public static extern byte Color3B_b_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color3B_WHITE_get")]
    public static extern IntPtr Color3B_WHITE_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color3B_YELLOW_get")]
    public static extern IntPtr Color3B_YELLOW_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color3B_BLUE_get")]
    public static extern IntPtr Color3B_BLUE_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color3B_GREEN_get")]
    public static extern IntPtr Color3B_GREEN_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color3B_RED_get")]
    public static extern IntPtr Color3B_RED_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color3B_MAGENTA_get")]
    public static extern IntPtr Color3B_MAGENTA_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color3B_BLACK_get")]
    public static extern IntPtr Color3B_BLACK_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color3B_ORANGE_get")]
    public static extern IntPtr Color3B_ORANGE_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color3B_GRAY_get")]
    public static extern IntPtr Color3B_GRAY_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_Color3B")]
    public static extern void delete_Color3B(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_Color4B__SWIG_0")]
    public static extern IntPtr new_Color4B__SWIG_0();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_Color4B__SWIG_1")]
    public static extern IntPtr new_Color4B__SWIG_1(byte jarg1, byte jarg2, byte jarg3, byte jarg4);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_Color4B__SWIG_2")]
    public static extern IntPtr new_Color4B__SWIG_2(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_Color4B__SWIG_3")]
    public static extern IntPtr new_Color4B__SWIG_3(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color4B_r_set")]
    public static extern void Color4B_r_set(HandleRef jarg1, byte jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color4B_r_get")]
    public static extern byte Color4B_r_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color4B_g_set")]
    public static extern void Color4B_g_set(HandleRef jarg1, byte jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color4B_g_get")]
    public static extern byte Color4B_g_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color4B_b_set")]
    public static extern void Color4B_b_set(HandleRef jarg1, byte jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color4B_b_get")]
    public static extern byte Color4B_b_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color4B_a_set")]
    public static extern void Color4B_a_set(HandleRef jarg1, byte jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color4B_a_get")]
    public static extern byte Color4B_a_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color4B_WHITE_get")]
    public static extern IntPtr Color4B_WHITE_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color4B_YELLOW_get")]
    public static extern IntPtr Color4B_YELLOW_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color4B_BLUE_get")]
    public static extern IntPtr Color4B_BLUE_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color4B_GREEN_get")]
    public static extern IntPtr Color4B_GREEN_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color4B_RED_get")]
    public static extern IntPtr Color4B_RED_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color4B_MAGENTA_get")]
    public static extern IntPtr Color4B_MAGENTA_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color4B_BLACK_get")]
    public static extern IntPtr Color4B_BLACK_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color4B_ORANGE_get")]
    public static extern IntPtr Color4B_ORANGE_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color4B_GRAY_get")]
    public static extern IntPtr Color4B_GRAY_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_Color4B")]
    public static extern void delete_Color4B(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_Color4F__SWIG_0")]
    public static extern IntPtr new_Color4F__SWIG_0();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_Color4F__SWIG_1")]
    public static extern IntPtr new_Color4F__SWIG_1(float jarg1, float jarg2, float jarg3, float jarg4);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_Color4F__SWIG_2")]
    public static extern IntPtr new_Color4F__SWIG_2(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_Color4F__SWIG_3")]
    public static extern IntPtr new_Color4F__SWIG_3(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color4F_equals")]
    public static extern bool Color4F_equals(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color4F_r_set")]
    public static extern void Color4F_r_set(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color4F_r_get")]
    public static extern float Color4F_r_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color4F_g_set")]
    public static extern void Color4F_g_set(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color4F_g_get")]
    public static extern float Color4F_g_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color4F_b_set")]
    public static extern void Color4F_b_set(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color4F_b_get")]
    public static extern float Color4F_b_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color4F_a_set")]
    public static extern void Color4F_a_set(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color4F_a_get")]
    public static extern float Color4F_a_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color4F_WHITE_get")]
    public static extern IntPtr Color4F_WHITE_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color4F_YELLOW_get")]
    public static extern IntPtr Color4F_YELLOW_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color4F_BLUE_get")]
    public static extern IntPtr Color4F_BLUE_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color4F_GREEN_get")]
    public static extern IntPtr Color4F_GREEN_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color4F_RED_get")]
    public static extern IntPtr Color4F_RED_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color4F_MAGENTA_get")]
    public static extern IntPtr Color4F_MAGENTA_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color4F_BLACK_get")]
    public static extern IntPtr Color4F_BLACK_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color4F_ORANGE_get")]
    public static extern IntPtr Color4F_ORANGE_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Color4F_GRAY_get")]
    public static extern IntPtr Color4F_GRAY_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_Color4F")]
    public static extern void delete_Color4F(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_Tex2F__SWIG_0")]
    public static extern IntPtr new_Tex2F__SWIG_0(float jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_Tex2F__SWIG_1")]
    public static extern IntPtr new_Tex2F__SWIG_1();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Tex2F_u_set")]
    public static extern void Tex2F_u_set(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Tex2F_u_get")]
    public static extern float Tex2F_u_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Tex2F_v_set")]
    public static extern void Tex2F_v_set(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Tex2F_v_get")]
    public static extern float Tex2F_v_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_Tex2F")]
    public static extern void delete_Tex2F(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_PointSprite_pos_set")]
    public static extern void PointSprite_pos_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_PointSprite_pos_get")]
    public static extern IntPtr PointSprite_pos_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_PointSprite_color_set")]
    public static extern void PointSprite_color_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_PointSprite_color_get")]
    public static extern IntPtr PointSprite_color_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_PointSprite_size_set")]
    public static extern void PointSprite_size_set(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_PointSprite_size_get")]
    public static extern float PointSprite_size_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_PointSprite")]
    public static extern IntPtr new_PointSprite();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_PointSprite")]
    public static extern void delete_PointSprite(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Quad2_tl_set")]
    public static extern void Quad2_tl_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Quad2_tl_get")]
    public static extern IntPtr Quad2_tl_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Quad2_tr_set")]
    public static extern void Quad2_tr_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Quad2_tr_get")]
    public static extern IntPtr Quad2_tr_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Quad2_bl_set")]
    public static extern void Quad2_bl_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Quad2_bl_get")]
    public static extern IntPtr Quad2_bl_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Quad2_br_set")]
    public static extern void Quad2_br_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Quad2_br_get")]
    public static extern IntPtr Quad2_br_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_Quad2")]
    public static extern IntPtr new_Quad2();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_Quad2")]
    public static extern void delete_Quad2(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Quad3_bl_set")]
    public static extern void Quad3_bl_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Quad3_bl_get")]
    public static extern IntPtr Quad3_bl_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Quad3_br_set")]
    public static extern void Quad3_br_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Quad3_br_get")]
    public static extern IntPtr Quad3_br_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Quad3_tl_set")]
    public static extern void Quad3_tl_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Quad3_tl_get")]
    public static extern IntPtr Quad3_tl_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Quad3_tr_set")]
    public static extern void Quad3_tr_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Quad3_tr_get")]
    public static extern IntPtr Quad3_tr_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_Quad3")]
    public static extern IntPtr new_Quad3();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_Quad3")]
    public static extern void delete_Quad3(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V2F_C4B_T2F_vertices_set")]
    public static extern void V2F_C4B_T2F_vertices_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V2F_C4B_T2F_vertices_get")]
    public static extern IntPtr V2F_C4B_T2F_vertices_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V2F_C4B_T2F_colors_set")]
    public static extern void V2F_C4B_T2F_colors_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V2F_C4B_T2F_colors_get")]
    public static extern IntPtr V2F_C4B_T2F_colors_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V2F_C4B_T2F_texCoords_set")]
    public static extern void V2F_C4B_T2F_texCoords_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V2F_C4B_T2F_texCoords_get")]
    public static extern IntPtr V2F_C4B_T2F_texCoords_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_V2F_C4B_T2F")]
    public static extern IntPtr new_V2F_C4B_T2F();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_V2F_C4B_T2F")]
    public static extern void delete_V2F_C4B_T2F(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V2F_C4F_T2F_vertices_set")]
    public static extern void V2F_C4F_T2F_vertices_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V2F_C4F_T2F_vertices_get")]
    public static extern IntPtr V2F_C4F_T2F_vertices_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V2F_C4F_T2F_colors_set")]
    public static extern void V2F_C4F_T2F_colors_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V2F_C4F_T2F_colors_get")]
    public static extern IntPtr V2F_C4F_T2F_colors_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V2F_C4F_T2F_texCoords_set")]
    public static extern void V2F_C4F_T2F_texCoords_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V2F_C4F_T2F_texCoords_get")]
    public static extern IntPtr V2F_C4F_T2F_texCoords_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_V2F_C4F_T2F")]
    public static extern IntPtr new_V2F_C4F_T2F();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_V2F_C4F_T2F")]
    public static extern void delete_V2F_C4F_T2F(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V3F_C4B_T2F_vertices_set")]
    public static extern void V3F_C4B_T2F_vertices_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V3F_C4B_T2F_vertices_get")]
    public static extern IntPtr V3F_C4B_T2F_vertices_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V3F_C4B_T2F_colors_set")]
    public static extern void V3F_C4B_T2F_colors_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V3F_C4B_T2F_colors_get")]
    public static extern IntPtr V3F_C4B_T2F_colors_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V3F_C4B_T2F_texCoords_set")]
    public static extern void V3F_C4B_T2F_texCoords_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V3F_C4B_T2F_texCoords_get")]
    public static extern IntPtr V3F_C4B_T2F_texCoords_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_V3F_C4B_T2F")]
    public static extern IntPtr new_V3F_C4B_T2F();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_V3F_C4B_T2F")]
    public static extern void delete_V3F_C4B_T2F(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V3F_T2F_vertices_set")]
    public static extern void V3F_T2F_vertices_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V3F_T2F_vertices_get")]
    public static extern IntPtr V3F_T2F_vertices_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V3F_T2F_texCoords_set")]
    public static extern void V3F_T2F_texCoords_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V3F_T2F_texCoords_get")]
    public static extern IntPtr V3F_T2F_texCoords_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_V3F_T2F")]
    public static extern IntPtr new_V3F_T2F();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_V3F_T2F")]
    public static extern void delete_V3F_T2F(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V2F_C4B_T2F_Triangle_a_set")]
    public static extern void V2F_C4B_T2F_Triangle_a_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V2F_C4B_T2F_Triangle_a_get")]
    public static extern IntPtr V2F_C4B_T2F_Triangle_a_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V2F_C4B_T2F_Triangle_b_set")]
    public static extern void V2F_C4B_T2F_Triangle_b_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V2F_C4B_T2F_Triangle_b_get")]
    public static extern IntPtr V2F_C4B_T2F_Triangle_b_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V2F_C4B_T2F_Triangle_c_set")]
    public static extern void V2F_C4B_T2F_Triangle_c_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V2F_C4B_T2F_Triangle_c_get")]
    public static extern IntPtr V2F_C4B_T2F_Triangle_c_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_V2F_C4B_T2F_Triangle")]
    public static extern IntPtr new_V2F_C4B_T2F_Triangle();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_V2F_C4B_T2F_Triangle")]
    public static extern void delete_V2F_C4B_T2F_Triangle(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V2F_C4B_T2F_Quad_bl_set")]
    public static extern void V2F_C4B_T2F_Quad_bl_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V2F_C4B_T2F_Quad_bl_get")]
    public static extern IntPtr V2F_C4B_T2F_Quad_bl_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V2F_C4B_T2F_Quad_br_set")]
    public static extern void V2F_C4B_T2F_Quad_br_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V2F_C4B_T2F_Quad_br_get")]
    public static extern IntPtr V2F_C4B_T2F_Quad_br_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V2F_C4B_T2F_Quad_tl_set")]
    public static extern void V2F_C4B_T2F_Quad_tl_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V2F_C4B_T2F_Quad_tl_get")]
    public static extern IntPtr V2F_C4B_T2F_Quad_tl_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V2F_C4B_T2F_Quad_tr_set")]
    public static extern void V2F_C4B_T2F_Quad_tr_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V2F_C4B_T2F_Quad_tr_get")]
    public static extern IntPtr V2F_C4B_T2F_Quad_tr_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_V2F_C4B_T2F_Quad")]
    public static extern IntPtr new_V2F_C4B_T2F_Quad();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_V2F_C4B_T2F_Quad")]
    public static extern void delete_V2F_C4B_T2F_Quad(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V3F_C4B_T2F_Quad_tl_set")]
    public static extern void V3F_C4B_T2F_Quad_tl_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V3F_C4B_T2F_Quad_tl_get")]
    public static extern IntPtr V3F_C4B_T2F_Quad_tl_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V3F_C4B_T2F_Quad_bl_set")]
    public static extern void V3F_C4B_T2F_Quad_bl_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V3F_C4B_T2F_Quad_bl_get")]
    public static extern IntPtr V3F_C4B_T2F_Quad_bl_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V3F_C4B_T2F_Quad_tr_set")]
    public static extern void V3F_C4B_T2F_Quad_tr_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V3F_C4B_T2F_Quad_tr_get")]
    public static extern IntPtr V3F_C4B_T2F_Quad_tr_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V3F_C4B_T2F_Quad_br_set")]
    public static extern void V3F_C4B_T2F_Quad_br_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V3F_C4B_T2F_Quad_br_get")]
    public static extern IntPtr V3F_C4B_T2F_Quad_br_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_V3F_C4B_T2F_Quad")]
    public static extern IntPtr new_V3F_C4B_T2F_Quad();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_V3F_C4B_T2F_Quad")]
    public static extern void delete_V3F_C4B_T2F_Quad(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V2F_C4F_T2F_Quad_bl_set")]
    public static extern void V2F_C4F_T2F_Quad_bl_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V2F_C4F_T2F_Quad_bl_get")]
    public static extern IntPtr V2F_C4F_T2F_Quad_bl_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V2F_C4F_T2F_Quad_br_set")]
    public static extern void V2F_C4F_T2F_Quad_br_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V2F_C4F_T2F_Quad_br_get")]
    public static extern IntPtr V2F_C4F_T2F_Quad_br_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V2F_C4F_T2F_Quad_tl_set")]
    public static extern void V2F_C4F_T2F_Quad_tl_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V2F_C4F_T2F_Quad_tl_get")]
    public static extern IntPtr V2F_C4F_T2F_Quad_tl_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V2F_C4F_T2F_Quad_tr_set")]
    public static extern void V2F_C4F_T2F_Quad_tr_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V2F_C4F_T2F_Quad_tr_get")]
    public static extern IntPtr V2F_C4F_T2F_Quad_tr_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_V2F_C4F_T2F_Quad")]
    public static extern IntPtr new_V2F_C4F_T2F_Quad();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_V2F_C4F_T2F_Quad")]
    public static extern void delete_V2F_C4F_T2F_Quad(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V3F_T2F_Quad_bl_set")]
    public static extern void V3F_T2F_Quad_bl_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V3F_T2F_Quad_bl_get")]
    public static extern IntPtr V3F_T2F_Quad_bl_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V3F_T2F_Quad_br_set")]
    public static extern void V3F_T2F_Quad_br_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V3F_T2F_Quad_br_get")]
    public static extern IntPtr V3F_T2F_Quad_br_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V3F_T2F_Quad_tl_set")]
    public static extern void V3F_T2F_Quad_tl_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V3F_T2F_Quad_tl_get")]
    public static extern IntPtr V3F_T2F_Quad_tl_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V3F_T2F_Quad_tr_set")]
    public static extern void V3F_T2F_Quad_tr_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_V3F_T2F_Quad_tr_get")]
    public static extern IntPtr V3F_T2F_Quad_tr_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_V3F_T2F_Quad")]
    public static extern IntPtr new_V3F_T2F_Quad();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_V3F_T2F_Quad")]
    public static extern void delete_V3F_T2F_Quad(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_BlendFunc_src_set")]
    public static extern void BlendFunc_src_set(HandleRef jarg1, uint jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_BlendFunc_src_get")]
    public static extern uint BlendFunc_src_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_BlendFunc_dst_set")]
    public static extern void BlendFunc_dst_set(HandleRef jarg1, uint jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_BlendFunc_dst_get")]
    public static extern uint BlendFunc_dst_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_BlendFunc_DISABLE_get")]
    public static extern IntPtr BlendFunc_DISABLE_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_BlendFunc_ALPHA_PREMULTIPLIED_get")]
    public static extern IntPtr BlendFunc_ALPHA_PREMULTIPLIED_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_BlendFunc_ALPHA_NON_PREMULTIPLIED_get")]
    public static extern IntPtr BlendFunc_ALPHA_NON_PREMULTIPLIED_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_BlendFunc_ADDITIVE_get")]
    public static extern IntPtr BlendFunc_ADDITIVE_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_BlendFunc")]
    public static extern IntPtr new_BlendFunc();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_BlendFunc")]
    public static extern void delete_BlendFunc(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_T2F_Quad_bl_set")]
    public static extern void T2F_Quad_bl_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_T2F_Quad_bl_get")]
    public static extern IntPtr T2F_Quad_bl_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_T2F_Quad_br_set")]
    public static extern void T2F_Quad_br_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_T2F_Quad_br_get")]
    public static extern IntPtr T2F_Quad_br_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_T2F_Quad_tl_set")]
    public static extern void T2F_Quad_tl_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_T2F_Quad_tl_get")]
    public static extern IntPtr T2F_Quad_tl_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_T2F_Quad_tr_set")]
    public static extern void T2F_Quad_tr_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_T2F_Quad_tr_get")]
    public static extern IntPtr T2F_Quad_tr_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_T2F_Quad")]
    public static extern IntPtr new_T2F_Quad();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_T2F_Quad")]
    public static extern void delete_T2F_Quad(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_AnimationFrameData_texCoords_set")]
    public static extern void AnimationFrameData_texCoords_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_AnimationFrameData_texCoords_get")]
    public static extern IntPtr AnimationFrameData_texCoords_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_AnimationFrameData_delay_set")]
    public static extern void AnimationFrameData_delay_set(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_AnimationFrameData_delay_get")]
    public static extern float AnimationFrameData_delay_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_AnimationFrameData_size_set")]
    public static extern void AnimationFrameData_size_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_AnimationFrameData_size_get")]
    public static extern IntPtr AnimationFrameData_size_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_AnimationFrameData")]
    public static extern IntPtr new_AnimationFrameData();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_AnimationFrameData")]
    public static extern void delete_AnimationFrameData(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_FontShadow")]
    public static extern IntPtr new_FontShadow();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_FontShadow__shadowEnabled_set")]
    public static extern void FontShadow__shadowEnabled_set(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_FontShadow__shadowEnabled_get")]
    public static extern bool FontShadow__shadowEnabled_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_FontShadow__shadowOffset_set")]
    public static extern void FontShadow__shadowOffset_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_FontShadow__shadowOffset_get")]
    public static extern IntPtr FontShadow__shadowOffset_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_FontShadow__shadowBlur_set")]
    public static extern void FontShadow__shadowBlur_set(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_FontShadow__shadowBlur_get")]
    public static extern float FontShadow__shadowBlur_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_FontShadow__shadowOpacity_set")]
    public static extern void FontShadow__shadowOpacity_set(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_FontShadow__shadowOpacity_get")]
    public static extern float FontShadow__shadowOpacity_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_FontShadow")]
    public static extern void delete_FontShadow(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_FontStroke")]
    public static extern IntPtr new_FontStroke();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_FontStroke__strokeEnabled_set")]
    public static extern void FontStroke__strokeEnabled_set(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_FontStroke__strokeEnabled_get")]
    public static extern bool FontStroke__strokeEnabled_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_FontStroke__strokeColor_set")]
    public static extern void FontStroke__strokeColor_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_FontStroke__strokeColor_get")]
    public static extern IntPtr FontStroke__strokeColor_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_FontStroke__strokeSize_set")]
    public static extern void FontStroke__strokeSize_set(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_FontStroke__strokeSize_get")]
    public static extern float FontStroke__strokeSize_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_FontStroke")]
    public static extern void delete_FontStroke(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_FontDefinition")]
    public static extern IntPtr new_FontDefinition();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_FontDefinition__fontName_set")]
    public static extern void FontDefinition__fontName_set(HandleRef jarg1, string jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_FontDefinition__fontName_get")]
    public static extern string FontDefinition__fontName_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_FontDefinition__fontSize_set")]
    public static extern void FontDefinition__fontSize_set(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_FontDefinition__fontSize_get")]
    public static extern int FontDefinition__fontSize_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_FontDefinition__alignment_set")]
    public static extern void FontDefinition__alignment_set(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_FontDefinition__alignment_get")]
    public static extern int FontDefinition__alignment_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_FontDefinition__vertAlignment_set")]
    public static extern void FontDefinition__vertAlignment_set(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_FontDefinition__vertAlignment_get")]
    public static extern int FontDefinition__vertAlignment_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_FontDefinition__dimensions_set")]
    public static extern void FontDefinition__dimensions_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_FontDefinition__dimensions_get")]
    public static extern IntPtr FontDefinition__dimensions_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_FontDefinition__fontFillColor_set")]
    public static extern void FontDefinition__fontFillColor_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_FontDefinition__fontFillColor_get")]
    public static extern IntPtr FontDefinition__fontFillColor_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_FontDefinition__shadow_set")]
    public static extern void FontDefinition__shadow_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_FontDefinition__shadow_get")]
    public static extern IntPtr FontDefinition__shadow_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_FontDefinition__stroke_set")]
    public static extern void FontDefinition__stroke_set(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_FontDefinition__stroke_get")]
    public static extern IntPtr FontDefinition__stroke_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_FontDefinition")]
    public static extern void delete_FontDefinition(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Acceleration_x_set")]
    public static extern void Acceleration_x_set(HandleRef jarg1, double jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Acceleration_x_get")]
    public static extern double Acceleration_x_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Acceleration_y_set")]
    public static extern void Acceleration_y_set(HandleRef jarg1, double jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Acceleration_y_get")]
    public static extern double Acceleration_y_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Acceleration_z_set")]
    public static extern void Acceleration_z_set(HandleRef jarg1, double jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Acceleration_z_get")]
    public static extern double Acceleration_z_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Acceleration_timestamp_set")]
    public static extern void Acceleration_timestamp_set(HandleRef jarg1, double jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_Acceleration_timestamp_get")]
    public static extern double Acceleration_timestamp_get(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_Acceleration")]
    public static extern IntPtr new_Acceleration();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_Acceleration")]
    public static extern void delete_Acceleration(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_STD_STRING_EMPTY_get")]
    public static extern string STD_STRING_EMPTY_get();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CocosGUIVersion")]
    public static extern string CocosGUIVersion();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorPoint_Clear")]
    public static extern void CSVectorPoint_Clear(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorPoint_Add")]
    public static extern void CSVectorPoint_Add(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorPoint_size")]
    public static extern uint CSVectorPoint_size(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorPoint_capacity")]
    public static extern uint CSVectorPoint_capacity(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorPoint_reserve")]
    public static extern void CSVectorPoint_reserve(HandleRef jarg1, uint jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSVectorPoint__SWIG_0")]
    public static extern IntPtr new_CSVectorPoint__SWIG_0();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSVectorPoint__SWIG_1")]
    public static extern IntPtr new_CSVectorPoint__SWIG_1(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSVectorPoint__SWIG_2")]
    public static extern IntPtr new_CSVectorPoint__SWIG_2(int jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorPoint_getitemcopy")]
    public static extern IntPtr CSVectorPoint_getitemcopy(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorPoint_getitem")]
    public static extern IntPtr CSVectorPoint_getitem(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorPoint_setitem")]
    public static extern void CSVectorPoint_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorPoint_AddRange")]
    public static extern void CSVectorPoint_AddRange(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorPoint_GetRange")]
    public static extern IntPtr CSVectorPoint_GetRange(HandleRef jarg1, int jarg2, int jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorPoint_Insert")]
    public static extern void CSVectorPoint_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorPoint_InsertRange")]
    public static extern void CSVectorPoint_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorPoint_RemoveAt")]
    public static extern void CSVectorPoint_RemoveAt(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorPoint_RemoveRange")]
    public static extern void CSVectorPoint_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorPoint_Repeat")]
    public static extern IntPtr CSVectorPoint_Repeat(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorPoint_Reverse__SWIG_0")]
    public static extern void CSVectorPoint_Reverse__SWIG_0(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorPoint_Reverse__SWIG_1")]
    public static extern void CSVectorPoint_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorPoint_SetRange")]
    public static extern void CSVectorPoint_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSVectorPoint")]
    public static extern void delete_CSVectorPoint(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorRect_Clear")]
    public static extern void CSVectorRect_Clear(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorRect_Add")]
    public static extern void CSVectorRect_Add(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorRect_size")]
    public static extern uint CSVectorRect_size(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorRect_capacity")]
    public static extern uint CSVectorRect_capacity(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorRect_reserve")]
    public static extern void CSVectorRect_reserve(HandleRef jarg1, uint jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSVectorRect__SWIG_0")]
    public static extern IntPtr new_CSVectorRect__SWIG_0();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSVectorRect__SWIG_1")]
    public static extern IntPtr new_CSVectorRect__SWIG_1(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSVectorRect__SWIG_2")]
    public static extern IntPtr new_CSVectorRect__SWIG_2(int jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorRect_getitemcopy")]
    public static extern IntPtr CSVectorRect_getitemcopy(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorRect_getitem")]
    public static extern IntPtr CSVectorRect_getitem(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorRect_setitem")]
    public static extern void CSVectorRect_setitem(HandleRef jarg1, int jarg2, HandleRef jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorRect_AddRange")]
    public static extern void CSVectorRect_AddRange(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorRect_GetRange")]
    public static extern IntPtr CSVectorRect_GetRange(HandleRef jarg1, int jarg2, int jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorRect_Insert")]
    public static extern void CSVectorRect_Insert(HandleRef jarg1, int jarg2, HandleRef jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorRect_InsertRange")]
    public static extern void CSVectorRect_InsertRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorRect_RemoveAt")]
    public static extern void CSVectorRect_RemoveAt(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorRect_RemoveRange")]
    public static extern void CSVectorRect_RemoveRange(HandleRef jarg1, int jarg2, int jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorRect_Repeat")]
    public static extern IntPtr CSVectorRect_Repeat(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorRect_Reverse__SWIG_0")]
    public static extern void CSVectorRect_Reverse__SWIG_0(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorRect_Reverse__SWIG_1")]
    public static extern void CSVectorRect_Reverse__SWIG_1(HandleRef jarg1, int jarg2, int jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVectorRect_SetRange")]
    public static extern void CSVectorRect_SetRange(HandleRef jarg1, int jarg2, HandleRef jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSVectorRect")]
    public static extern void delete_CSVectorRect(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSScale__SWIG_0")]
    public static extern IntPtr new_CSScale__SWIG_0();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSScale")]
    public static extern void delete_CSScale(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSScale__SWIG_1")]
    public static extern IntPtr new_CSScale__SWIG_1(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSScale__SWIG_2")]
    public static extern IntPtr new_CSScale__SWIG_2(float jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSScale_SetScale")]
    public static extern void CSScale_SetScale(HandleRef jarg1, float jarg2, float jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSScale_SetScaleX")]
    public static extern void CSScale_SetScaleX(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSScale_GetScaleX")]
    public static extern float CSScale_GetScaleX(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSScale_SetScaleY")]
    public static extern void CSScale_SetScaleY(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSScale_GetScaleY")]
    public static extern float CSScale_GetScaleY(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSResourceData__SWIG_0")]
    public static extern IntPtr new_CSResourceData__SWIG_0();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSResourceData__SWIG_1")]
    public static extern IntPtr new_CSResourceData__SWIG_1([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (UTF8Marshaler))] string jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSResourceData__SWIG_2")]
    public static extern IntPtr new_CSResourceData__SWIG_2([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (UTF8Marshaler))] string jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSResourceData__SWIG_3")]
    public static extern IntPtr new_CSResourceData__SWIG_3([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (UTF8Marshaler))] string jarg1, int jarg2, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (UTF8Marshaler))] string jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSResourceData__SWIG_4")]
    public static extern IntPtr new_CSResourceData__SWIG_4(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSResourceData")]
    public static extern void delete_CSResourceData(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSResourceData_GetResourceType")]
    public static extern int CSResourceData_GetResourceType(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSResourceData_GetPath")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (UTF8Marshaler))]
    public static extern string CSResourceData_GetPath(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSResourceData_GetPathC")]
    public static extern string CSResourceData_GetPathC(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSResourceData_GetPlistFile")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (UTF8Marshaler))]
    public static extern string CSResourceData_GetPlistFile(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSResourceData_EndsWith")]
    public static extern bool CSResourceData_EndsWith(HandleRef jarg1, string jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSResourceData_Equals")]
    public static extern bool CSResourceData_Equals(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSResourceData_IsEmpty")]
    public static extern bool CSResourceData_IsEmpty(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSMatrix")]
    public static extern IntPtr new_CSMatrix();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSMatrix_M11")]
    public static extern float CSMatrix_M11(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSMatrix_M12")]
    public static extern float CSMatrix_M12(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSMatrix_M21")]
    public static extern float CSMatrix_M21(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSMatrix_M22")]
    public static extern float CSMatrix_M22(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSMatrix_X")]
    public static extern float CSMatrix_X(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSMatrix_Y")]
    public static extern float CSMatrix_Y(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSMatrix_SetM11")]
    public static extern void CSMatrix_SetM11(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSMatrix_SetM12")]
    public static extern void CSMatrix_SetM12(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSMatrix_SetM21")]
    public static extern void CSMatrix_SetM21(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSMatrix_SetM22")]
    public static extern void CSMatrix_SetM22(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSMatrix_SetX")]
    public static extern void CSMatrix_SetX(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSMatrix_SetY")]
    public static extern void CSMatrix_SetY(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSMatrix")]
    public static extern void delete_CSMatrix(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSRect")]
    public static extern IntPtr new_CSRect();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSRect_MinX")]
    public static extern float CSRect_MinX(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSRect_MinY")]
    public static extern float CSRect_MinY(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSRect_MaxX")]
    public static extern float CSRect_MaxX(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSRect_MaxY")]
    public static extern float CSRect_MaxY(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSRect")]
    public static extern void delete_CSRect(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_MatrixNode_init")]
    public static extern void MatrixNode_init(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_MatrixNode_print")]
    public static extern void MatrixNode_print(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_MatrixNode_X")]
    public static extern float MatrixNode_X(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_MatrixNode_Y")]
    public static extern float MatrixNode_Y(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_MatrixNode_ScaleX")]
    public static extern float MatrixNode_ScaleX(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_MatrixNode_ScaleY")]
    public static extern float MatrixNode_ScaleY(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_MatrixNode_SkewX")]
    public static extern float MatrixNode_SkewX(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_MatrixNode_SkewY")]
    public static extern float MatrixNode_SkewY(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_MatrixNode_AnchorPointX")]
    public static extern float MatrixNode_AnchorPointX(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_MatrixNode_AnchorPointY")]
    public static extern float MatrixNode_AnchorPointY(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_MatrixNode")]
    public static extern IntPtr new_MatrixNode();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_MatrixNode")]
    public static extern void delete_MatrixNode(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_GetName")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (UTF8Marshaler))]
    public static extern string CSVisualObject_GetName(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_SetName")]
    public static extern void CSVisualObject_SetName(HandleRef jarg1, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (UTF8Marshaler))] string jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_GetRelativePosition")]
    public static extern IntPtr CSVisualObject_GetRelativePosition(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_SetRelativePosition")]
    public static extern void CSVisualObject_SetRelativePosition(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_GetPosition")]
    public static extern IntPtr CSVisualObject_GetPosition(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_SetPosition")]
    public static extern void CSVisualObject_SetPosition(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_GetAnchorPoint")]
    public static extern IntPtr CSVisualObject_GetAnchorPoint(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_SetAnchorPoint")]
    public static extern void CSVisualObject_SetAnchorPoint(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_GetScale")]
    public static extern IntPtr CSVisualObject_GetScale(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_SetScale")]
    public static extern void CSVisualObject_SetScale(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_GetVisible")]
    public static extern bool CSVisualObject_GetVisible(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_SetVisible")]
    public static extern void CSVisualObject_SetVisible(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_GetVisibleForFrame")]
    public static extern bool CSVisualObject_GetVisibleForFrame(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_SetVisibleForFrame")]
    public static extern void CSVisualObject_SetVisibleForFrame(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_GetFrameEvent")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (UTF8Marshaler))]
    public static extern string CSVisualObject_GetFrameEvent(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_SetFrameEvent")]
    public static extern void CSVisualObject_SetFrameEvent(HandleRef jarg1, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (UTF8Marshaler))] string jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_GetRotation")]
    public static extern float CSVisualObject_GetRotation(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_SetRotation")]
    public static extern void CSVisualObject_SetRotation(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_GetRotationSkewX")]
    public static extern float CSVisualObject_GetRotationSkewX(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_SetRotationSkewX")]
    public static extern void CSVisualObject_SetRotationSkewX(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_GetRotationSkewY")]
    public static extern float CSVisualObject_GetRotationSkewY(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_SetRotationSkewY")]
    public static extern void CSVisualObject_SetRotationSkewY(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_GetZOrder")]
    public static extern int CSVisualObject_GetZOrder(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_SetZOrder")]
    public static extern void CSVisualObject_SetZOrder(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_GetOrderOfArrival")]
    public static extern int CSVisualObject_GetOrderOfArrival(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_GetTag")]
    public static extern int CSVisualObject_GetTag(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_SetTag")]
    public static extern void CSVisualObject_SetTag(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_GetColor")]
    public static extern IntPtr CSVisualObject_GetColor(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_SetColor")]
    public static extern void CSVisualObject_SetColor(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_GetAlpha")]
    public static extern int CSVisualObject_GetAlpha(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_SetAlpha")]
    public static extern void CSVisualObject_SetAlpha(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_IsAutoSize")]
    public static extern bool CSVisualObject_IsAutoSize(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_SetAutoSize")]
    public static extern void CSVisualObject_SetAutoSize(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_GetSize")]
    public static extern IntPtr CSVisualObject_GetSize(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_SetSize")]
    public static extern void CSVisualObject_SetSize(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_GetBoundingAnchorPoint")]
    public static extern IntPtr CSVisualObject_GetBoundingAnchorPoint(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_GetBoundingSize")]
    public static extern IntPtr CSVisualObject_GetBoundingSize(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_AddChild")]
    public static extern void CSVisualObject_AddChild(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_InsertChild")]
    public static extern void CSVisualObject_InsertChild(HandleRef jarg1, int jarg2, HandleRef jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_RemoveChild")]
    public static extern void CSVisualObject_RemoveChild(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_HitTest")]
    public static extern int CSVisualObject_HitTest(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_RectTest")]
    public static extern bool CSVisualObject_RectTest(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_TransformToSelf")]
    public static extern IntPtr CSVisualObject_TransformToSelf(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_TransformToScene")]
    public static extern IntPtr CSVisualObject_TransformToScene(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_TransformToParent")]
    public static extern IntPtr CSVisualObject_TransformToParent(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_GetMatrix")]
    public static extern IntPtr CSVisualObject_GetMatrix(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_GetWorldMatrix")]
    public static extern IntPtr CSVisualObject_GetWorldMatrix(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_GetAnchorMatrix")]
    public static extern IntPtr CSVisualObject_GetAnchorMatrix(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_GetAnchorWorldMatrix")]
    public static extern IntPtr CSVisualObject_GetAnchorWorldMatrix(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_GetParentMatrix")]
    public static extern IntPtr CSVisualObject_GetParentMatrix(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_GetParentWorldMatrix")]
    public static extern IntPtr CSVisualObject_GetParentWorldMatrix(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_ConvertToNodeMatrix")]
    public static extern IntPtr CSVisualObject_ConvertToNodeMatrix(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_GetAnchorPointInPoints")]
    public static extern IntPtr CSVisualObject_GetAnchorPointInPoints(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSCanvas")]
    public static extern IntPtr new_CSCanvas();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSCanvas")]
    public static extern void delete_CSCanvas(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSCanvas_SetVisible")]
    public static extern void CSCanvas_SetVisible(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSCanvas_SetPosition")]
    public static extern void CSCanvas_SetPosition(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSCanvas_SetScale")]
    public static extern void CSCanvas_SetScale(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSCanvas_HitTest")]
    public static extern int CSCanvas_HitTest(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSCanvas_SetCanvasSize")]
    public static extern void CSCanvas_SetCanvasSize(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSCanvas_GetCanvasSize")]
    public static extern IntPtr CSCanvas_GetCanvasSize(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSCanvas_ResetCanvas")]
    public static extern void CSCanvas_ResetCanvas(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSCanvas_SetLayerColorVisible")]
    public static extern void CSCanvas_SetLayerColorVisible(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSCanvas_SetCenterLineVisible")]
    public static extern void CSCanvas_SetCenterLineVisible(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSScene")]
    public static extern void delete_CSScene(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSNode__SWIG_1")]
    public static extern IntPtr new_CSNode__SWIG_1();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSNode")]
    public static extern void delete_CSNode(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSNode_Init")]
    public static extern void CSNode_Init(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSNode_IsPrePositionEnabled")]
    public static extern bool CSNode_IsPrePositionEnabled(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSNode_SetPrePositionEnabled")]
    public static extern void CSNode_SetPrePositionEnabled(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSNode_GetPositionType")]
    public static extern int CSNode_GetPositionType(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSNode_SetPositionType")]
    public static extern void CSNode_SetPositionType(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSNode_GetPrePosition")]
    public static extern IntPtr CSNode_GetPrePosition(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSNode_SetPrePosition")]
    public static extern void CSNode_SetPrePosition(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSNode_IsPreSizeEnabled")]
    public static extern bool CSNode_IsPreSizeEnabled(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSNode_SetPreSizeEnabled")]
    public static extern void CSNode_SetPreSizeEnabled(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSNode_GetPreSize")]
    public static extern IntPtr CSNode_GetPreSize(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSNode_SetPreSize")]
    public static extern void CSNode_SetPreSize(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSNode_GetCascadeColorEnabled")]
    public static extern bool CSNode_GetCascadeColorEnabled(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSNode_SetCascadeColorEnabled")]
    public static extern void CSNode_SetCascadeColorEnabled(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSNode_GetCascadeOpacityEnabled")]
    public static extern bool CSNode_GetCascadeOpacityEnabled(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSNode_SetCascadeOpacityEnabled")]
    public static extern void CSNode_SetCascadeOpacityEnabled(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSNode_GetIconVisible")]
    public static extern bool CSNode_GetIconVisible(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSNode_SetIconVisible")]
    public static extern void CSNode_SetIconVisible(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSNode_RefreshBoundingObjects")]
    public static extern void CSNode_RefreshBoundingObjects(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSNode_HasFileAndSize")]
    public static extern bool CSNode_HasFileAndSize(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSNode_RefreshLayout")]
    public static extern void CSNode_RefreshLayout(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSNode_GetObjectState")]
    public static extern int CSNode_GetObjectState(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSNode_SetObjectState")]
    public static extern void CSNode_SetObjectState(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSNode_SetPosition")]
    public static extern void CSNode_SetPosition(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSNode_SetScale")]
    public static extern void CSNode_SetScale(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSNode_SetAnchorPoint")]
    public static extern void CSNode_SetAnchorPoint(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSNode_GetRelativePosition")]
    public static extern IntPtr CSNode_GetRelativePosition(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSNode_SetRelativePosition")]
    public static extern void CSNode_SetRelativePosition(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSNode_SetSize")]
    public static extern void CSNode_SetSize(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSNode_GetBoundingAnchorPoint")]
    public static extern IntPtr CSNode_GetBoundingAnchorPoint(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSNode_GetBoundingSize")]
    public static extern IntPtr CSNode_GetBoundingSize(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSNode_HitTest")]
    public static extern int CSNode_HitTest(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSNode_RectTest")]
    public static extern bool CSNode_RectTest(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSNode_GetWorldMatrix")]
    public static extern IntPtr CSNode_GetWorldMatrix(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSNode_GetAnchorWorldMatrix")]
    public static extern IntPtr CSNode_GetAnchorWorldMatrix(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSNode_SetAutoSize")]
    public static extern void CSNode_SetAutoSize(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSLayer")]
    public static extern IntPtr new_CSLayer();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSLayer")]
    public static extern void delete_CSLayer(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSLayer_Init")]
    public static extern void CSLayer_Init(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSLayer_IsTouchEnabled")]
    public static extern bool CSLayer_IsTouchEnabled(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSLayer_SetTouchEnabled")]
    public static extern void CSLayer_SetTouchEnabled(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSWindow")]
    public static extern void delete_CSWindow(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSWindow__SWIG_0")]
    public static extern IntPtr new_CSWindow__SWIG_0(int jarg1, int jarg2, int jarg3, string jarg4);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSWindow__SWIG_1")]
    public static extern IntPtr new_CSWindow__SWIG_1(IntPtr jarg1, IntPtr jarg2, int jarg3, int jarg4, string jarg5);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSWindow_Draw")]
    public static extern void CSWindow_Draw(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSWindow_SetViewRect")]
    public static extern void CSWindow_SetViewRect(HandleRef jarg1, int jarg2, int jarg3, int jarg4, int jarg5);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSWindow_Close")]
    public static extern void CSWindow_Close(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSWindow_GetCanvas")]
    public static extern IntPtr CSWindow_GetCanvas(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSWindow_GetScene")]
    public static extern IntPtr CSWindow_GetScene(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSWindow_UpdateOpenGLContext")]
    public static extern void CSWindow_UpdateOpenGLContext(HandleRef jarg1, bool jarg2, int jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSCocosHelp")]
    public static extern IntPtr new_CSCocosHelp();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSCocosHelp")]
    public static extern void delete_CSCocosHelp(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSCocosHelp_ClearResurceCache")]
    public static extern void CSCocosHelp_ClearResurceCache();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSCocosHelp_LoadPListFileToCache")]
    public static extern void CSCocosHelp_LoadPListFileToCache(string jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSCocosHelp_ReloadPngFileToCache")]
    public static extern void CSCocosHelp_ReloadPngFileToCache(string jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSCocosHelp_ReloadPlistFileToCache")]
    public static extern void CSCocosHelp_ReloadPlistFileToCache(string jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSCocosHelp_RemovePngFileFromCache")]
    public static extern void CSCocosHelp_RemovePngFileFromCache(string jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSCocosHelp_RemovePlistFileFromCache")]
    public static extern void CSCocosHelp_RemovePlistFileFromCache(string jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSCocosHelp_GetTmxMapImageArray")]
    public static extern IntPtr CSCocosHelp_GetTmxMapImageArray(string jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSCocosHelp_ConvertToBinProto")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (UTF8Marshaler))]
    public static extern string CSCocosHelp_ConvertToBinProto(string jarg1, string jarg2, string jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSCocosHelp_ConvertToBinByFlat")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (UTF8Marshaler))]
    public static extern string CSCocosHelp_ConvertToBinByFlat(string jarg1, string jarg2, string jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSCocosHelp_RefreshLayoutSystemState")]
    public static extern void CSCocosHelp_RefreshLayoutSystemState(bool jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSCocosHelp_SetResourcePath")]
    public static extern void CSCocosHelp_SetResourcePath(string jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSSprite")]
    public static extern IntPtr new_CSSprite();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSSprite")]
    public static extern void delete_CSSprite(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSSprite_Init")]
    public static extern void CSSprite_Init(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSSprite_GetFlipX")]
    public static extern bool CSSprite_GetFlipX(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSSprite_SetFlipX")]
    public static extern void CSSprite_SetFlipX(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSSprite_GetFlipY")]
    public static extern bool CSSprite_GetFlipY(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSSprite_SetFlipY")]
    public static extern void CSSprite_SetFlipY(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSSprite_GetFileData")]
    public static extern IntPtr CSSprite_GetFileData(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSSprite_SetFileData")]
    public static extern void CSSprite_SetFileData(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSGameMap")]
    public static extern IntPtr new_CSGameMap();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSGameMap")]
    public static extern void delete_CSGameMap(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSGameMap_Init")]
    public static extern void CSGameMap_Init(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSGameMap_GetFileData")]
    public static extern IntPtr CSGameMap_GetFileData(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSGameMap_SetFileData")]
    public static extern void CSGameMap_SetFileData(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSParticleSystem")]
    public static extern IntPtr new_CSParticleSystem();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSParticleSystem")]
    public static extern void delete_CSParticleSystem(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSParticleSystem_Init")]
    public static extern void CSParticleSystem_Init(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSParticleSystem_Start")]
    public static extern void CSParticleSystem_Start(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSParticleSystem_Stop")]
    public static extern void CSParticleSystem_Stop(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSParticleSystem_IsPlaying")]
    public static extern bool CSParticleSystem_IsPlaying(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSParticleSystem_GetFileData")]
    public static extern IntPtr CSParticleSystem_GetFileData(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSParticleSystem_SetFileData")]
    public static extern void CSParticleSystem_SetFileData(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSProjectNode")]
    public static extern IntPtr new_CSProjectNode();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSProjectNode")]
    public static extern void delete_CSProjectNode(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSProjectNode_Init")]
    public static extern void CSProjectNode_Init(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSProjectNode_GetWidth")]
    public static extern float CSProjectNode_GetWidth(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSProjectNode_GetHeight")]
    public static extern float CSProjectNode_GetHeight(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSProjectNode_GetFileData")]
    public static extern IntPtr CSProjectNode_GetFileData(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSProjectNode_SetFileData")]
    public static extern void CSProjectNode_SetFileData(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSSimpleAudio")]
    public static extern IntPtr new_CSSimpleAudio();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSSimpleAudio")]
    public static extern void delete_CSSimpleAudio(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSSimpleAudio_Init")]
    public static extern void CSSimpleAudio_Init(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSSimpleAudio_GetName")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (UTF8Marshaler))]
    public static extern string CSSimpleAudio_GetName(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSSimpleAudio_SetName")]
    public static extern void CSSimpleAudio_SetName(HandleRef jarg1, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (UTF8Marshaler))] string jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSSimpleAudio_GetVolume")]
    public static extern float CSSimpleAudio_GetVolume(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSSimpleAudio_SetVolume")]
    public static extern void CSSimpleAudio_SetVolume(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSSimpleAudio_GetIsLoop")]
    public static extern bool CSSimpleAudio_GetIsLoop(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSSimpleAudio_SetIsLoop")]
    public static extern void CSSimpleAudio_SetIsLoop(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSSimpleAudio_Start")]
    public static extern void CSSimpleAudio_Start(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSSimpleAudio_Stop")]
    public static extern void CSSimpleAudio_Stop(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSSimpleAudio_GetFileData")]
    public static extern IntPtr CSSimpleAudio_GetFileData(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSSimpleAudio_SetFileData")]
    public static extern void CSSimpleAudio_SetFileData(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSPrimitive")]
    public static extern IntPtr new_CSPrimitive();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSPrimitive")]
    public static extern void delete_CSPrimitive(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSPrimitive_Init")]
    public static extern void CSPrimitive_Init(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSPrimitive_AddASBox")]
    public static extern void CSPrimitive_AddASBox(HandleRef jarg1, string jarg2, float jarg3, float jarg4, float jarg5, float jarg6);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSPrimitive_ResetBoxSize")]
    public static extern void CSPrimitive_ResetBoxSize(HandleRef jarg1, string jarg2, float jarg3, float jarg4, float jarg5, float jarg6);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSComControlNode")]
    public static extern IntPtr new_CSComControlNode();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSComControlNode")]
    public static extern void delete_CSComControlNode(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSComControlNode_Init")]
    public static extern void CSComControlNode_Init(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSComControlNode_SetPosition")]
    public static extern void CSComControlNode_SetPosition(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSComControlNode_GetSize")]
    public static extern IntPtr CSComControlNode_GetSize(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSComControlNode_SetSize")]
    public static extern void CSComControlNode_SetSize(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSComControlNode_HitTest")]
    public static extern int CSComControlNode_HitTest(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSComControlNode_HasFileAndSize")]
    public static extern bool CSComControlNode_HasFileAndSize(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSComControlNode_SetCanvasObject")]
    public static extern void CSComControlNode_SetCanvasObject(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSComControlNode_RectApplyTransform")]
    public static extern IntPtr CSComControlNode_RectApplyTransform(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSComControlNode_SetMat")]
    public static extern void CSComControlNode_SetMat(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSComControlNode_GetMat")]
    public static extern IntPtr CSComControlNode_GetMat(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSComControlNode_SetOriginMat")]
    public static extern void CSComControlNode_SetOriginMat(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSComControlNode_GetOriginMat")]
    public static extern IntPtr CSComControlNode_GetOriginMat(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSComControlNode_SetEnable")]
    public static extern void CSComControlNode_SetEnable(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSComControlNode_IsEnable")]
    public static extern bool CSComControlNode_IsEnable(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSComControlNode_GetControlPointType")]
    public static extern int CSComControlNode_GetControlPointType(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSComControlNode_GetMatrixWithoutReCalculate")]
    public static extern IntPtr CSComControlNode_GetMatrixWithoutReCalculate(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSComControlNode_Mat4Multiply")]
    public static extern IntPtr CSComControlNode_Mat4Multiply(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSComControlNode_Mat4Inverse")]
    public static extern IntPtr CSComControlNode_Mat4Inverse(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSComControlNode_Mat4Identity")]
    public static extern IntPtr CSComControlNode_Mat4Identity(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSComControlNode_Mat4ToMatrixNode")]
    public static extern IntPtr CSComControlNode_Mat4ToMatrixNode(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSComControlNode_TransformPoint")]
    public static extern IntPtr CSComControlNode_TransformPoint(HandleRef jarg1, HandleRef jarg2, HandleRef jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSComControlNode_SetAnchorPointVisiable")]
    public static extern void CSComControlNode_SetAnchorPointVisiable(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSComControlNode_SetControlPointVisiable")]
    public static extern void CSComControlNode_SetControlPointVisiable(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSComControlNode_SetAttachNode")]
    public static extern void CSComControlNode_SetAttachNode(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSWidget__SWIG_1")]
    public static extern IntPtr new_CSWidget__SWIG_1();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSWidget")]
    public static extern void delete_CSWidget(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSWidget_Init")]
    public static extern void CSWidget_Init(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSWidget_GetSizeCustomEnabled")]
    public static extern bool CSWidget_GetSizeCustomEnabled(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSWidget_SetSizeCustomEnabled")]
    public static extern void CSWidget_SetSizeCustomEnabled(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSWidget_GetWidgetAutoSize")]
    public static extern IntPtr CSWidget_GetWidgetAutoSize(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSWidget_GetTouchEnabled")]
    public static extern bool CSWidget_GetTouchEnabled(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSWidget_SetTouchEnabled")]
    public static extern void CSWidget_SetTouchEnabled(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSWidget_GetScale9Enabled")]
    public static extern bool CSWidget_GetScale9Enabled(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSWidget_SetScale9Enabled")]
    public static extern void CSWidget_SetScale9Enabled(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSWidget_SetScale9Rect")]
    public static extern void CSWidget_SetScale9Rect(HandleRef jarg1, int jarg2, int jarg3, int jarg4, int jarg5);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSWidget_CloneWidgetCustomProperty")]
    public static extern void CSWidget_CloneWidgetCustomProperty(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSWidget_ChangeState")]
    public static extern void CSWidget_ChangeState(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSButton")]
    public static extern IntPtr new_CSButton();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSButton")]
    public static extern void delete_CSButton(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSButton_Init")]
    public static extern void CSButton_Init(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSButton_SetSizeCustomEnabled")]
    public static extern void CSButton_SetSizeCustomEnabled(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSButton_GetFlipX")]
    public static extern bool CSButton_GetFlipX(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSButton_SetFlipX")]
    public static extern void CSButton_SetFlipX(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSButton_GetFlipY")]
    public static extern bool CSButton_GetFlipY(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSButton_SetFlipY")]
    public static extern void CSButton_SetFlipY(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSButton_GetScale9Enabled")]
    public static extern bool CSButton_GetScale9Enabled(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSButton_SetScale9Enabled")]
    public static extern void CSButton_SetScale9Enabled(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSButton_SetScale9Rect")]
    public static extern void CSButton_SetScale9Rect(HandleRef jarg1, int jarg2, int jarg3, int jarg4, int jarg5);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSButton_GetText")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (UTF8Marshaler))]
    public static extern string CSButton_GetText(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSButton_SetText")]
    public static extern void CSButton_SetText(HandleRef jarg1, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (UTF8Marshaler))] string jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSButton_GetFontName")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (UTF8Marshaler))]
    public static extern string CSButton_GetFontName(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSButton_SetFontName")]
    public static extern void CSButton_SetFontName(HandleRef jarg1, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (UTF8Marshaler))] string jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSButton_GetFontSize")]
    public static extern int CSButton_GetFontSize(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSButton_SetFontSize")]
    public static extern void CSButton_SetFontSize(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSButton_GetTextColor")]
    public static extern IntPtr CSButton_GetTextColor(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSButton_SetTextColor")]
    public static extern void CSButton_SetTextColor(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSButton_GetNormalFilePath")]
    public static extern IntPtr CSButton_GetNormalFilePath(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSButton_SetNormalFilePath")]
    public static extern void CSButton_SetNormalFilePath(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSButton_GetPressedFilePath")]
    public static extern IntPtr CSButton_GetPressedFilePath(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSButton_SetPressedFilePath")]
    public static extern void CSButton_SetPressedFilePath(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSButton_GetDisabledFilePath")]
    public static extern IntPtr CSButton_GetDisabledFilePath(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSButton_SetDisabledFilePath")]
    public static extern void CSButton_SetDisabledFilePath(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSButton_GetWidgetAutoSize")]
    public static extern IntPtr CSButton_GetWidgetAutoSize(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSCheckBox")]
    public static extern IntPtr new_CSCheckBox();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSCheckBox")]
    public static extern void delete_CSCheckBox(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSCheckBox_Init")]
    public static extern void CSCheckBox_Init(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSCheckBox_GetChecked")]
    public static extern bool CSCheckBox_GetChecked(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSCheckBox_SetChecked")]
    public static extern void CSCheckBox_SetChecked(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSCheckBox_GetNormalGroundFile")]
    public static extern IntPtr CSCheckBox_GetNormalGroundFile(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSCheckBox_SetNormalGroudFile")]
    public static extern void CSCheckBox_SetNormalGroudFile(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSCheckBox_GetPressedGroundFile")]
    public static extern IntPtr CSCheckBox_GetPressedGroundFile(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSCheckBox_SetPressedGroudFile")]
    public static extern void CSCheckBox_SetPressedGroudFile(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSCheckBox_GetDisabledGroundFile")]
    public static extern IntPtr CSCheckBox_GetDisabledGroundFile(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSCheckBox_SetDisabledGroudFile")]
    public static extern void CSCheckBox_SetDisabledGroudFile(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSCheckBox_GetNormalNodeFile")]
    public static extern IntPtr CSCheckBox_GetNormalNodeFile(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSCheckBox_SetNormalNodeFile")]
    public static extern void CSCheckBox_SetNormalNodeFile(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSCheckBox_GetDisabledNodeFile")]
    public static extern IntPtr CSCheckBox_GetDisabledNodeFile(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSCheckBox_SetDisabledNodeFile")]
    public static extern void CSCheckBox_SetDisabledNodeFile(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSImageView")]
    public static extern IntPtr new_CSImageView();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSImageView")]
    public static extern void delete_CSImageView(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSImageView_Init")]
    public static extern void CSImageView_Init(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSImageView_GetFlipX")]
    public static extern bool CSImageView_GetFlipX(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSImageView_SetFlipX")]
    public static extern void CSImageView_SetFlipX(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSImageView_GetFlipY")]
    public static extern bool CSImageView_GetFlipY(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSImageView_SetFlipY")]
    public static extern void CSImageView_SetFlipY(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSImageView_GetScale9Enabled")]
    public static extern bool CSImageView_GetScale9Enabled(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSImageView_SetScale9Enabled")]
    public static extern void CSImageView_SetScale9Enabled(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSImageView_SetScale9Rect")]
    public static extern void CSImageView_SetScale9Rect(HandleRef jarg1, int jarg2, int jarg3, int jarg4, int jarg5);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSImageView_GetFileData")]
    public static extern IntPtr CSImageView_GetFileData(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSImageView_SetFileData")]
    public static extern void CSImageView_SetFileData(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSText")]
    public static extern IntPtr new_CSText();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSText")]
    public static extern void delete_CSText(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSText_Init")]
    public static extern void CSText_Init(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSText_SetSizeCustomEnabled")]
    public static extern void CSText_SetSizeCustomEnabled(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSText_GetFlipX")]
    public static extern bool CSText_GetFlipX(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSText_SetFlipX")]
    public static extern void CSText_SetFlipX(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSText_GetFlipY")]
    public static extern bool CSText_GetFlipY(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSText_SetFlipY")]
    public static extern void CSText_SetFlipY(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSText_GetFontName")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (UTF8Marshaler))]
    public static extern string CSText_GetFontName(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSText_SetFontName")]
    public static extern void CSText_SetFontName(HandleRef jarg1, string jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSText_GetFontSize")]
    public static extern int CSText_GetFontSize(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSText_SetFontSize")]
    public static extern void CSText_SetFontSize(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSText_GetLabelText")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (UTF8Marshaler))]
    public static extern string CSText_GetLabelText(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSText_SetLabelText")]
    public static extern void CSText_SetLabelText(HandleRef jarg1, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (UTF8Marshaler))] string jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSText_GetHorizontalAlignmentType")]
    public static extern int CSText_GetHorizontalAlignmentType(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSText_SetHorizontalAlignmentType")]
    public static extern void CSText_SetHorizontalAlignmentType(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSText_GetVerticalAlignmentType")]
    public static extern int CSText_GetVerticalAlignmentType(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSText_SetVerticalAlignmentType")]
    public static extern void CSText_SetVerticalAlignmentType(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSText_GetTouchScaleChangeEanbleState")]
    public static extern bool CSText_GetTouchScaleChangeEanbleState(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSText_SetTouchScaleChangeEanbleState")]
    public static extern void CSText_SetTouchScaleChangeEanbleState(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSTextAtlas")]
    public static extern IntPtr new_CSTextAtlas();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSTextAtlas")]
    public static extern void delete_CSTextAtlas(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTextAtlas_Init")]
    public static extern void CSTextAtlas_Init(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTextAtlas_SetStartChar")]
    public static extern void CSTextAtlas_SetStartChar(HandleRef jarg1, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (UTF8Marshaler))] string jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTextAtlas_GetStartChar")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (UTF8Marshaler))]
    public static extern string CSTextAtlas_GetStartChar(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTextAtlas_GetCharacterWidth")]
    public static extern int CSTextAtlas_GetCharacterWidth(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTextAtlas_SetCharacterWidth")]
    public static extern void CSTextAtlas_SetCharacterWidth(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTextAtlas_GetCharacterHeight")]
    public static extern int CSTextAtlas_GetCharacterHeight(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTextAtlas_SetCharacterHeight")]
    public static extern void CSTextAtlas_SetCharacterHeight(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTextAtlas_GetText")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (UTF8Marshaler))]
    public static extern string CSTextAtlas_GetText(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTextAtlas_SetText")]
    public static extern void CSTextAtlas_SetText(HandleRef jarg1, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (UTF8Marshaler))] string jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTextAtlas_GetAtlasFile")]
    public static extern IntPtr CSTextAtlas_GetAtlasFile(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTextAtlas_SetAtlasFile")]
    public static extern bool CSTextAtlas_SetAtlasFile(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSTextBMFont")]
    public static extern IntPtr new_CSTextBMFont();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSTextBMFont")]
    public static extern void delete_CSTextBMFont(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTextBMFont_Init")]
    public static extern void CSTextBMFont_Init(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTextBMFont_GetText")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (UTF8Marshaler))]
    public static extern string CSTextBMFont_GetText(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTextBMFont_SetText")]
    public static extern void CSTextBMFont_SetText(HandleRef jarg1, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (UTF8Marshaler))] string jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTextBMFont_GetFntFile")]
    public static extern IntPtr CSTextBMFont_GetFntFile(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTextBMFont_SetFntFile")]
    public static extern void CSTextBMFont_SetFntFile(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSLoadingBar")]
    public static extern IntPtr new_CSLoadingBar();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSLoadingBar")]
    public static extern void delete_CSLoadingBar(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSLoadingBar_Init")]
    public static extern void CSLoadingBar_Init(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSLoadingBar_GetProgressPercent")]
    public static extern int CSLoadingBar_GetProgressPercent(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSLoadingBar_SetProgressPercent")]
    public static extern void CSLoadingBar_SetProgressPercent(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSLoadingBar_GetProgressType")]
    public static extern int CSLoadingBar_GetProgressType(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSLoadingBar_SetProgressType")]
    public static extern void CSLoadingBar_SetProgressType(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSLoadingBar_GetScale9Enabled")]
    public static extern bool CSLoadingBar_GetScale9Enabled(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSLoadingBar_SetScale9Enabled")]
    public static extern void CSLoadingBar_SetScale9Enabled(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSLoadingBar_SetScale9Rect")]
    public static extern void CSLoadingBar_SetScale9Rect(HandleRef jarg1, int jarg2, int jarg3, int jarg4, int jarg5);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSLoadingBar_GetFileData")]
    public static extern IntPtr CSLoadingBar_GetFileData(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSLoadingBar_SetFileData")]
    public static extern void CSLoadingBar_SetFileData(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSSlider")]
    public static extern IntPtr new_CSSlider();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSSlider")]
    public static extern void delete_CSSlider(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSSlider_Init")]
    public static extern void CSSlider_Init(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSSlider_GetPercent")]
    public static extern int CSSlider_GetPercent(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSSlider_SetPercent")]
    public static extern void CSSlider_SetPercent(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSSlider_GetScale9Enabled")]
    public static extern bool CSSlider_GetScale9Enabled(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSSlider_SetScale9Enabled")]
    public static extern void CSSlider_SetScale9Enabled(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSSlider_SetScale9Rect")]
    public static extern void CSSlider_SetScale9Rect(HandleRef jarg1, int jarg2, int jarg3, int jarg4, int jarg5);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSSlider_GetGroundBarTexture")]
    public static extern IntPtr CSSlider_GetGroundBarTexture(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSSlider_SetGroundBarTexture")]
    public static extern void CSSlider_SetGroundBarTexture(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSSlider_GetProgressBarTexture")]
    public static extern IntPtr CSSlider_GetProgressBarTexture(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSSlider_SetProgressBarTexture")]
    public static extern void CSSlider_SetProgressBarTexture(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSSlider_GetBallNormalTexture")]
    public static extern IntPtr CSSlider_GetBallNormalTexture(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSSlider_SetBallNormalTexture")]
    public static extern void CSSlider_SetBallNormalTexture(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSSlider_GetBallPressedTexture")]
    public static extern IntPtr CSSlider_GetBallPressedTexture(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSSlider_SetBallPressedTexture")]
    public static extern void CSSlider_SetBallPressedTexture(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSSlider_GetBallDisabledTexture")]
    public static extern IntPtr CSSlider_GetBallDisabledTexture(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSSlider_SetBallDisabledTexture")]
    public static extern void CSSlider_SetBallDisabledTexture(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSSlider_GetWidgetAutoSize")]
    public static extern IntPtr CSSlider_GetWidgetAutoSize(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSTextField")]
    public static extern IntPtr new_CSTextField();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSTextField")]
    public static extern void delete_CSTextField(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTextField_Init")]
    public static extern void CSTextField_Init(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTextField_SetSizeCustomEnabled")]
    public static extern void CSTextField_SetSizeCustomEnabled(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTextField_GetFontName")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (UTF8Marshaler))]
    public static extern string CSTextField_GetFontName(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTextField_SetFontName")]
    public static extern void CSTextField_SetFontName(HandleRef jarg1, string jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTextField_GetFontSize")]
    public static extern int CSTextField_GetFontSize(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTextField_SetFontSize")]
    public static extern void CSTextField_SetFontSize(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTextField_GetLabelText")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (UTF8Marshaler))]
    public static extern string CSTextField_GetLabelText(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTextField_SetLabelText")]
    public static extern void CSTextField_SetLabelText(HandleRef jarg1, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (UTF8Marshaler))] string jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTextField_GetPlaceHolderText")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (UTF8Marshaler))]
    public static extern string CSTextField_GetPlaceHolderText(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTextField_SetPlaceHolderText")]
    public static extern void CSTextField_SetPlaceHolderText(HandleRef jarg1, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (UTF8Marshaler))] string jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTextField_GetPlaceHolderTextColor")]
    public static extern IntPtr CSTextField_GetPlaceHolderTextColor(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTextField_SetPlaceHolderTextColor")]
    public static extern void CSTextField_SetPlaceHolderTextColor(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTextField_GetPassWordEnabled")]
    public static extern bool CSTextField_GetPassWordEnabled(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTextField_SetPassWordEnabled")]
    public static extern void CSTextField_SetPassWordEnabled(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTextField_GetPasswordStyleText")]
    public static extern string CSTextField_GetPasswordStyleText(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTextField_SetPasswordStyleText")]
    public static extern void CSTextField_SetPasswordStyleText(HandleRef jarg1, string jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTextField_GetLengthLimited")]
    public static extern bool CSTextField_GetLengthLimited(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTextField_SetLengthLimited")]
    public static extern void CSTextField_SetLengthLimited(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTextField_GetMaxLength")]
    public static extern int CSTextField_GetMaxLength(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTextField_SetMaxLength")]
    public static extern void CSTextField_SetMaxLength(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSPanel__SWIG_1")]
    public static extern IntPtr new_CSPanel__SWIG_1();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSPanel")]
    public static extern void delete_CSPanel(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSPanel_Init")]
    public static extern void CSPanel_Init(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSPanel_GetClipAble")]
    public static extern bool CSPanel_GetClipAble(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSPanel_SetClipAble")]
    public static extern void CSPanel_SetClipAble(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSPanel_GetGroundAlpha")]
    public static extern int CSPanel_GetGroundAlpha(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSPanel_SetGroundAlpha")]
    public static extern void CSPanel_SetGroundAlpha(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSPanel_GetGroundColorType")]
    public static extern int CSPanel_GetGroundColorType(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSPanel_SetGroundColorType")]
    public static extern void CSPanel_SetGroundColorType(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSPanel_GetGroundSingleColor")]
    public static extern IntPtr CSPanel_GetGroundSingleColor(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSPanel_SetGroundSingleColor")]
    public static extern void CSPanel_SetGroundSingleColor(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSPanel_GetGroundLineStartColor")]
    public static extern IntPtr CSPanel_GetGroundLineStartColor(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSPanel_SetGroundLineStartColor")]
    public static extern void CSPanel_SetGroundLineStartColor(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSPanel_GetGroundLineEndColor")]
    public static extern IntPtr CSPanel_GetGroundLineEndColor(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSPanel_SetGroundLineEndColor")]
    public static extern void CSPanel_SetGroundLineEndColor(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSPanel_GetGroundColorVector")]
    public static extern IntPtr CSPanel_GetGroundColorVector(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSPanel_SetGroundColorVector")]
    public static extern void CSPanel_SetGroundColorVector(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSPanel_GetScale9Enabled")]
    public static extern bool CSPanel_GetScale9Enabled(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSPanel_SetScale9Enabled")]
    public static extern void CSPanel_SetScale9Enabled(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSPanel_SetScale9Rect")]
    public static extern void CSPanel_SetScale9Rect(HandleRef jarg1, int jarg2, int jarg3, int jarg4, int jarg5);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSPanel_GetFilePath")]
    public static extern IntPtr CSPanel_GetFilePath(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSPanel_SetFilePath")]
    public static extern void CSPanel_SetFilePath(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSPanel_GetContainerLayoutType")]
    public static extern int CSPanel_GetContainerLayoutType(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSPanel_SetContainerLayoutType")]
    public static extern void CSPanel_SetContainerLayoutType(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSPanel_RemoveBackGroundFile")]
    public static extern void CSPanel_RemoveBackGroundFile(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSPanel_GetWidgetAutoSize")]
    public static extern IntPtr CSPanel_GetWidgetAutoSize(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSScrollView__SWIG_1")]
    public static extern IntPtr new_CSScrollView__SWIG_1();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSScrollView")]
    public static extern void delete_CSScrollView(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSScrollView_Init")]
    public static extern void CSScrollView_Init(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSScrollView_GetInnerSize")]
    public static extern IntPtr CSScrollView_GetInnerSize(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSScrollView_SetInnerSize")]
    public static extern void CSScrollView_SetInnerSize(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSScrollView_GetDirectionType")]
    public static extern int CSScrollView_GetDirectionType(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSScrollView_SetDirectionType")]
    public static extern void CSScrollView_SetDirectionType(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSScrollView_GetBounceEnabled")]
    public static extern bool CSScrollView_GetBounceEnabled(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSScrollView_SetBounceEnabled")]
    public static extern void CSScrollView_SetBounceEnabled(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSScrollView_RefreshBoundingObjects")]
    public static extern void CSScrollView_RefreshBoundingObjects(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSScrollView_TransformToSelfInner")]
    public static extern IntPtr CSScrollView_TransformToSelfInner(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSPageView")]
    public static extern IntPtr new_CSPageView();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSPageView")]
    public static extern void delete_CSPageView(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSPageView_Init")]
    public static extern void CSPageView_Init(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSPageView_AddChild")]
    public static extern void CSPageView_AddChild(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSPageView_RemoveChild")]
    public static extern void CSPageView_RemoveChild(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSPageView_InsertChild")]
    public static extern void CSPageView_InsertChild(HandleRef jarg1, int jarg2, HandleRef jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSPageView_SetSize")]
    public static extern void CSPageView_SetSize(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSPageView_RefreshBoundingObjects")]
    public static extern void CSPageView_RefreshBoundingObjects(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSListView")]
    public static extern IntPtr new_CSListView();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSListView")]
    public static extern void delete_CSListView(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSListView_Init")]
    public static extern void CSListView_Init(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSListView_GetItemSpace")]
    public static extern int CSListView_GetItemSpace(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSListView_SetItemSpace")]
    public static extern void CSListView_SetItemSpace(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSListView_GetGravityType")]
    public static extern int CSListView_GetGravityType(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSListView_SetGravityType")]
    public static extern void CSListView_SetGravityType(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSListView_InsertChild")]
    public static extern void CSListView_InsertChild(HandleRef jarg1, int jarg2, HandleRef jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSListView_AddChild")]
    public static extern void CSListView_AddChild(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSListView_RemoveChild")]
    public static extern void CSListView_RemoveChild(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSListView_SetDirectionType")]
    public static extern void CSListView_SetDirectionType(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSListView_RefreshBoundingObjects")]
    public static extern void CSListView_RefreshBoundingObjects(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSTimelineFrame")]
    public static extern IntPtr new_CSTimelineFrame();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSTimelineFrame")]
    public static extern void delete_CSTimelineFrame(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineFrame_GetFrameIndex")]
    public static extern int CSTimelineFrame_GetFrameIndex(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineFrame_SetFrameIndex")]
    public static extern void CSTimelineFrame_SetFrameIndex(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineFrame_GetActionObject")]
    public static extern IntPtr CSTimelineFrame_GetActionObject(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineFrame_SetActionObject")]
    public static extern void CSTimelineFrame_SetActionObject(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineFrame_SetTween")]
    public static extern void CSTimelineFrame_SetTween(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineFrame_IsTween")]
    public static extern bool CSTimelineFrame_IsTween(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineFrame_OnEnter")]
    public static extern void CSTimelineFrame_OnEnter(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSTimelineVisibleFrame__SWIG_0")]
    public static extern IntPtr new_CSTimelineVisibleFrame__SWIG_0(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSTimelineVisibleFrame__SWIG_1")]
    public static extern IntPtr new_CSTimelineVisibleFrame__SWIG_1();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSTimelineVisibleFrame")]
    public static extern void delete_CSTimelineVisibleFrame(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineVisibleFrame_SetVisible")]
    public static extern void CSTimelineVisibleFrame_SetVisible(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineVisibleFrame_IsVisible")]
    public static extern bool CSTimelineVisibleFrame_IsVisible(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSTimelineTextureFrame__SWIG_0")]
    public static extern IntPtr new_CSTimelineTextureFrame__SWIG_0(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSTimelineTextureFrame__SWIG_1")]
    public static extern IntPtr new_CSTimelineTextureFrame__SWIG_1();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSTimelineTextureFrame")]
    public static extern void delete_CSTimelineTextureFrame(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineTextureFrame_SetTexture")]
    public static extern void CSTimelineTextureFrame_SetTexture(HandleRef jarg1, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (UTF8Marshaler))] string jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineTextureFrame_GetTexture")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (UTF8Marshaler))]
    public static extern string CSTimelineTextureFrame_GetTexture(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineTextureFrame_SetPlist")]
    public static extern void CSTimelineTextureFrame_SetPlist(HandleRef jarg1, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (UTF8Marshaler))] string jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineTextureFrame_GetPlist")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (UTF8Marshaler))]
    public static extern string CSTimelineTextureFrame_GetPlist(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineTextureFrame_SetFrameEnterCallBack")]
    public static extern void CSTimelineTextureFrame_SetFrameEnterCallBack(HandleRef jarg1, CSTimelineTextureFrame.FrameEnterCallBack jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSTimelineRotationFrame__SWIG_0")]
    public static extern IntPtr new_CSTimelineRotationFrame__SWIG_0(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSTimelineRotationFrame__SWIG_1")]
    public static extern IntPtr new_CSTimelineRotationFrame__SWIG_1();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSTimelineRotationFrame")]
    public static extern void delete_CSTimelineRotationFrame(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineRotationFrame_SetRotation")]
    public static extern void CSTimelineRotationFrame_SetRotation(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineRotationFrame_GetRotation")]
    public static extern bool CSTimelineRotationFrame_GetRotation(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSTimelineSkewFrame__SWIG_0")]
    public static extern IntPtr new_CSTimelineSkewFrame__SWIG_0(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSTimelineSkewFrame__SWIG_1")]
    public static extern IntPtr new_CSTimelineSkewFrame__SWIG_1();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSTimelineSkewFrame")]
    public static extern void delete_CSTimelineSkewFrame(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineSkewFrame_SetSkewX")]
    public static extern void CSTimelineSkewFrame_SetSkewX(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineSkewFrame_GetSkewX")]
    public static extern float CSTimelineSkewFrame_GetSkewX(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineSkewFrame_SetSkewY")]
    public static extern void CSTimelineSkewFrame_SetSkewY(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineSkewFrame_GetSkewY")]
    public static extern float CSTimelineSkewFrame_GetSkewY(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSTimelineRotationSkewFrame__SWIG_0")]
    public static extern IntPtr new_CSTimelineRotationSkewFrame__SWIG_0(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSTimelineRotationSkewFrame__SWIG_1")]
    public static extern IntPtr new_CSTimelineRotationSkewFrame__SWIG_1();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSTimelineRotationSkewFrame")]
    public static extern void delete_CSTimelineRotationSkewFrame(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSTimelinePositionFrame__SWIG_0")]
    public static extern IntPtr new_CSTimelinePositionFrame__SWIG_0(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSTimelinePositionFrame__SWIG_1")]
    public static extern IntPtr new_CSTimelinePositionFrame__SWIG_1();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSTimelinePositionFrame")]
    public static extern void delete_CSTimelinePositionFrame(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelinePositionFrame_SetX")]
    public static extern void CSTimelinePositionFrame_SetX(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelinePositionFrame_GetX")]
    public static extern float CSTimelinePositionFrame_GetX(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelinePositionFrame_SetY")]
    public static extern void CSTimelinePositionFrame_SetY(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelinePositionFrame_GetY")]
    public static extern float CSTimelinePositionFrame_GetY(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSTimelineScaleFrame__SWIG_0")]
    public static extern IntPtr new_CSTimelineScaleFrame__SWIG_0(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSTimelineScaleFrame__SWIG_1")]
    public static extern IntPtr new_CSTimelineScaleFrame__SWIG_1();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSTimelineScaleFrame")]
    public static extern void delete_CSTimelineScaleFrame(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineScaleFrame_SetScaleX")]
    public static extern void CSTimelineScaleFrame_SetScaleX(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineScaleFrame_GetScaleX")]
    public static extern float CSTimelineScaleFrame_GetScaleX(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineScaleFrame_SetScaleY")]
    public static extern void CSTimelineScaleFrame_SetScaleY(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineScaleFrame_GetScaleY")]
    public static extern float CSTimelineScaleFrame_GetScaleY(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSTimelineAnchorPointFrame__SWIG_0")]
    public static extern IntPtr new_CSTimelineAnchorPointFrame__SWIG_0(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSTimelineAnchorPointFrame__SWIG_1")]
    public static extern IntPtr new_CSTimelineAnchorPointFrame__SWIG_1();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSTimelineAnchorPointFrame")]
    public static extern void delete_CSTimelineAnchorPointFrame(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineAnchorPointFrame_SetAnchorPointX")]
    public static extern void CSTimelineAnchorPointFrame_SetAnchorPointX(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineAnchorPointFrame_GetAnchorPointX")]
    public static extern float CSTimelineAnchorPointFrame_GetAnchorPointX(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineAnchorPointFrame_SetAnchorPointY")]
    public static extern void CSTimelineAnchorPointFrame_SetAnchorPointY(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineAnchorPointFrame_GetAnchorPointY")]
    public static extern float CSTimelineAnchorPointFrame_GetAnchorPointY(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSTimelineColorFrame__SWIG_0")]
    public static extern IntPtr new_CSTimelineColorFrame__SWIG_0(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSTimelineColorFrame__SWIG_1")]
    public static extern IntPtr new_CSTimelineColorFrame__SWIG_1();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSTimelineColorFrame")]
    public static extern void delete_CSTimelineColorFrame(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineColorFrame_SetAlpha")]
    public static extern void CSTimelineColorFrame_SetAlpha(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineColorFrame_GetAlpha")]
    public static extern int CSTimelineColorFrame_GetAlpha(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineColorFrame_SetColor")]
    public static extern void CSTimelineColorFrame_SetColor(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineColorFrame_GetColor")]
    public static extern IntPtr CSTimelineColorFrame_GetColor(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSTimelineInnerActionFrame__SWIG_0")]
    public static extern IntPtr new_CSTimelineInnerActionFrame__SWIG_0(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSTimelineInnerActionFrame__SWIG_1")]
    public static extern IntPtr new_CSTimelineInnerActionFrame__SWIG_1();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSTimelineInnerActionFrame")]
    public static extern void delete_CSTimelineInnerActionFrame(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineInnerActionFrame_SetInnerActionType")]
    public static extern void CSTimelineInnerActionFrame_SetInnerActionType(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineInnerActionFrame_GetInnerActionType")]
    public static extern int CSTimelineInnerActionFrame_GetInnerActionType(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineInnerActionFrame_SetStartFrameIndex")]
    public static extern void CSTimelineInnerActionFrame_SetStartFrameIndex(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineInnerActionFrame_GetStartFrameIndex")]
    public static extern int CSTimelineInnerActionFrame_GetStartFrameIndex(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSTimelineZOrderFrame__SWIG_0")]
    public static extern IntPtr new_CSTimelineZOrderFrame__SWIG_0(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSTimelineZOrderFrame__SWIG_1")]
    public static extern IntPtr new_CSTimelineZOrderFrame__SWIG_1();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSTimelineZOrderFrame")]
    public static extern void delete_CSTimelineZOrderFrame(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineZOrderFrame_SetZOrder")]
    public static extern void CSTimelineZOrderFrame_SetZOrder(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineZOrderFrame_GetZOrder")]
    public static extern int CSTimelineZOrderFrame_GetZOrder(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSTimelineEventFrame__SWIG_0")]
    public static extern IntPtr new_CSTimelineEventFrame__SWIG_0(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSTimelineEventFrame__SWIG_1")]
    public static extern IntPtr new_CSTimelineEventFrame__SWIG_1();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSTimelineEventFrame")]
    public static extern void delete_CSTimelineEventFrame(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineEventFrame_SetEvent")]
    public static extern void CSTimelineEventFrame_SetEvent(HandleRef jarg1, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (UTF8Marshaler))] string jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineEventFrame_GetEvent")]
    [return: MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof (UTF8Marshaler))]
    public static extern string CSTimelineEventFrame_GetEvent(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSTimeline")]
    public static extern IntPtr new_CSTimeline();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSTimeline")]
    public static extern void delete_CSTimeline(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimeline_SetActionObject")]
    public static extern void CSTimeline_SetActionObject(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimeline_GetActionObject")]
    public static extern IntPtr CSTimeline_GetActionObject(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimeline_SetActionTag")]
    public static extern void CSTimeline_SetActionTag(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimeline_GetActionTag")]
    public static extern int CSTimeline_GetActionTag(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimeline_GotoFrame")]
    public static extern void CSTimeline_GotoFrame(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimeline_InsertFrame")]
    public static extern void CSTimeline_InsertFrame(HandleRef jarg1, int jarg2, HandleRef jarg3);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimeline_RemoveFrame")]
    public static extern void CSTimeline_RemoveFrame(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimeline_ClearSearchState")]
    public static extern void CSTimeline_ClearSearchState(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineAction_SetOnionSkinPreNum")]
    public static extern void CSTimelineAction_SetOnionSkinPreNum(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineAction_GetOnionSkinPreNum")]
    public static extern int CSTimelineAction_GetOnionSkinPreNum(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineAction_SetOnionSkinSuffNum")]
    public static extern void CSTimelineAction_SetOnionSkinSuffNum(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineAction_GetOnionSkinSuffNum")]
    public static extern int CSTimelineAction_GetOnionSkinSuffNum(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineAction_SetOnionSkinEnable")]
    public static extern void CSTimelineAction_SetOnionSkinEnable(HandleRef jarg1, bool jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineAction_IsOnionSkinEnable")]
    public static extern bool CSTimelineAction_IsOnionSkinEnable(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineAction_AddOnionSkinKey")]
    public static extern void CSTimelineAction_AddOnionSkinKey(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineAction_RemoveOnionSkinKey")]
    public static extern void CSTimelineAction_RemoveOnionSkinKey(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineAction_IsOnionKeyFrame")]
    public static extern bool CSTimelineAction_IsOnionKeyFrame(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSTimelineAction__SWIG_0")]
    public static extern IntPtr new_CSTimelineAction__SWIG_0(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_new_CSTimelineAction__SWIG_1")]
    public static extern IntPtr new_CSTimelineAction__SWIG_1();

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_delete_CSTimelineAction")]
    public static extern void delete_CSTimelineAction(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineAction_GotoFrame")]
    public static extern void CSTimelineAction_GotoFrame(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineAction_Play")]
    public static extern void CSTimelineAction_Play(HandleRef jarg1, int jarg2, int jarg3, int jarg4, bool jarg5);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineAction_Pause")]
    public static extern void CSTimelineAction_Pause(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineAction_Resume")]
    public static extern void CSTimelineAction_Resume(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineAction_SetTimeSpeed")]
    public static extern void CSTimelineAction_SetTimeSpeed(HandleRef jarg1, float jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineAction_GetTimeSpeed")]
    public static extern float CSTimelineAction_GetTimeSpeed(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineAction_SetDuration")]
    public static extern void CSTimelineAction_SetDuration(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineAction_GetDuration")]
    public static extern int CSTimelineAction_GetDuration(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineAction_SetEndFrame")]
    public static extern void CSTimelineAction_SetEndFrame(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineAction_GetEndFrame")]
    public static extern int CSTimelineAction_GetEndFrame(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineAction_SetCurrentFrame")]
    public static extern void CSTimelineAction_SetCurrentFrame(HandleRef jarg1, int jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineAction_GetCurrentFrame")]
    public static extern int CSTimelineAction_GetCurrentFrame(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineAction_AddTimeline")]
    public static extern void CSTimelineAction_AddTimeline(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineAction_RemoveTimeline")]
    public static extern void CSTimelineAction_RemoveTimeline(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineAction_IsPlaying")]
    public static extern bool CSTimelineAction_IsPlaying(HandleRef jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineAction_InitWithRootNode")]
    public static extern void CSTimelineAction_InitWithRootNode(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineAction_ActiveAction")]
    public static extern void CSTimelineAction_ActiveAction(HandleRef jarg1, HandleRef jarg2);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSVisualObject_SWIGUpcast")]
    public static extern IntPtr CSVisualObject_SWIGUpcast(IntPtr jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSCanvas_SWIGUpcast")]
    public static extern IntPtr CSCanvas_SWIGUpcast(IntPtr jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSScene_SWIGUpcast")]
    public static extern IntPtr CSScene_SWIGUpcast(IntPtr jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSNode_SWIGUpcast")]
    public static extern IntPtr CSNode_SWIGUpcast(IntPtr jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSLayer_SWIGUpcast")]
    public static extern IntPtr CSLayer_SWIGUpcast(IntPtr jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSSprite_SWIGUpcast")]
    public static extern IntPtr CSSprite_SWIGUpcast(IntPtr jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSGameMap_SWIGUpcast")]
    public static extern IntPtr CSGameMap_SWIGUpcast(IntPtr jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSParticleSystem_SWIGUpcast")]
    public static extern IntPtr CSParticleSystem_SWIGUpcast(IntPtr jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSProjectNode_SWIGUpcast")]
    public static extern IntPtr CSProjectNode_SWIGUpcast(IntPtr jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSSimpleAudio_SWIGUpcast")]
    public static extern IntPtr CSSimpleAudio_SWIGUpcast(IntPtr jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSPrimitive_SWIGUpcast")]
    public static extern IntPtr CSPrimitive_SWIGUpcast(IntPtr jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSComControlNode_SWIGUpcast")]
    public static extern IntPtr CSComControlNode_SWIGUpcast(IntPtr jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSWidget_SWIGUpcast")]
    public static extern IntPtr CSWidget_SWIGUpcast(IntPtr jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSButton_SWIGUpcast")]
    public static extern IntPtr CSButton_SWIGUpcast(IntPtr jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSCheckBox_SWIGUpcast")]
    public static extern IntPtr CSCheckBox_SWIGUpcast(IntPtr jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSImageView_SWIGUpcast")]
    public static extern IntPtr CSImageView_SWIGUpcast(IntPtr jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSText_SWIGUpcast")]
    public static extern IntPtr CSText_SWIGUpcast(IntPtr jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTextAtlas_SWIGUpcast")]
    public static extern IntPtr CSTextAtlas_SWIGUpcast(IntPtr jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTextBMFont_SWIGUpcast")]
    public static extern IntPtr CSTextBMFont_SWIGUpcast(IntPtr jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSLoadingBar_SWIGUpcast")]
    public static extern IntPtr CSLoadingBar_SWIGUpcast(IntPtr jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSSlider_SWIGUpcast")]
    public static extern IntPtr CSSlider_SWIGUpcast(IntPtr jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTextField_SWIGUpcast")]
    public static extern IntPtr CSTextField_SWIGUpcast(IntPtr jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSPanel_SWIGUpcast")]
    public static extern IntPtr CSPanel_SWIGUpcast(IntPtr jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSScrollView_SWIGUpcast")]
    public static extern IntPtr CSScrollView_SWIGUpcast(IntPtr jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSPageView_SWIGUpcast")]
    public static extern IntPtr CSPageView_SWIGUpcast(IntPtr jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSListView_SWIGUpcast")]
    public static extern IntPtr CSListView_SWIGUpcast(IntPtr jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineFrame_SWIGUpcast")]
    public static extern IntPtr CSTimelineFrame_SWIGUpcast(IntPtr jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineVisibleFrame_SWIGUpcast")]
    public static extern IntPtr CSTimelineVisibleFrame_SWIGUpcast(IntPtr jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineTextureFrame_SWIGUpcast")]
    public static extern IntPtr CSTimelineTextureFrame_SWIGUpcast(IntPtr jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineRotationFrame_SWIGUpcast")]
    public static extern IntPtr CSTimelineRotationFrame_SWIGUpcast(IntPtr jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineSkewFrame_SWIGUpcast")]
    public static extern IntPtr CSTimelineSkewFrame_SWIGUpcast(IntPtr jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineRotationSkewFrame_SWIGUpcast")]
    public static extern IntPtr CSTimelineRotationSkewFrame_SWIGUpcast(IntPtr jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelinePositionFrame_SWIGUpcast")]
    public static extern IntPtr CSTimelinePositionFrame_SWIGUpcast(IntPtr jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineScaleFrame_SWIGUpcast")]
    public static extern IntPtr CSTimelineScaleFrame_SWIGUpcast(IntPtr jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineAnchorPointFrame_SWIGUpcast")]
    public static extern IntPtr CSTimelineAnchorPointFrame_SWIGUpcast(IntPtr jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineColorFrame_SWIGUpcast")]
    public static extern IntPtr CSTimelineColorFrame_SWIGUpcast(IntPtr jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineInnerActionFrame_SWIGUpcast")]
    public static extern IntPtr CSTimelineInnerActionFrame_SWIGUpcast(IntPtr jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineZOrderFrame_SWIGUpcast")]
    public static extern IntPtr CSTimelineZOrderFrame_SWIGUpcast(IntPtr jarg1);

    [DllImport("CocoStudioEngineAdapter", EntryPoint = "CSharp_CSTimelineEventFrame_SWIGUpcast")]
    public static extern IntPtr CSTimelineEventFrame_SWIGUpcast(IntPtr jarg1);

    protected class SWIGExceptionHelper
    {
      private static CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.ExceptionDelegate applicationDelegate = new CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.ExceptionDelegate(CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.SetPendingApplicationException);
      private static CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.ExceptionDelegate arithmeticDelegate = new CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.ExceptionDelegate(CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.SetPendingArithmeticException);
      private static CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.ExceptionDelegate divideByZeroDelegate = new CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.ExceptionDelegate(CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.SetPendingDivideByZeroException);
      private static CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.ExceptionDelegate indexOutOfRangeDelegate = new CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.ExceptionDelegate(CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.SetPendingIndexOutOfRangeException);
      private static CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.ExceptionDelegate invalidCastDelegate = new CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.ExceptionDelegate(CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.SetPendingInvalidCastException);
      private static CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.ExceptionDelegate invalidOperationDelegate = new CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.ExceptionDelegate(CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.SetPendingInvalidOperationException);
      private static CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.ExceptionDelegate ioDelegate = new CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.ExceptionDelegate(CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.SetPendingIOException);
      private static CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.ExceptionDelegate nullReferenceDelegate = new CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.ExceptionDelegate(CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.SetPendingNullReferenceException);
      private static CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.ExceptionDelegate outOfMemoryDelegate = new CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.ExceptionDelegate(CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.SetPendingOutOfMemoryException);
      private static CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.ExceptionDelegate overflowDelegate = new CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.ExceptionDelegate(CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.SetPendingOverflowException);
      private static CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.ExceptionDelegate systemDelegate = new CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.ExceptionDelegate(CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.SetPendingSystemException);
      private static CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.ExceptionArgumentDelegate argumentDelegate = new CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.ExceptionArgumentDelegate(CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.SetPendingArgumentException);
      private static CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.ExceptionArgumentDelegate argumentNullDelegate = new CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.ExceptionArgumentDelegate(CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.SetPendingArgumentNullException);
      private static CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.ExceptionArgumentDelegate argumentOutOfRangeDelegate = new CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.ExceptionArgumentDelegate(CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.SetPendingArgumentOutOfRangeException);

      static SWIGExceptionHelper()
      {
        CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.SWIGRegisterExceptionCallbacks_CocoStudioEngineAdapter(CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.applicationDelegate, CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.arithmeticDelegate, CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.divideByZeroDelegate, CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.indexOutOfRangeDelegate, CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.invalidCastDelegate, CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.invalidOperationDelegate, CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.ioDelegate, CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.nullReferenceDelegate, CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.outOfMemoryDelegate, CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.overflowDelegate, CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.systemDelegate);
        CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.SWIGRegisterExceptionCallbacksArgument_CocoStudioEngineAdapter(CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.argumentDelegate, CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.argumentNullDelegate, CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.argumentOutOfRangeDelegate);
      }

      [DllImport("CocoStudioEngineAdapter")]
      public static extern void SWIGRegisterExceptionCallbacks_CocoStudioEngineAdapter(CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.ExceptionDelegate applicationDelegate, CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.ExceptionDelegate arithmeticDelegate, CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.ExceptionDelegate divideByZeroDelegate, CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.ExceptionDelegate indexOutOfRangeDelegate, CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.ExceptionDelegate invalidCastDelegate, CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.ExceptionDelegate invalidOperationDelegate, CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.ExceptionDelegate ioDelegate, CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.ExceptionDelegate nullReferenceDelegate, CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.ExceptionDelegate outOfMemoryDelegate, CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.ExceptionDelegate overflowDelegate, CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.ExceptionDelegate systemExceptionDelegate);

      [DllImport("CocoStudioEngineAdapter", EntryPoint = "SWIGRegisterExceptionArgumentCallbacks_CocoStudioEngineAdapter")]
      public static extern void SWIGRegisterExceptionCallbacksArgument_CocoStudioEngineAdapter(CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.ExceptionArgumentDelegate argumentDelegate, CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.ExceptionArgumentDelegate argumentNullDelegate, CocoStudioEngineAdapterPINVOKE.SWIGExceptionHelper.ExceptionArgumentDelegate argumentOutOfRangeDelegate);

      private static void SetPendingApplicationException(string message)
      {
        CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Set((Exception) new ApplicationException(message, CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve()));
      }

      private static void SetPendingArithmeticException(string message)
      {
        CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Set((Exception) new ArithmeticException(message, CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve()));
      }

      private static void SetPendingDivideByZeroException(string message)
      {
        CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Set((Exception) new DivideByZeroException(message, CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve()));
      }

      private static void SetPendingIndexOutOfRangeException(string message)
      {
        CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Set((Exception) new IndexOutOfRangeException(message, CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve()));
      }

      private static void SetPendingInvalidCastException(string message)
      {
        CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Set((Exception) new InvalidCastException(message, CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve()));
      }

      private static void SetPendingInvalidOperationException(string message)
      {
        CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Set((Exception) new InvalidOperationException(message, CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve()));
      }

      private static void SetPendingIOException(string message)
      {
        CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Set((Exception) new IOException(message, CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve()));
      }

      private static void SetPendingNullReferenceException(string message)
      {
        CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Set((Exception) new NullReferenceException(message, CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve()));
      }

      private static void SetPendingOutOfMemoryException(string message)
      {
        CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Set((Exception) new OutOfMemoryException(message, CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve()));
      }

      private static void SetPendingOverflowException(string message)
      {
        CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Set((Exception) new OverflowException(message, CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve()));
      }

      private static void SetPendingSystemException(string message)
      {
        CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Set((Exception) new SystemException(message, CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve()));
      }

      private static void SetPendingArgumentException(string message, string paramName)
      {
        CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Set((Exception) new ArgumentException(message, paramName, CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve()));
      }

      private static void SetPendingArgumentNullException(string message, string paramName)
      {
        Exception exception = CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
        if (exception != null)
          message = message + " Inner Exception: " + exception.Message;
        CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Set((Exception) new ArgumentNullException(paramName, message));
      }

      private static void SetPendingArgumentOutOfRangeException(string message, string paramName)
      {
        Exception exception = CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Retrieve();
        if (exception != null)
          message = message + " Inner Exception: " + exception.Message;
        CocoStudioEngineAdapterPINVOKE.SWIGPendingException.Set((Exception) new ArgumentOutOfRangeException(paramName, message));
      }

      public delegate void ExceptionDelegate(string message);

      public delegate void ExceptionArgumentDelegate(string message, string paramName);
    }

    public class SWIGPendingException
    {
      [ThreadStatic]
      private static Exception pendingException = (Exception) null;
      private static int numExceptionsPending = 0;

      public static bool Pending
      {
        get
        {
          bool flag = false;
          if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.numExceptionsPending > 0 && CocoStudioEngineAdapterPINVOKE.SWIGPendingException.pendingException != null)
            flag = true;
          return flag;
        }
      }

      public static void Set(Exception e)
      {
        if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.pendingException != null)
          throw new ApplicationException("FATAL: An earlier pending exception from unmanaged code was missed and thus not thrown (" + CocoStudioEngineAdapterPINVOKE.SWIGPendingException.pendingException.ToString() + ")", e);
        CocoStudioEngineAdapterPINVOKE.SWIGPendingException.pendingException = e;
        lock (typeof (CocoStudioEngineAdapterPINVOKE))
          ++CocoStudioEngineAdapterPINVOKE.SWIGPendingException.numExceptionsPending;
      }

      public static Exception Retrieve()
      {
        Exception exception = (Exception) null;
        if (CocoStudioEngineAdapterPINVOKE.SWIGPendingException.numExceptionsPending > 0 && CocoStudioEngineAdapterPINVOKE.SWIGPendingException.pendingException != null)
        {
          exception = CocoStudioEngineAdapterPINVOKE.SWIGPendingException.pendingException;
          CocoStudioEngineAdapterPINVOKE.SWIGPendingException.pendingException = (Exception) null;
          lock (typeof (CocoStudioEngineAdapterPINVOKE))
            --CocoStudioEngineAdapterPINVOKE.SWIGPendingException.numExceptionsPending;
        }
        return exception;
      }
    }

    protected class SWIGStringHelper
    {
      private static CocoStudioEngineAdapterPINVOKE.SWIGStringHelper.SWIGStringDelegate stringDelegate = new CocoStudioEngineAdapterPINVOKE.SWIGStringHelper.SWIGStringDelegate(CocoStudioEngineAdapterPINVOKE.SWIGStringHelper.CreateString);

      static SWIGStringHelper()
      {
        CocoStudioEngineAdapterPINVOKE.SWIGStringHelper.SWIGRegisterStringCallback_CocoStudioEngineAdapter(CocoStudioEngineAdapterPINVOKE.SWIGStringHelper.stringDelegate);
      }

      [DllImport("CocoStudioEngineAdapter")]
      public static extern void SWIGRegisterStringCallback_CocoStudioEngineAdapter(CocoStudioEngineAdapterPINVOKE.SWIGStringHelper.SWIGStringDelegate stringDelegate);

      private static string CreateString(string cString)
      {
        return cString;
      }

      public delegate string SWIGStringDelegate(string message);
    }
  }
}
