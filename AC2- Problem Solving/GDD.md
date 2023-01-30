## Power-ups
- Auto-aim "Target Acquisition" speed up, stack-able until it snaps onto enemies instantly

enemy kill count is the same as currency, trading souls like DS
buy upgrades with souls
buy large items with kills late-game
and you can sort those large items into custom classes
like your own characters in ror2, and they are abilities like dash
You can make your own character setups as these abilities are permanently unlocked
ScrollManager that is responsible for spawning loot


Upgrade Examples:
### Special upgrades
- "Back-blast" - BB - Bullets propel you backwards in recoil.
- "Hidden Magnet" - HM - Bullets curve towards your crosshairs.
###  Generic upgrades
- "Container of Hearts" - CH - Max Health += 1;
- "Wind's Blow" - WB - Movement Speed * 1.1;
- "Marksman's Meal" - MM - Target Acquisition * 0.9; //this is an upgrade- lower is better on this 
### Weapons
- Pistol
- Shotgun
- Machine Gun
### Enemy Upgrades
- "Strong Armor" - E-SA - All Enemies: Max Health += 1
- "Marksman's Scope" - E-MS - Rangers: Muzzle Vel * 1.1

meta progression is reaching milestones of number of kills

keep on shooting by holding space, e and q cycle through weapons

every 1 minute you get to decide (like a vampire survivor level-up) what part of the game you want to be harder (more health, more damage, faster movement, etc)
- enemies move faster 
- more enemy health
- more damage
- enemy bullets move faster/area up
- etc.


# WORKING-TITLE

# Overview 

# Genre

# Influences

# Camera

# Character Controller

# Replay Value/Progression

# Game Characters 

# Bosses/Enemies 

# Game Mechanics 

# Health 
My initial idea is to have an integer-based health system, where you deal 1 damage and enemies deal 1 damage by default. When upgrades are applied, they are simple iterations (adding one to the current number) to the stat.
This makes it simple to see these stats, as the number of upgrades is equal to the stat (damage, maxHealth, etc.).
# Interactive Objects
Scattered throughout the level, there are player upgrades. These cost kills to pick up (starting at 10 and increasing by 5 each time), and make your character more powerful. 
Different weapons are also pickups in the map, though they don't cost any money to acquire. they will be placed further out from the spawn point depending on the quality of the weapon (you start with a pistol, then shotgun, then machine gun, etc.)
# Level Design 
The level design should be kept simple, as complications could occur with enemy pathfinding it could get frustrating for players to be trapped in an area, unable to dodge bullets or enemies. The bullets/enemies "become" the environment that the player has to traverse through
# Art Style 
I think a simple art-style would work for this game, so I chose an ASCII-based text style. This could be mixed with some post-processing effects such as Chromatic Aberration and Lens Distortion to give the game a "CRT Monitor" effect, like you are playing on an old computer/arcade game.
The program playscii is a simple ascii art editor, which is free on itch.io. It allows you to create ASCII art, and save it as png or 
