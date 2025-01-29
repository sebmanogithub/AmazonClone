# Commandes .NET
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

### Ajoût des références
dotnet add Amazon.Clone.API/Amazon.Clone.API.csproj reference Amazon.Clone.Core/Amazon.Clone.Core.csproj    
dotnet add Amazon.Clone.API/Amazon.Clone.API.csproj reference Amazon.Clone.Infrastructure/Amazon.Clone.Infrastructure.csproj    
dotnet add Amazon.Clone.Infrastructure/Amazon.Clone.Infrastructure.csproj reference Amazon.Clone.Core/Amazon.Clone.Core.csproj    
dotnet add Amazon.Clone.Tests/Amazon.Clone.Tests.csproj reference Amazon.Clone.Core/Amazon.Clone.Core.csproj    
dotnet add Amazon.Clone.Tests/Amazon.Clone.Tests.csproj reference Amazon.Clone.Infrastructure/Amazon.Clone.Infrastructure.csproj    
dotnet add Amazon.Clone.Tests/Amazon.Clone.Tests.csproj reference Amazon.Clone.API/Amazon.Clone.API.csproj





# Commandes Node.js    

node -v    
nvm list    
nvm install 18.19.1    
nvm use 20.14.0    
npm install -g @angular/cli@17    

# Commandes Angular 
ng new client

