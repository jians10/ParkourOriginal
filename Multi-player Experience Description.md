## Multiplayer Experience
### Description
This game is designed to be a mutiplayer game. Each user can create their own rooms. Once a room is created, it can be found through the "Find Room" option in the menu scene, then other users can join the room. When multiple players are in the single room, all their movements will be synchronized, and all the objects in the scene will also be synchronized according to the player's actions. For example, once an object has been picked up by a player, the other players should no longer see that object on the ground. Also, you can see there are floating stages in our current scence, players standing on the stages should go up and down synchronously with the stages and it should appear the same to the other players.

### How to Implement

#### Connection:

Utilize Photon Pun2 to support our net connection. In the first scene (menu scene), we build a launcher which allows the user to input their game id and to either create a room or join an existing room. 
These steps, or menus, are implemented by activating and deactivating different gameObject. We iterate through the menu array to check and make sure that only one menu page is currently in use.

#### Character animation with root motion

Change each animation’s rig to “Humanoid”
Copy the character’s avatar to our mesh.
Use “offset” and “curve” to manipulate movement range, such as the height of jumping or the distance of sliding. 
Write the script “animationReceiver” to catch the changes in animation, and use “Key Frame” to manage the transition between different animation based on those changes

#### Future Plan:

 Instead of using the same script to manipulate the movement and animation, we will build an animationController to focus on the animation part and to handle all information related to the animation. Thus, the codes for different sections will be separated.

#### Ability Design:

Most abilities are binding with our character. However, they remain inactive until we pick up a gadget, which sets a certain ability to be active with a certain time.

#### Map Construction:

We use YUME map maker to make the blueprint of our map. For now we are discussing the art style of our map. And we have already constructed the white mold of our map with basic shapes such as cube and stairs. Etc.

We have already found some great materials online for free, which will account for the most part. We also use blender to create meshes that are unique to our needs.

In order to reduce our work load, we convert those reusable elements such as “floating platform”, “elevator” etc. into modular prefab objects.


#### Special Effects - Particle System:

Add special effects using particle system.