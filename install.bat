@echo off

@rem TODO - use drive env in script below
 
set prog=ColorSelector
set bindir=d:\opt\bin
set msbuild=F:\opt\VisualStudio\2022\Preview\MSBuild\Current\Bin\MSBuild.exe

 
@echo ---- Clean Release %prog% 
cd %prog%
lldu -sum obj bin 
rmdir /s obj  2> nul
rmdir /s bin  2> nul
cd ..
@rem %msbuild% %prog%.sln  -t:Clean

@echo.
@echo ---- Build Release %prog% 
%msbuild% %prog%.sln -p:Configuration="Release" -verbosity:minimal  -detailedSummary:True

@echo.
@echo ---- Build done 
set binbuilt=%prog%\bin\Release\%prog%.exe
if not exist "%binbuilt%" (
   echo Failed to build %binbuilt%
   goto _end
)
 
@echo ---- Copy Release to %bindir%
copy  "%binbuilt%" %bindir%\%prog%.exe
dir   "%binbuilt%" %bindir%\%prog%.exe

@rem play happy tone
rundll32.exe cmdext.dll,MessageBeepStub
rundll32 user32.dll,MessageBeep
 
:_end
