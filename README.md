# Demos_Visualisation

Ce projet permet de projeter en réalité augmentée des parcelles d'agroforesterie. Chaque parcelle est à la taille d'une maquette. Le but est de représenter 3 phénomènes intervenant sur des parcelles d'agroforesterie :
- La quantité de lumière reçue par le sol en tenant compte de la présence d'arbres.
- La répulsion des ravageurs et donc la protection naturelle d'une zone, grâce à certaines essences d'arbres.
- Le passage des machines agricoles entre les arbres de la parcelle 


## Installation

1. **Prérequis**
   Assurez-vous d'avoir Unity installé sur votre système.

2. **Téléchargement et Configuration**
   - Clonez le dépôt du projet depuis GitHub.
   - Ouvrez Unity Hub et ajoutez le projet Unity téléchargé.

3. **Lancement**
   - Ouvrez le projet dans Unity.
   - Build le projet sur un appareil avec Android 7 au minimum.

## Fonctionnalités

- Les utilisateurs peuvent observer 7 visualisations différentes. Les 3 premières sont : "la quantité de lumière au sol", "la répulsion des ravageurs" et "le passage des machines". Les 4 suivantes sont des combinaisons de 3 premières.
- Sur chaque visualisation, il est possible de modifier la taille des arbres à l'aide d'un curseur sur la gauche de l'écran. 
- Sur les visualisations comprenant "le passage des machines", plusieurs interactions sont possibles. L'utilisateur peut, via le bouton en bas à droite, ajouter un tracteur sur la scène et slectionner la taille de l'outil agricole tracté par le tracteur. A la base de l'écran, un bouton play/pause permet de stopper ou mettre en mouvement le tracteur.  

### Scripts Principaux

Le projet est structuré en plusieurs scripts pour gérer différents aspects de l'application :

- **`ARManager`** : Plusieurs scripts ARManager gèrent l'initialisation de la réalité augmentée (RA) et la gestion des parcelles selon la visualisation.
- **`SliderManager`** : Plusieurs scripts SliderManager gèrent les paramètres liés aux curseurs pour contrôler la croissance des arbres dans les différentes scènes.
- **`Tractor`** : Plusieurs scripts tracteurs permettent d'ajouter, contrôler et gérer les tracteurs.
- **`CollisionTractor`** : Plusieurs scripts CollisionTractor permettent de gérer les interaction visuels entre les arbres et le tracteur quand celui-ci entre en contact avec eux.
- **`FollowPath`** : Plusieurs scripts FollowPath permettent de gérer la rotation de boucliers autour des différentes zones protégées par des ravageurs. 
- **`MenuManager`** : Ce script permet de naviguer entre les différentes visualisations.

### Utilisation

1. Au démarrage, l'application affiche une fenêtre indiquant que 7 visualisations vont être présentées et que entre chaque visualisation, une autre fenêtre demandera à l'utilisateur de répondre à un questionnaire. Ces questionnaires, qui avaient pour but de tester les visualisations, ne sont pas présent directement dans ce projet. Sur cette première fenêtre il suffit de cliquer sur le bouton "commencer" pour lancer la première visualisation.
2. Sur chaque visualisation, un bouton "Répondre aux questions" permet de passer à la visualisation suivante. Un bouton retour est également présent.
3. Sur la fenêtre appelant à répondre au questionnaire, il suffit de cliquer sur "Passer à la démo suivante" pour continuer.
4. La dernière fenêtre remercie l'utilisateur et permet de quitter l'application.

### Notes Additionnelles

- L'application utilise la réalité augmentée (AR). ARCore doit être à jour sur le mobile ou la tablette utilisée.
- Pour une utilisation optimale, l'utilisateur doit avoir une surface plane (comme une table) à disposition.


## Packages nécessaires

- AR Foundation 4.2.8
- ARCore XR Plugin 4.2.7
- JetBrains Rider Editor 3.0.18
- Test Framework 1.1.31
- TextMeshPro 3.0.6 
- Timeline 1.6.4
- Tutorial Framework 3.1.1 
- Unity UI 1.0.0
- Universal RP 12.1.10
- Version Control 2.0.1
- Visual Scripting 1.8.0
- Visual Studio Code Editor 1.2.5
- Visual Studio Editor 2.0.17 
- XR Plugin Management 4.2.0 


## Contributeurs

- Clément Dahan
