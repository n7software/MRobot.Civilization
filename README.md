# Civilization

A .Net library that has reverse engineered much of the file structure for saved games in **Sid Meier's Civlization V** and **Sid Meier's Civilization: Beyond Earth**. This library supports parsing, modifying, and saving an existing save file or creating a new game configuration file from scratch. It provides a set of classes that expose almost all settings stored in a save file such as:
- Number and type of players (Human vs AI)
- Civilizations, Leaders, Colors, and Difficulties for each player
- Local passwords for HotSeat players
- All DLC enabled in the save
- All map and game settings
- Who's turn it currently is
- Which team each player is on 

It does _**not**_ support changing actual game elements such as:
- Units, buildings, cities, techs, gold, etc...
- Culture, Espionage, Diplomacy, or Messages

This library is used in conjunction with the [Multiplayer Robot](https://new.multiplayerrobot.com) service to automate much of the administration of an asynchronous multiplayer game played across the internet.
