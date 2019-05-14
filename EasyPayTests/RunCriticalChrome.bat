@echo off

set TestPath=%CD%\bin\Debug\EasyPayTests.dll
set ReportPath=%CD%\Test_Execution_Reports\EasyPayTests.CriticalTests\
cd ..\packages\NUnit.ConsoleRunner.3.10.0\tools

start nunit3-console %TestPath% --params:browser="Chrome" --where "class==EasyPayTests.CriticalTests" --result:%ReportPath%\result.xml

