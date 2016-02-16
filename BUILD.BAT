@echo off
 set BUILPATH=C:\Windows\Microsoft.NET\Framework\v4.0.30319
 %BUILPATH%\MSBuild.exe "HeaviSoft.FrameworkBase\HeaviSoft.FrameworkBase.Core\HeaviSoft.FrameworkBase.Core.csproj" /t:Build /p:Configuration=Debug
 %BUILPATH%\MSBuild.exe "HeaviSoft.FrameworkBase\HeaviSoft.FrameworkBase.Extension\HeaviSoft.FrameworkBase.Extension.csproj" /t:Build /p:Configuration=Debug
 %BUILPATH%\MSBuild.exe "HeaviSoft.FrameworkBase\HeaviSoft.FrameworkBase.Configuration\HeaviSoft.FrameworkBase.Configuration.csproj" /t:Build /p:Configuration=Debug
 %BUILPATH%\MSBuild.exe "HeaviSoft.FrameworkBase\HeaviSoft.FrameworkBase.Utility\HeaviSoft.FrameworkBase.Utility.csproj" /t:Build /p:Configuration=Debug
 %BUILPATH%\MSBuild.exe "HeaviSoft.FrameworkBase\HeaviSoft.FrameworkBase.Theme\HeaviSoft.FrameworkBase.Theme.csproj" /t:Build /p:Configuration=Debug
 %BUILPATH%\MSBuild.exe "HeaviSoft.FrameworkBase\HeaviSoft.FrameworkBase.Component\HeaviSoft.FrameworkBase.Component.csproj" /t:Build /p:Configuration=Debug
 %BUILPATH%\MSBuild.exe "HeaviSoft.FrameworkBase\HeaviSoft.FrameworkBase.Test\HeaviSoft.FrameworkBase.Test.csproj" /t:Build /p:Configuration=Debug
 xcopy HeaviSoft.FrameworkBase\HeaviSoft.Lib\Internal HeaviSoft.FrameworkBase\Bin /y /s
 %BUILPATH%\MSBuild.exe "HeaviSoft.FrameworkBase\HeaviSoft.FrameworkBase.Client\HeaviSoft.FrameworkBase.Client.csproj" /t:Build /p:Configuration=Debug
 xcopy HeaviSoft.FrameworkBase\Bin HeaviSoft.Documentor\bin /y /s
 %BUILPATH%\MSBuild.exe "HeaviSoft.Documentor\HeaviSoft.Documentor.Theme\HeaviSoft.Documentor.Theme.csproj" /t:Build /p:Configuration=Debug
 %BUILPATH%\MSBuild.exe "HeaviSoft.Documentor\HeaviSoft.Documentor.Language\HeaviSoft.Documentor.Language.csproj" /t:Build /p:Configuration=Debug
 %BUILPATH%\MSBuild.exe "HeaviSoft.Documentor\HeaviSoft.Documentor.Presentation.Docking\HeaviSoft.Documentor.Presentation.Docking.csproj" /t:Build /p:Configuration=Debug
 %BUILPATH%\MSBuild.exe "HeaviSoft.Documentor\HeaviSoft.Documentor.Presentation.Login\HeaviSoft.Documentor.Presentation.Login.csproj" /t:Build /p:Configuration=Debug
 PAUSE