ECHO OFF
LIB /DEF:.\x86\ACBrFramework32.def /OUT:.\x86\ACBrFramework32.lib /MACHINE:X86
LIB /DEF:.\x64\ACBrFramework64.def /OUT:.\x64\ACBrFramework64.lib  /MACHINE:X64
pause