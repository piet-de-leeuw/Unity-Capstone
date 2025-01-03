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

