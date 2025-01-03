# Unreal-Engine-Capstone
In this project I present the game that I made as Capstone Project for the C# and Unity Course from [The Tech Academy](https://www.learncodinganywhere.com/) Game Developer Boot Camp.
The Project was setup to stimulate a real job project as much as possible. Therefor I was given tasks in the form of user storys.

You can try the game itself [HERE](https://piet-de-leeuw.github.io/Adventure-In-The-Wild/)

- [User-Story 1](#user-story-1)
- [User-Story 2](#user-story-2)
- [User-Story 3](#user-story-3)
- [User-Story 4](#user-story-4)
- [User-Story 5](#user-story-5)
- You can find all classes and scource code from this project [HERE](Capstone/Assets/Scripts)

## User-Story 1
STORY: User would like 4 basic scenes created for this game: a title scene, a gameplay scene, victory scene and game-over scene.

For the first story I was tasked with creating 4 simple Scene’s (Main Menu, Level 1, Game Over, and Victory) and making a class to handle scene loading.

![4Scenes.png](Images/Userstory-1/ 4Scenes.png)
  
I set up some scenes and created a LoadSceneManager class where I created an IEnumerator LoadScene to trigger Scene transition with delay.
After that I created a few methods that can be called to easily load other scenes. Some of them using LoadScene. 

![LoadSceneManager2.png](Images/Userstory-1/LoadSceneManager2.png)

![LoadSceneManager3.png](Images/Userstory-1/LoadSceneManager3.png)

After that I created some UI buttons to call some of the functions.

## User-Story 2
STORY: User would like the player character created for the game.In this story, you will create the player character for the game. This can be a basic square/cube for now as you will be able to come back and add more detail later. You will also need to create a script to respond to user input and add any necessary physics components.
This story will be complete when you have added a player character that the user can control.

I first created quickly a player mesh with some asset from the unity asset store and added the physics components like a collider and a rigidbody.

For movement I started with creating some classes to create a Finite State Machine to make it easy to implement further behavior in the future.
First I create the abstract class PlayerBaseState. This will be the template for all states. 

![PlayerBaseState.pn](Images/Userstory-2/PlayerBaseState.png)

I then created multiple state classes that inherit from PlayerBaseState for Idle, Run, Jump, attack, GetHit and Die, and declared the abstract functions.

![Empty-States.png](Images/Userstory-2/Empty-States.png)

Then I used the Animator to make a diagram of the transitions between the different states to visualize how all states are connected. For story 2, I will only implement Idle, Run and Jump because that is the basic movement.

![StateTransitionSchema2.png](Images/Userstory-2/StateTransitionSchema2.png)

Then I set up the PlayerController class to be able to use the State classes.

![PlayerController-Basic.png](Images/Userstory-2/PlayerController-Basic.png)

After that I set up the Idle, run and jump. The Jump state inherits from the PlayerRunState so the player can move in the air without having to rewrite that code and still being able to protect the Move method from being accessible to other classes that don’t need movement.
Every state sets its own animations. 
Update: I moved all the logic from PlayerRunState into PlayerBaseRunState only leaving the logic for switching states in PlayerRunState and letting the PlayeRunstate and PlayerJumpState inherit from it,  for more flexibility in the future. (for example when creating an attack, swim or fly state that uses the run logic for movement.)

![PlayerIdleState.png](Images/Userstory-2/PlayerIdleState.png)

![PlayerBaseRunState.png](Images/Userstory-2/PlayerBaseRunState.png)

![PlayerJumpState.png](Images/Userstory-2/PlayerJumpState.png)

I changed the Player animator for better implementation of the Jump Animations.

![Animator.png](Images/Userstory-2/Animator.png)

Update: after playing a little with my player in my environment I noticed that the controls didn’t feel right. Turning left and right didn’t feel intuitive and moving backwards made me turn towards the camera but then move in the false direction so I took another look ad it and fixed it. The player now uses the forward direction from the camera as rotateTo direction and I took out horizontal movement for at the moment it seems unnecessary because I changed the camera settings to use the mouse to rotate the player around.

![PlayerBaseRunStateUpdate.png](Images/Userstory-2/PlayerBaseRunStateUpdate.png)

## User-Story 3
STORY: User would like the environment of the gameplay scene created.
In this story, you will set up the environment of your gameplay scene. This can simply be objects with colliders added to the scene or you can utilize a TileMap and TileMap collider.
This can be kept simple for now but should have enough there for you to test out game elements that will be added in later stories.
This story will be complete when you have added the necessary gameplay area for the player to navigate.

I started with creating a terrain modifying setting up the layout of the game, adding in some textures and some walls. I also thougt about where the player can and can’t go and started to use that in my layout. From there I Added in walls, pillars and details.

![Environment.png](Images/Userstory-3/Environment.png)

<img src="Images/Userstory-3/Environment1.png" width="45%"/> <img src="Images/Userstory-3/Environment2.1.png" width="45%"/>

<img src="Images/Userstory-3/Environment3.png" width="45%"/> <img src="Images/Userstory-3/Environment8.png" width="45%"/>

![Environment6.png](Images/Userstory-3/Environment6.png)

After that I tried my player in the environment. I found out that my Player movement didn’t work really well with collision and that jumping didn’t feel good either so I decided to spent more time on the player movement. Rewriting the whole PlayerBaseRunState so it works with the Unity physics system and not against it. I rewrote jump to use Physics.Raycast for checking if we are on the ground, instead of collision detection because it was to much in conflict with other colliders on the player that collided. After that the player movement felt way better and it fixed the problems I hat with collision.

![PlayerRunBase.png](Images/Userstory-3/PlayerRunBase.png)

![PlayerRunBase1.png](Images/Userstory-3/PlayerRunBase1.png)

## User-Story 4
STORY: User would like collectibles and incentive to collect them added to the game.
In this story you will add challenges to the level as well as an incentive for completing these challenges. The collectibles you add can be an item the player can pick up that increases their score or acts as a powerup of some kind. The obstacles can be the level itself, a trap to avoid, or even simple enemies to fight.
This story will be complete when you have added necessary obstacles and collectibles to your game level.

I started with a sword the player can pick up and that automatically equips. Picking it up also triggers a door to open. 

![sword-pick-up.png](Images/Userstory-4/sword-pick-up.png)

Then for the obstacle I decided to create an enemy in the form of a bear. I started with code to start and stop chasing the player if the bear is in a certain ranch, start attacking if close enough and to return to its home base (start position) if this option is selected (bool ReturnHome). 

![BearController-ChaseFunctionality-part1.png](Images/Userstory-4/BearController-ChaseFunctionality-part1.png)

![BearController-ChaseFunctionality-part2.png](Images/Userstory-4/BearController-ChaseFunctionality-part2.png)

After that I setup a Health script so the attack of the bear can do damage to the player and so the player can die.

![Health.png](Images/Userstory-4/Health.png)

After that I implemented attack and refactored the health script so it can be used by enemy's as well. To do that I used an Interface so the health script can call the functions GetHit and Die in both the PlayerController and the BearController even thou both scripts work differently and are of other types.

![IController.png](Images/Userstory-4/IController.png)

![Health_refactored _part1.png](Images/Userstory-4/Health_refactored _part1.png)

![Health_refactored _part2.png](Images/Userstory-4/Health_refactored _part2.png)

<img src="Images/Userstory-4/weaponDamagePlayerController.png" width="45%"/> <img src="Images/Userstory-4/weaponDamageBearController.png" width="45%"/>
<img src="Images/Userstory-4/ImplementationIControllerPlayer.png" width="45%"/> <img src="Images/Userstory-4/ImplementationIControllerBear.png" width="45%"/>

After I tuned combat so it feels right.
Then I setup a DeathPit and BurnPits where the player dies or get hurt if he falls into it. 

![death-and-burnPit.png](Images/Userstory-4/death-and-burnPit.png)

After that I added a health power up and coins to raise the score.

<img src="Images/Userstory-4/health-powerup.png" width="45%"/> <img src="Images/Userstory-4/coin.png" width="45%"/>



