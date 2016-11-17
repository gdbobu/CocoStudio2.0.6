// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.TweenType
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

namespace CocoStudio.Model.ViewModel
{
  public enum TweenType
  {
    Custom = -1,
    [EnumType("Linear")] Linear = 0,
    [EnumType("Sine_EaseIn")] Sine_EaseIn = 1,
    [EnumType("Sine_EaseOut")] Sine_EaseOut = 2,
    [EnumType("Sine_EaseInOut")] Sine_EaseInOut = 3,
    [EnumType("Quad_EaseIn")] Quad_EaseIn = 4,
    [EnumType("Quad_EaseOut")] Quad_EaseOut = 5,
    [EnumType("Quad_EaseInOut")] Quad_EaseInOut = 6,
    [EnumType("Cubic_EaseIn")] Cubic_EaseIn = 7,
    [EnumType("Cubic_EaseOut")] Cubic_EaseOut = 8,
    [EnumType("Cubic_EaseInOut")] Cubic_EaseInOut = 9,
    [EnumType("Quart_EaseIn")] Quart_EaseIn = 10,
    [EnumType("Quart_EaseOut")] Quart_EaseOut = 11,
    [EnumType("Quart_EaseInOut")] Quart_EaseInOut = 12,
    [EnumType("Quint_EaseIn")] Quint_EaseIn = 13,
    [EnumType("Quint_EaseOut")] Quint_EaseOut = 14,
    [EnumType("Quint_EaseInOut")] Quint_EaseInOut = 15,
    [EnumType("Expo_EaseIn")] Expo_EaseIn = 16,
    [EnumType("Expo_EaseOut")] Expo_EaseOut = 17,
    [EnumType("Expo_EaseInOut")] Expo_EaseInOut = 18,
    [EnumType("Circ_EaseIn")] Circ_EaseIn = 19,
    [EnumType("Circ_EaseOut")] Circ_EaseOut = 20,
    [EnumType("Circ_EaseInOut")] Circ_EaseInOut = 21,
    [EnumType("Elastic_EaseIn"), EnumType("Elastic_EaseInOut"), EnumType("Elastic_EaseOut"), EnumType("Back_EaseIn")] Back_EaseIn = 22,
    [EnumType("Back_EaseOut")] Back_EaseOut = 23,
    [EnumType("Back_EaseInOut")] Back_EaseInOut = 24,
    [EnumType("Bounce_EaseIn")] Bounce_EaseIn = 25,
    [EnumType("Bounce_EaseOut")] Bounce_EaseOut = 26,
    [EnumType("Bounce_EaseInOut")] Bounce_EaseInOut = 27,
    TWEEN_EASING_MAX = 10000,
  }
}
