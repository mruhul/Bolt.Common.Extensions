set /p packageName="Project name: "
set /p version="Version: "
echo %packageName%
cd %cd%/%packageName%/
dotnet pack -c Release --version-suffix %version%
set /p apiKey="Api Key: "
dotnet nuget push %cd%\bin\Release\%packageName%.%version%.nupkg -s https://www.nuget.org/api/v2/package -k %apiKey%
cd ..