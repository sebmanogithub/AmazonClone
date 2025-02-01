# Description du projet
Clone d'un site de vente en ligne tel qu'Amazon      
Technologies Utilisées :      
    - Angular 18    
    - .NET 8 avec EF Core 

## Côté Back
J'ai opté pour une architecture en couches pour une meilleure maintenabilité et séparation
des responsabilités.

### Amazon.Clone.API          
→ Couche API (Controllers, DTOs, Swagger, Auth)
### Amazon.Clone.Core         
→ Couche métier - Logique d'application (Services, Entités, Interfaces, Logique)
### Amazon.Clone.Infrastructure 
→ Couche d'accès aux données (EF Core, Repositories, Migrations)
### Amazon.Clone.Tests     
Tests de la logique métier (Core) et de l'API (API)     
→ Tests unitaires et d'intégration    

### *Choix de la base de données*

Dans un premier temps, je vais utiliser **SQLite** afin de faciliter la mise en place des Tests d'intégrations.
Puis, je passerais à PostGreSql en Docker pour les tests d'intégration avancés et la mise en prod.     
<u>Contraintes :</u> 
- Utilisation de GUID au lieu d’INT pour les IDs (compatible SQLite/Postgre).




## Côté Front



