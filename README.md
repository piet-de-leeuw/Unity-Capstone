# Unreal-Engine-Capstone
In this project I present the game that I made as Capstone Project for the C# and Unity Course from [The Tech Academy](https://www.learncodinganywhere.com/) Game Developer Boot Camp.
The Project was setup to stimulate a real job project as much as possible. Therefor I was given tasks in the form of user storys.

You can try the game itself [HERE]([url](https://piet-de-leeuw.github.io/Adventure-In-The-Wild/))

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
