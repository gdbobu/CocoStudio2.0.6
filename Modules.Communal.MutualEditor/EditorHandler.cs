// Decompiled with JetBrains decompiler
// Type: Modules.Communal.MutualEditor.EditorHandler
// Assembly: Modules.Communal.MutualEditor, Version=1.0.5464.34363, Culture=neutral, PublicKeyToken=null
// MVID: DFA20643-9760-4068-BB56-12AD0ACFA443
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.MutualEditor.dll

using CocoStudio.Core;

namespace Modules.Communal.MutualEditor
{
  internal class EditorHandler : BaseHandler
  {
    private const int portNumber = 9000;

    protected override int GetStartPort()
    {
      return 9000;
    }

    protected override void OnHandleMessageRecived(object sender, MessageArgs args)
    {
      if (args.Message == null || Services.ProjectsService == null || Services.ProjectsService.CurrentSolution == null || !args.Message.Data.Equals((string) Services.ProjectsService.CurrentSolution.FileName))
        return;
      MutualCore.ShowCurrApplication();
    }
  }
}
