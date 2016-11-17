// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.StringFrame
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

namespace CocoStudio.Model.ViewModel
{
  public abstract class StringFrame : Frame
  {
    public virtual string Value { get; set; }

    public override void Copy(Frame frame)
    {
      base.Copy(frame);
      StringFrame stringFrame = frame as StringFrame;
      if (stringFrame == null)
        return;
      this.Value = stringFrame.Value;
    }
  }
}
