# Set Working Directory
Split-Path $MyInvocation.MyCommand.Path | Push-Location
[Environment]::CurrentDirectory = $PWD

Remove-Item "$env:RELOADEDIIMODS/p3rpc.nativetypes/*" -Force -Recurse
dotnet publish "./p3rpc.nativetypes.csproj" -c Release -o "$env:RELOADEDIIMODS/p3rpc.nativetypes" /p:OutputPath="./bin/Release" /p:ReloadedILLink="true"

# Restore Working Directory
Pop-Location