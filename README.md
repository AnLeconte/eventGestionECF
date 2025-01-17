# Gestion d'une plateforme d'événements en ASP.NET Core

Ce projet consiste à développer une application web permettant de gérer des événements, leurs participants et des statistiques associées, en utilisant ASP.NET Core, Entity Framework Core, et une base de données SQL. Une base NoSQL (MongoDB) est également intégrée pour les données statistiques.

---

## Prérequis

- **Visual Studio 2022** ou **JetBrains Rider** (avec le support pour ASP.NET Core).
- **.NET 6.0 ou ultérieur**.
- **SQL Server** pour la base relationnelle.
- **MongoDB** pour la base NoSQL.
- Outil de ligne de commande `dotnet-ef` :
  ```bash
  dotnet tool install --global dotnet-ef
  ```
- Git pour le versionnement du code.

---

## Installation et configuration

### 1. Clonez le projet

Clonez le dépôt Git à l’emplacement de votre choix :
```bash
git clone <https://github.com/AnLeconte/eventGestionECF>
cd <eventGestionECF>
```

### 2. Configurez la base de données

#### Base relationnelle (SQL Server)
1. Assurez-vous que SQL Server est installé et en cours d’exécution.
2. Mettez à jour la chaîne de connexion dans `appsettings.json` :
   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=EventDB;Trusted_Connection=True;"
   }
   ```
3. Ajoutez les migrations EF Core et appliquez-les :
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

#### Base NoSQL (MongoDB)
1. Installez MongoDB et assurez-vous qu’il est actif.
2. Mettez à jour la chaîne de connexion dans `appsettings.json` :
   ```json
   "ConnectionStrings": {
       "MongoDBConnection": "mongodb://localhost:27017"
   }
   ```

### 3. Lancez l’application

Exécutez la commande suivante pour démarrer le projet :
```bash
dotnet run
```
L’application sera disponible à l’adresse `http://localhost:5000`.

---

## Fonctionnalités

1. **Gestion des événements** :
   - Création, modification, suppression et affichage des événements.
   - Association de participants à un événement.

2. **Gestion des participants** :
   - Ajout de participants avec leurs informations (nom, contact, type d’inscription).
   - Recherche et filtrage des participants.

3. **Statistiques en temps réel** :
   - Extraction des données pour générer des graphiques (nombre de participants, répartition par type, etc.).

4. **Interface utilisateur intuitive** :
   - Tableau de bord interactif (basé sur Razor Pages ou React).
   - Pages réactives avec Bootstrap ou TailwindCSS.

---

## Structure du projet

```
EventGestion
├── Controllers       # Contrôleurs ASP.NET Core
├── Models            # Modèles de données (EF Core)
├── Services          # Logique métier (ex : gestion des statistiques)
├── Views             # Vues Razor (si applicable)
├── wwwroot           # Fichiers statiques (CSS, JS, images)
├── appsettings.json  # Configuration des chaînes de connexion
└── Program.cs        # Point d’entrée de l’application
```

---

## Problèmes fréquents

1. **Erreur lors de l’exécution de `dotnet ef migrations add` :**
   - Assurez-vous que `dotnet-ef` est installé avec la commande suivante :
     ```bash
     dotnet tool install --global dotnet-ef
     ```
   - Vérifiez que le fichier `Program.cs` ne contient pas d’erreurs de syntaxe ou de modificateurs invalides.

2. **Problèmes de connexion à SQL Server ou MongoDB :**
   - Confirmez que les bases de données sont en cours d’exécution.
   - Testez les chaînes de connexion dans `appsettings.json`.

3. **Problèmes de compilation ou de dépendances :**
   - Lancez une restauration des packages :
     ```bash
     dotnet restore
     ```

---

## Technologies utilisées

- **Backend** : ASP.NET Core 6
- **ORM** : Entity Framework Core
- **Frontend** : Razor Pages
- **Base relationnelle** : SQL Server
- **Base NoSQL** : MongoDB
- **UI** : Bootstrap

---

## Auteur

- **Nom** : LECONTE Antoine


