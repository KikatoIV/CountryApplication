@echo on

REM Get the current directory
set "currentDir=%~dp0"

REM Change directory to the CountryApp folder
set "appPath=%currentDir%\CountryApp"

REM Change directory to the CountryApp folder
cd "%appPath%"

REM Build the .NET application
dotnet build

REM Run the .NET application
start "" cmd /k "dotnet run"

REM Wait for a few seconds to ensure the application starts
timeout /t 10 /nobreak

REM Open the default web browser to the specified URL
start https://localhost:7093

REM Keep the command prompt window open
pause
