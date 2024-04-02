@echo off

REM Get the current directory
set "currentDir=%cd%"

REM Construct the full path to the CountryApp folder
set "appPath=%currentDir%\CountryApp"

REM Change directory to the CountryApp folder
cd "%appPath%"

REM Run the .NET application
start "" cmd /k "dotnet run"

REM Wait for a few seconds to ensure the application starts
timeout /t 10 /nobreak

REM Open the default web browser to the specified URL
start https://localhost:7093
