# Parkour
Please check [ChangeLog (Weekly)](https://github.com/jians10/ParkourOriginal/blob/main/ChangeLog%20(Weekly).md) for **Up-To-Date Information** & **Control Guide** of our project.

Please check [Multi-player Experience Description](https://github.com/jians10/ParkourOriginal/blob/main/Multi-player%20Experience%20Description.md) for our game's multiplayer experience.

## Game Videos
Click on the following links to watch example game-play videos:

[Parkour Mode](https://youtu.be/A6J-oLFG9Fs)

[Hide & Seek Mode](https://youtu.be/ruB_Gl0veFo)

## Instruction to Open the Project:
1. Clone the Parkour project from Github with URL https://github.com/jians10/ParkourOriginal.git

1. Open the file with Unity

1. Select unity project version to be 2019.4.9f1 and open it (if a window pops up that you need to update the version, just click yes/allow)

1. Now the project should be opened in Unity. Click on the Game button. It should show a 'loading' scene.
   if it is not a 'Loading' scene, select Project file -> Assets -> Scenes -> double click MenuScene.
   
1. Click play button in Unity. Then after a while it should start with 3 options: Find Room, Create Room, and Quit Game.
   **Click on "Create Room" + Specify "Room Index"**(see details below) and enter a name ->click create room. 
   
1. After loading, there will be a room waiting scene with players in the room. Just click start if you are single player. At this
   Moment, someone else might join you by clicking find room and select your room on his end. After joining, you can start game.
   
1. Now it should be into the actual game scene already (if you find your visual angle to be strange, you can press ctrl+B to buid the game and run it)

1. The map implementation is still in progress

## Room Index
Index 1: Training Mode (Get yourself familiar with the movements)

Index 2: Parkour Mode

Index 3: Hide & Seek Mode

## Role Distribution:
Leo: Map Design + Map Implementation + Documentation

Amy: Map elements + Animation

Shenxin: Photon synchronize + Network + Tech Support

Alex: Character ability + Pick-up tools + Map
