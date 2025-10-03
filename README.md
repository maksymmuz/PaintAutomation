# PaintAutomation

Automated UI tests for Microsoft Paint application using C# and WinAppDriver.

## Tech stack
- .NET 8 / C#
- NUnit
- FluentAssertions
- WinAppDriver
- Page Object Model (POM) pattern

## Project structure
- **PaintAutomation.Core** – shared utilities and helpers
- **PaintAutomation.UI** – page objects (UI elements and actions)
- **PaintAutomation.Tests** – automated test cases, grouped by features

## How to run
1. Install [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
2. Install [WinAppDriver](https://github.com/microsoft/WinAppDriver)
3. Start WinAppDriver before running tests:
   ```bash
   WinAppDriver.exe 127.0.0.1 4723
