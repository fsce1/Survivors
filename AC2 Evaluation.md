# Response to Brief
- Summary of what I need to actually do to finish this assignment
- Initial Reactions- will it be hard, easy, etc
	Why?
- What am I going to do?
# Idea Generation
- Idea Generation - at least 5
- Multiple game ideas
- Evaluate them and pick one
To begin I generated some ideas that take inspiration from the games I researched in the  [[AC1 Evaluation]].
I wanted to take the parts of each game that I enjoyed, while trying to fix the issues I had with them. 
## Game 1: PULYA
- Top-Down 2D Shooter, Mouse-based crosshair (no Aim-Assist)
- The "Draw" of the game is that you can shoot enemies' bullets out of the air, and deflect them back.
- It will have an ability system including passive upgrades and abilities (like a hero shooter, I.E. shields, AOE damage/crowd control, new movement tech such as dashing, charged shot for more damage, etc)
- Dark Souls style level design with lots of secret passages and shortcuts, with semi-random generation of prefab rooms (similar to [[Enter the Gungeon]]). This can teach younger audiences about spatial awareness and mapping areas in their head.
- Set in Victorian era, dark art style and historic weapons.
- Your character is a wraith, meaning they can turn invisible and dash forward a short distance. They have to find the person that turned them into a wraith and confront them.
## Game 2: SURVIVORS
- Top-Down 2D Shooter, Auto-aiming. Option to turn off auto-aim and use Mouse-based crosshair instead
- Similar to [[Risk of Rain 2]], Every 1 minute, the difficulty ticks up a level. Each time this happens, you can select from 3 difficulty-increasing "upgrades."
- Weapons and abilities randomly spawn around the level. They can be unlocked by trading in a certain number of kills (one kill is one "coin").
- Sci-fi, You play as a security guard/mercenary who has to fight off computer viruses in a Matrix-Style virtual world.
## Game 3: SURVIVORS2
- Action Platformer, side-on 2D shooter. This is more familiar to a younger audience as they may be more acquainted with games like Mario or Rayman. 
- Similar to [[Noita]] in shooting gameplay (aiming style, weapon cooldown/projectile speed)
- Shop area at the end of each level where you can buy abilities and passive upgrades 
- Tile-based generation of level sections (similar to [[Enter the Gungeon]], but side-on). This makes the game more replayable without getting into the complication of real procedural generation.
- Same story idea as Game 2, SURVIVORS
## Game 4: AUTOMATON
- Top-Down 2D Shooter, Auto-aiming.
- Automation controls such as auto-shooting, inventory management and combining upgrades.
- This would be very hard to create in one month, as it requires a lot of systems and different layers of controls.
- However it would be very interesting to create as this genre of game hasn't really been done with such a level of automation.
- Story is an engineer who has been abandoned in his spaceship, which is breaking, and he needs to traverse the area to fix things around the ship in order to get home, while fighting off hordes of aliens.
## Evaluation
Game 1, PULYA, was a good idea, however it would take too long to finish, as the level design is a large part of the gameplay. This would mean spending extra time on tilesets for art, drawing up plans for the level, and code for procedural generation of rooms that do not intersect and can be easily traversed. This means that i would have to spend less time on other parts of the game, and it would be a lot of work.
Game 3, SURVIVORS2, would be my second choice as it is almost as simple as SURVIVORS. However I think the bullet-hell aspects of the game would not work as well, since there would be lots of cover and blocks for the bullets to collide with. I would also need to figure out how AI would work, as it would need to pathfind around complex geometry.
Game 4, AUTOMATON, is another interesting idea, however it would likely be way too complex for this size of assignment. It would also not fit the brief as well as others, as it would require a lot of logic and micro-management. This means it may be too complex or difficult for a 10-15y/o to understand. However I think its story could be interesting. However, I dont think the story is enough to base my game off. 
Game 2, SURVIVORS, was my final choice. This was because it was unique enough that it provided a fresh take on the bullet-hell and roguelike genre, without getting too complicated with systems (such as AUTOMATON). It also had a good story idea, based on film The Matrix, and it would be fairly simple to write dialog and a small backstory.
# GDD
## Overview / Genre
SURVIVORS will be a bullet-hell roguelike that takes inspiration from Vampire Survivors and Risk of Rain 2, among other games of a similar style.
every 1 minute you get to decide (like a vampire survivor level-up) what part of the game you want to be harder (more health, more damage, faster movement, etc)
enemy kill count is the same as currency, and you buy upgrades with kills
## Weapons
Different weapons have different stats, such as the Pistol, which fires quite slowly and has slow-moving projectiles, and the SMG which can fire faster and has faster bullets, but lower accuracy.
This means you have to choose the most effective weapon for the specific circumstance and it adds some logical thinking to the game.
## Upgrades
### Special upgrades
- "Back-blast" - BB - Bullets propel you backwards in recoil.
- "Hidden Magnet" - HM - Bullets curve towards your crosshairs.
### Generic upgrades
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
## Camera
I think a slowly auto-scrolling camera will work well with this game, as it keeps the player on the right path. This is important because children often don't know the way to continue the game, and get lost very easily. an auto-scrolling camera means there is a very simple direction for the player to go and they cannot get sidetracked.
## Character Controller
Taking inspiration from Vampire Survivors, the game will be entirely playable with just one hand. The only controls you need to think about are WASD for movement, holding space to shoot automatically, and swapping weapons with Q and E.
## Replay Value/Progression
To unlock permanent upgrades, you reach milestones of kills (such as 100, 500, 1000, etc.)
These unlock abilities such as dashes, invisibility for a short time, etc.
Because I don't have enough time, I think I may miss out this feature for the deadline.
## Bosses/Enemies 
There will be 2 enemy types to start the level, Melee and Ranger. Melee will have a speed bonus and Rangers can fire bullets at the player.
As the game continues and they level up, there are rare upgrades that add new enemies to the mix, such as a shotgun-wielding enemy and larger boss enemies. 
## Game Mechanics 
The main game mechanics will be a bullet-hell style. This means that there are a lot of enemy bullets on screen that all move fairly slowly, and you have to dodge and weave through them in order to not get hit. The game progresses and gets more hectic/fast as it continues and ends when you die. Therefore I have a closed game loop that is re-playable.
## Health 
My initial idea is to have an integer-based health system, where you deal 1 damage and enemies deal 1 damage by default. When upgrades are applied, they are simple iterations (adding one to the current number) to the stat.
This makes it simple to understand these upgrades and stats, as the number of upgrades is equal to the stat itself (damage, maxHealth, etc.).
## Interactive Objects
Scattered throughout the level, there are player upgrades. These cost kills to pick up (starting at 10 and increasing by 5 each time), and make your character more powerful. Every time an enemy cycle happens, a random number (increasing by upgrades) will be placed in the map. 
Different weapons are also pickups in the map, though they don't cost any money to acquire. they will be placed further out from the spawn point depending on the quality of the weapon (you start with a pistol, then shotgun, then machine gun, etc.)
## Level Design 
The level design should be kept simple, as complications could occur with enemy pathfinding. it could also get frustrating for players to be trapped in an area, unable to dodge bullets or enemies. The bullets/enemies are the main obstacles that the player has to traverse through.
## Art Style 
I think a simple art-style would work for this game, so I chose an ASCII-based text style. This could be mixed with some post-processing effects such as Chromatic Aberration and Lens Distortion to give the game a "CRT Monitor" effect, like you are playing on an old computer/arcade game. For this, there is a Unity Package that provides a base for creating your own post-processing effects.
The program playscii is a simple ascii art editor, which is free on itch.io. It allows you to create ASCII art, and save it as png or image sequence for animations.
# Pitch
# Playtest Feedback
## Ryan Pedder- 17/01/2023
"This game is really good. I have a bit of feedback: 
The overall movement of both the enemies, the player and the Bullets are a bit slow. They could be sped up a bit more. 
After a while the enemies stopped spawning, but I think there were a few still alive off the screen because bullets were coming from the top left corner. 
It would be good to see more a variety of types of enemies"
## Niko - 30/01/2023
"its pretty fun, i definitely like the foundation, i will say it did feel pretty unintuitive at first and i was quite confused visual clarity wise but i think its pretty solid.
i did however get softlocked. i got curious and just tested the waters and i did eventually get all of the enemies to stop chasing me, because i had gone out of vision, and i guess i must have ended up somewhere crazy because i could not get back to the center of the playing field.
Suggestion: edge colliders attached as a child object of the camera to keep things clean and to prevent leaving bounds, or you could also just let the player move at their own pace and just do frustrum culling as you move potentially.
I think its quite enjoyable.
i also think the natural pacing felt very slow to start, thats just one of those game feel tweaking things, obviously i imagine you probably want the game to have a natural scaling sense of progression, but i think its worth finding a middle ground and just making everything faster if its taking a lot of downtime to get to the more fun parts of a game."
## Playtest Evaluation
This feedback was very valuable, as it showed me where i need to improve the game, and helped me fix some bugs (such as the enemies not chasing you after a certain amount of time, and stopping spawning). I fixed this by killing enemies that were outside of the view of the player so they didnt get trapped outside of the play area.
It also let me know how the pacing felt, as Niko thought it was a bit too slow to start off with. Ryan also thought that the player and bullets were too slow. Therefore, i will speed up the start of the game by modifying variables and possibly speeding up the enemy spawn rates.
I will also need to update the visuals of the game a bit, as Niko said it was quite obscured and hard to understand,