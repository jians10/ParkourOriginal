## Week of 10/12
* Created the hide & seek map. The package we use to generate the maze is QMaze from https://assetstore.unity.com/packages/tools/modeling/qmaze-30600.
* Applied game objects created from last sprint into the new scene.
* Created new moving blocks (enabled movement in both x & y axis).
* Solved multiple synchronization problems of moving blocks.
* Enabled the climb (panel) movement (not applied to the hide & seek scene yet due to too many synchronization bugs).
* Reconfigured pickup objects to limit the duration of special abilities.

## Week of 10/19
* Created floating blocks.
* Enabled the "slide tackle" movement in the hide & seek scene.
* Solved synchronization & collider problems of floating blocks.
* Created two large objects in the game scene (the parking lot and the slope) & solved collider problems.
* Enabled pick-up movement (pick up cubes and blocks).
* Enabled throw movement and control of throw power by long-time pressing of the left mouse.
* Map - use meshes to build a track for running.
* Map - interior lights rendering,
* Map - use textures to make the scene seems more real.

## Week of 10/26
* Merged the environment scene to the main repository.
* Created new game objects in the new environment scene.
* Imported previously created objects into environment scene.
* Created "Portal" object, solved synchronization issues.
* Created jump board (not yet added to the scene).
* Enabled climb (wall) movement.

## Week of 11/2
* Solved synchronization issues related to photon connection.
* Enabled the "Infection" action.
* Enabled "Range Infection" ability.
* Solved synchronization issues related to infection action.
* Enabled climbing over small-height cubes
* MiniMap in Hide and Seek Map
* Upgraded inter-user connection to enable more fluent multi-player gaming.

## Week of 11/9
* Created new prefabs for the Parkour mode.
* Used new created prefabs to decorate the scene.
* Enabled one-player full gameplay of Parkour mode.
* Implemented the scoring board for Hide & Seek mode.
* Solved bugs of infecting action.
* Created a new bomb object -- the catcher will fall down for a few seconds if they touch this bomd

## Week of 11/16
* Created lava background scene & introduced background music for the Parkour mode.
* Improved lighting for both scenes.
* Implemented the scoring board for Parkour mode.
* Enabled multi-player full gameplay of Parkour mode.
* Enabled multi-player full gameplay of Parkour mode.
* Improved jump movement to make it look more natural.


## Up-To-Date Control Guide:
* **WASD** for movement.
* **SPACE** for jump.
* **MOVE YOUR MOUSE** for adjustment of visual angle.
* **KEEP RUNNING** in a particular direction to enter sprint mode
* **SHIFT** for dashing (need to enter sprint mode).
* **CAPS LOCK** for slide tackling (need to enter sprint mode).
* **E** for picking up cubes and other physical objects (still in development, lots of bugs) & **HOLD ON LEFT MOUSE** to control the throw power.
* **GOING THROUGH** star and diamond objects for special abilities.
* **SPACE + TAB** for rocket jet (diamond object).
* **KEEP RUNNING** for faster sprint (star object).
* **Getting Close to A Floating Panel + G + W** to climb on the panel that is slightly higher than you (This is still under testing, only one side of the walls can be climbed, and you may encounter bugs).
* **Getting Close to A Climbable Wall + R + W** to climb vertical wall (Notice that only the extended part of the vertical wall is climbale).
* **Run Toward A Small-Height Cube + G** to climb over the cube.
* **Go Throught the Portal** to be teleported.
* **Making Contact With A Blue-Color Player** to infect him (the infected player will turn red).
* **After Being Infected For 10s + E** to use the Range-Infection ability (Notice it has a 10s cooldown).
