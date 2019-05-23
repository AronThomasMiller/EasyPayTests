@echo off

set TestPath=%CD%\bin\Release\EasyPayTests.dll
set ReportPath=%CD%\Test_Execution_Reports\EasyPayTests.CriticalTests\
cd ..\packages\NUnit.ConsoleRunner.3.10.0\tools

start nunit3-console %TestPath% --params -browser="Chrome" --where "cat == Critical"