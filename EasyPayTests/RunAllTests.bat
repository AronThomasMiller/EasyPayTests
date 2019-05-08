@echo off
set /p UserInputBrowser=Which browser would you like?
echo.%browser%

cd ..
cd packages\NUnit.ConsoleRunner.3.10.0\tools
set ConsolePath=%CD%
echo.%ConsolePath%
pause