using System.Reflection;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
#if COM_INTEROP
[assembly: AssemblyTitle("ACBrFramework")]
[assembly: AssemblyDescription("ACBrFramework ActiveX")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("ACBr")]
[assembly: AssemblyProduct("ACBrFramework")]
[assembly: TypeLibVersion(109, 23)]
#else
[assembly: AssemblyTitle("ACBrFramework.Net")]
[assembly: AssemblyDescription("Projeto ACBrFramework para .Net")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Equipe ACBrFramework")]
[assembly: AssemblyProduct("ACBrFramework.Net")]
#endif

[assembly: AssemblyCopyright("Direitos Autorais © Equipe ACBrFramework 2010-2013")]
[assembly: AssemblyTrademark("http://acbrframework.sourceforge.net")]
[assembly: AssemblyCulture("")]

[assembly: ComVisible(false)]


// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("D487CB83-4CD7-4C64-BBC3-FEF2DCD04023")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("0.9.5.2")]
[assembly: AssemblyFileVersion("0.9.5.2")]

internal sealed class ToolboxIcons { }