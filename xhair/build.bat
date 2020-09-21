<# :
@echo off
@if not exist .build ( md .build & attrib +h .build /d )
@powershell -noprofile -nologo "iex (${%~f0} | out-string)"
@copy .build\bin\Release\net461\xhair.exe xhair.exe
@goto :eof
#>
$msbuild = &"${env:ProgramFiles(x86)}\Microsoft Visual Studio\Installer\vswhere.exe" `
	-latest -products * -requires Microsoft.Component.MSBuild `
	-find **\Bin\MSBuild.exe
&$msbuild -r xhair.sln /noLogo /verbosity:quiet /p:Configuration=Release
