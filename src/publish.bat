@echo off
mkdir nupkgs
cd nupkgs
del /F /Q *.*
cd ..
cd "Bolt.Common.Extensions"
dotnet restore
dotnet build -c Release
dotnet pack -c Release --no-build --output ../nupkgs
set /p key="Enter Key: "
cd ../nupkgs
dotnet nuget push *.nupkg -s https://www.nuget.org/api/v2/package/ -k %key%
cd ..