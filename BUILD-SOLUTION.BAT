@echo off
set BUILPATH=C:\Windows\Microsoft.NET\Framework\v4.0.30319
%BUILPATH%\MSBuild.exe "HeaviSoft.FrameworkBase\HeaviSoft.FrameworkBase.Core\HeaviSoft.FrameworkBase.Core.csproj" /t:Build /p:Configuration=Debug
xcopy HeaviSoft.FrameworkBase\HeaviSoft.Lib\Internal HeaviSoft.FrameworkBase\Bin /y /s
%BUILPATH%\MSBuild.exe "HeaviSoft.FrameworkBase\HeaviSoft.FrameworkBase.sln" /t:Build /p:Configuration=Debug
xcopy HeaviSoft.FrameworkBase\Bin HeaviSoft.Documentor\bin /y /s
%BUILPATH%\MSBuild.exe "HeaviSoft.Documentor\HeaviSoft.Documentor.sln" /t:Build /p:Configuration=Debug
PAUSE