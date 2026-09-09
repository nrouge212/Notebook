# NoteBook

Application de bureau WPF permettant de gérer des notes, des modules et des unités d'enseignement. 

## Contexte du Projet
Ce projet est réalisé dans le cadre du module **R3.04 - Qualité de développement** du BUT Informatique à l'IUT de Nevers. Il a pour but de mettre en pratique les principes de conception logicielle (comme SOLID) et de structurer une application graphique en différentes couches indépendantes.

## Architecture
La solution est découpée en 3 projets distincts pour séparer les responsabilités :
- **NoteBook (IHM)** : Interface utilisateur graphique développée en C# WPF. Gère l'affichage, l'ajout, l'édition et la suppression des unités.
- **Logic (Métier)** : Cœur de l'application sous forme de bibliothèque de classes. Contient la logique des éléments pédagogiques (`EducationalElement`, `Unit`, `Module`, `Exam`, `NoteBook`) et la gestion des exceptions métier (ex: coefficients strictement positifs, notes entre 0 et 20).
- **TestLogic (Tests)** : Projet de tests unitaires (xUnit) assurant la fiabilité de la couche métier et le respect des contraintes.

## Installation et Lancement
1. Cloner le dépôt sur votre machine locale.
2. Ouvrir la solution `NoteBook.sln` avec **Visual Studio 2026**.
3. S'assurer que les références entre les projets sont bien configurées (IHM -> Logic <- TestLogic).
4. Définir le projet `NoteBook` (l'application WPF) comme projet de démarrage.
5. Compiler la solution et lancer l'application.

## Fonctionnalités implémentées
- Affichage de la liste des Unités d'Enseignement (UE).
- Ajout d'une nouvelle unité avec vérification des doublons.
- Modification du nom et du coefficient d'une unité existante via un double-clic.
- Suppression d'une unité de la liste.

## Auteur
* **Noha Rougé**
