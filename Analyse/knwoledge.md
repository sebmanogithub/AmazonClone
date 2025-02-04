# .NET
 ```
 dotnet --info
 dotnet -h
 dotnet new -h
 dotnet --list-sdks    
 dotnet --version    
 dotnet new webapi -o API -f net5.0
 dotnet new globaljson --sdk-version 5.0.408  
 dotnet list Amazon.Clone.Tests/Amazon.Clone.Tests.csproj reference
 
 dotnet new gitignore
 
 dotnet dev-certs https --trust
 dotnet run
 dotnet watch run
 ```
 
 # Entity Framework
```
dotnet add package Microsoft.EntityFrameworkCore --version 5.0.17
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 5.0.17
dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 5.0.17

dotnet tool install --global dotnet-ef --version 5.0.17
dotnet ef migrations add InitialCreate -o Data/Migrations
dotnet ef database update

Projet AmazonClone

dotnet add Amazon.Clone.Infrastructure/Amazon.Clone.Infrastructure.csproj package Microsoft.EntityFrameworkCore
dotnet add Amazon.Clone.Infrastructure/Amazon.Clone.Infrastructure.csproj package Microsoft.EntityFrameworkCore.Sqlite
dotnet add Amazon.Clone.Infrastructure/Amazon.Clone.Infrastructure.csproj package Microsoft.EntityFrameworkCore.Design

dotnet add Amazon.Clone.API/Amazon.Clone.API.csproj package Microsoft.EntityFrameworkCore.Design

dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate --project Amazon.Clone.Infrastructure --startup-project Amazon.Clone.API
dotnet ef database update --project Amazon.Clone.Infrastructure --startup-project Amazon.Clone.API

dotnet ef database drop --project Amazon.Clone.Infrastructure --startup-project Amazon.Clone.API -f

```

dotnet ef migrations add InitialCreate ...
dotnet ef database update ....

# Création du projet
```
dotnet new sln -n AmazonClone    
dotnet new webapi -n Amazon.Clone.API    
dotnet new classlib -n Amazon.Clone.Core    
dotnet new classlib -n Amazon.Clone.Infrastructure  
```  

## Ajoût de l'API, des bibliothèques de classes et du projet de tests à la solution
```
dotnet sln add Amazon.Clone.API/Amazon.Clone.API.csproj    
dotnet sln add Amazon.Clone.Core/Amazon.Clone.Core.csproj    
dotnet sln add Amazon.Clone.Infrastructure/Amazon.Clone.Infrastructure.csproj    
dotnet sln add Amazon.Clone.Tests/Amazon.Clone.Tests.csproj
```


## Ajout Tests Unitaires
```
dotnet new xunit -n Amazon.Clone.Tests
```

## Ajoût des références
```
dotnet add Amazon.Clone.API/Amazon.Clone.API.csproj reference Amazon.Clone.Core/Amazon.Clone.Core.csproj    
dotnet add Amazon.Clone.API/Amazon.Clone.API.csproj reference Amazon.Clone.Infrastructure/Amazon.Clone.Infrastructure.csproj    
dotnet add Amazon.Clone.Infrastructure/Amazon.Clone.Infrastructure.csproj reference Amazon.Clone.Core/Amazon.Clone.Core.csproj    
dotnet add Amazon.Clone.Tests/Amazon.Clone.Tests.csproj reference Amazon.Clone.Core/Amazon.Clone.Core.csproj    
dotnet add Amazon.Clone.Tests/Amazon.Clone.Tests.csproj reference Amazon.Clone.Infrastructure/Amazon.Clone.Infrastructure.csproj    
dotnet add Amazon.Clone.Tests/Amazon.Clone.Tests.csproj reference Amazon.Clone.API/Amazon.Clone.API.csproj
```

# Node.js    

```
node -v    
nvm list    
nvm install 18.19.1    
nvm use 20.14.0    
nvm use 16.13.2    
``` 

# Angular 
```
npx @angular/cli@12.2.18 new mon-projet //Installation en local
npx @angular/cli@18 new gameotheque //Installation en local

ng new client --strict false

Bonnes pratiques en entreprise : Structuration telle quelle
Créé d'abord un workspace 
ng new gameotheque-workspace --create-application=false
Puis 
ng g app gameotheque
ou
ng g lib ...

On peut rajouter par la suite des projets de type librairie que l'on pourra connecter par la suite avec l'app ng
```

# Docker
### Commandes

```
docker-compose up --build      
docker-compose ps   
``` 

*Sous PowerShell - Admin*  utilisée pour arrêter toutes les distributions WSL (Windows Subsystem for Linux)
```
wsl --shutdown   
``` 

### Limitation ressources utilisées par Docker Desktop

Sous PowerShell     
```
notepad $env:USERPROFILE\.wslconfig 
```    

[wsl2]    
memory=4GB   # Limite WSL à 4 Go de RAM (ajuste si besoin)    
processors=2 # Utilise seulement 2 cœurs CPU    
swap=2GB     # Ajoute 2 Go de swap pour éviter les crashs    

----------

Et utiliser une version légère du sdk    
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base

Ajout de dépendances natives si non existantes   
``` 
RUN apk add --no-cache <nom-du-paquet>
```

