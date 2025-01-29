# .NET
 dotnet --list-sdks    
 dotnet --version    
 dotnet new globaljson --sdk-version 5.0.408  
 dotnet list Amazon.Clone.Tests/Amazon.Clone.Tests.csproj reference
 

# Création du projet
dotnet new sln -n AmazonClone    
dotnet new webapi -n Amazon.Clone.API    
dotnet new classlib -n Amazon.Clone.Core    
dotnet new classlib -n Amazon.Clone.Infrastructure    

## Ajoût de l'API, des bibliothèques de classes et du projet de tests à la solution
dotnet sln add Amazon.Clone.API/Amazon.Clone.API.csproj    
dotnet sln add Amazon.Clone.Core/Amazon.Clone.Core.csproj    
dotnet sln add Amazon.Clone.Infrastructure/Amazon.Clone.Infrastructure.csproj    
dotnet sln add Amazon.Clone.Tests/Amazon.Clone.Tests.csproj


## Ajout Tests Unitaires
dotnet new xunit -n Amazon.Clone.Tests

## Ajoût des références
dotnet add Amazon.Clone.API/Amazon.Clone.API.csproj reference Amazon.Clone.Core/Amazon.Clone.Core.csproj    
dotnet add Amazon.Clone.API/Amazon.Clone.API.csproj reference Amazon.Clone.Infrastructure/Amazon.Clone.Infrastructure.csproj    
dotnet add Amazon.Clone.Infrastructure/Amazon.Clone.Infrastructure.csproj reference Amazon.Clone.Core/Amazon.Clone.Core.csproj    
dotnet add Amazon.Clone.Tests/Amazon.Clone.Tests.csproj reference Amazon.Clone.Core/Amazon.Clone.Core.csproj    
dotnet add Amazon.Clone.Tests/Amazon.Clone.Tests.csproj reference Amazon.Clone.Infrastructure/Amazon.Clone.Infrastructure.csproj    
dotnet add Amazon.Clone.Tests/Amazon.Clone.Tests.csproj reference Amazon.Clone.API/Amazon.Clone.API.csproj

# Node.js    

node -v    
nvm list    
nvm install 18.19.1    
nvm use 20.14.0    
npm install -g @angular/cli@17    

# Angular 
ng new client

# Docker
### Commandes

docker-compose up --build      
docker-compose ps    

*Sous PowerShell - Admin*  utilisée pour arrêter toutes les distributions WSL (Windows Subsystem for Linux)
wsl --shutdown    

### Limitation ressources utilisées par Docker Desktop

Sous PowerShell     
notepad $env:USERPROFILE\.wslconfig     

[wsl2]    
memory=4GB   # Limite WSL à 4 Go de RAM (ajuste si besoin)    
processors=2 # Utilise seulement 2 cœurs CPU    
swap=2GB     # Ajoute 2 Go de swap pour éviter les crashs    

----------

Et utiliser une version légère du sdk    
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base

Ajout de dépendances natives si non existantes    
RUN apk add --no-cache <nom-du-paquet>

