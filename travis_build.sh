#!/bin/sh
cd src
dotnet restore
dotnet build -c Release -f netcoreapp1.0 project.json
