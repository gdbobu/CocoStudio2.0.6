using CocoStudio.Core.Codons;
using Mono.Addins;
using MonoDevelop.Ide.Codons;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("CocoStudio.Core")]
[assembly: AddinDependency("::MonoDevelop.Ide", "5.4.0")]
[assembly: AssemblyTrademark("")]
[assembly: AddinDependency("::MonoDevelop.Core", "5.4.0")]
[assembly: ComVisible(false)]
[assembly: AddinRoot("CocoStudio.Core", "2.0", Namespace = "CocoStudio")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("CocoStudio.Core")]
[assembly: AssemblyCopyright("Copyright ©  2014")]
[assembly: AddinDependency("CocoStudio.Projects", "2.0")]
[assembly: Guid("136acbd6-1991-40a2-a040-0dbfca2f4946")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: InternalsVisibleTo("CocoStudio.Projects.Test")]
[assembly: InternalsVisibleTo("CocoStudio.ProjectsPublish.Test")]
[assembly: ExtensionPoint(Name = "Main Window Pads", NodeType = typeof (PadCodon), Path = "/CocoStudio/Ide/Pads")]
[assembly: ExtensionPoint(Name = "Display Builder", NodeType = typeof (DisplayBuilderCodon), Path = "CocoStudio/Ide/DisplayBuilder")]
[assembly: AssemblyVersion("1.0.0.0")]
