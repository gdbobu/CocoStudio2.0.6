// Decompiled with JetBrains decompiler
// Type: Modules.Communal.CocosCreator.ICreateStep
// Assembly: Modules.Communal.CocosCreator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70C77DE5-8380-4243-AAEF-73AA753A2D70
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.CocosCreator.dll

namespace Modules.Communal.CocosCreator
{
  internal interface ICreateStep
  {
    bool Run(CreateParams prms, CocosCreateMonitor monitor);

    bool CanCreate(CreateParams prms);
  }
}
