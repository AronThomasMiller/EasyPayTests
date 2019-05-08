@echo off

set TestPath=%CD%\bin\Debug\EasyPayTests.dll
cd ..\packages\NUnit.ConsoleRunner.3.10.0\tools

start nunit3-console %TestPath% --params:browser="Firefox" --where "class==EasyPayTests.CriticalTests" 
pause