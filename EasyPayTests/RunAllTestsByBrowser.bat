@echo off
set /p browserName=

set TestPath=%CD%\bin\Debug\EasyPayTests.dll
cd ..\packages\NUnit.ConsoleRunner.3.10.0\tools

start nunit3-console %TestPath% --params:browser=%browserName%
pause