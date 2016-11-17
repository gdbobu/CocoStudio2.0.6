// Decompiled with JetBrains decompiler
// Type: CocoStudio.TestHelp
// Assembly: CocosStudio, Version=2.0.6.0, Culture=neutral, PublicKeyToken=null
// MVID: F931EF05-B4A9-479F-8470-995544832753
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocosStudio.exe

using CocoStudio.Basic;
using CocoStudio.Core;
using CocoStudio.Model.DataModel;
using CocoStudio.Projects;
using Mono.Addins;
using MonoDevelop.Core;
using MonoDevelop.Core.ProgressMonitoring;
using System;
using System.Collections.Generic;
using System.IO;

namespace CocoStudio
{
  internal class TestHelp
  {
    public static void TestSolution()
    {
      Services.Workspace.Items.Clear();
      TestHelp.ReadSolution();
    }

    private static void ReadSolution()
    {
      AddinManager.Initialize(Option.AddinConfigFolder);
      Services.Workspace.OpenWorkspaceItem(TestHelp.GetFullPath("Game.ccs"));
      Solution selectedSolution = Services.ProjectOperations.CurrentSelectedSolution;
    }

    private static void WriteSolution()
    {
      AddinManager.Initialize(Option.AddinConfigFolder);
      AddinManager.Registry.Update();
      DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Test"));
      if (!directoryInfo.Exists)
        directoryInfo.Create();
      RootWorkspace workspace = Services.Workspace;
      Solution parentSolution = new Solution();
      parentSolution.SetLocation((FilePath) AppDomain.CurrentDomain.BaseDirectory, "Game");
      Services.ProjectOperations.CurrentSelectedSolution = parentSolution;
      ResourceGroup resourceGroup = new ResourceGroup(parentSolution);
      ResourceFile resourceFile1 = new ResourceFile((FilePath) TestHelp.GetFullPath("CocoStudio.Basic.pdb"));
      resourceGroup.RootFolder.Items.Add((ResourceItem) resourceFile1);
      ResourceFolder resourceFolder1 = new ResourceFolder((FilePath) TestHelp.GetFullPath("EditorDefaultRes"));
      resourceGroup.RootFolder.Items.Add((ResourceItem) resourceFolder1);
      ResourceFile resourceFile2 = new ResourceFile((FilePath) TestHelp.GetFullPath("EditorDefaultRes/Test.xml"));
      resourceFolder1.Items.Add((ResourceItem) resourceFile2);
      ResourceFolder resourceFolder2 = new ResourceFolder((FilePath) TestHelp.GetFullPath("Test"));
      resourceGroup.RootFolder.Items.Add((ResourceItem) resourceFolder2);
      ResourceFile resourceFile3 = new ResourceFile((FilePath) TestHelp.GetFullPath("Test/1.txt"));
      resourceFolder2.Items.Add((ResourceItem) resourceFile3);
      ImageFile imageFile1 = new ImageFile((FilePath) TestHelp.GetFullPath("Test/1.png"));
      resourceFolder2.Items.Add((ResourceItem) imageFile1);
      ImageFile imageFile2 = new ImageFile((FilePath) TestHelp.GetFullPath("Test/2.png"));
      resourceFolder2.Items.Add((ResourceItem) imageFile2);
      ImageFile imageFile3 = new ImageFile((FilePath) TestHelp.GetFullPath("Test/3.png"));
      resourceFolder2.Items.Add((ResourceItem) imageFile3);
      ImageFile imageFile4 = new ImageFile((FilePath) TestHelp.GetFullPath("Test/4.png"));
      resourceFolder2.Items.Add((ResourceItem) imageFile4);
      Project project1 = Services.ProjectsService.CreateProject("Node", new ProjectCreateInformation((FilePath) TestHelp.GetFullPath("Test/1.csd"), (IProjectContent) new GameProjectContent()
      {
        Content = new GameProjectData()
      }, (IList<ResourceItem>) null, 0.0f, 0.0f));
      resourceFolder2.Items.Add((ResourceItem) project1);
      Project project2 = Services.ProjectsService.CreateProject("Node", new ProjectCreateInformation((FilePath) TestHelp.GetFullPath("Test/2.csd"), (IProjectContent) new GameProjectContent()
      {
        Content = new GameProjectData()
      }, (IList<ResourceItem>) null, 0.0f, 0.0f));
      resourceFolder2.Items.Add((ResourceItem) project2);
      parentSolution.RootFolder.Items.Add((SolutionEntityItem) resourceGroup);
      workspace.Items.Add((WorkspaceItem) parentSolution);
      SimpleProgressMonitor simpleProgressMonitor = new SimpleProgressMonitor();
      workspace.Save((IProgressMonitor) simpleProgressMonitor);
    }

    private static string GetFullPath(string relativePath)
    {
      return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);
    }
  }
}
