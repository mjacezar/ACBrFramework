ECHO OFF
dumpbin /exports "..\x86\ACBrFramework32.dll" /Out:.\x86\ACBrFramework32.def
dumpbin /exports "..\x64\ACBrFramework64.dll" /Out:.\x64\ACBrFramework64.def