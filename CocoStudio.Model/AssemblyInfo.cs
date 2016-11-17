using Mono.Addins;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: ComVisible(false)]
[assembly: InternalsVisibleTo("Modules.UI.ComTool")]
[assembly: Addin("CocoStudio.Model", "2.0", Namespace = "CocoStudio")]
[assembly: AssemblyTrademark("")]
[assembly: AddinDependency("CocoStudio.Projects", "2.0")]
[assembly: AssemblyCopyright("Copyright © Chukong Aipu 2014")]
[assembly: Guid("1ee85fa3-4f51-4102-a560-bb416ac9b3f6")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AddinDependency("CocoStudio.Core", "2.0")]
[assembly: Extension]
[assembly: AssemblyTitle("CocoStudio")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Beijing Chukong Aipu Technology Co.,Ltd")]
[assembly: AssemblyProduct("CocoStudio")]
[assembly: AssemblyVersion("1.0.0.0")]
