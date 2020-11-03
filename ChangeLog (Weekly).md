## Week of 10/12
* Created the hide & seek map. The package we use to generate the maze is QMaze from https://assetstore.unity.com/packages/tools/modeling/qmaze-30600.
* Applied game objects created from last sprint into the new scene.
* Created new moving blocks (enabled movement in both x & y axis).
* Solved multiple synchronization problems of moving blocks.
* Enabled the climb movement (not applied to the hide & seek scene yet due to too many synchronization bugs).
* Reconfigured pickup objects to limit the duration of special abilities.

## Week of 10/19
* Created floating blocks.
* Enabled the "slide tackle" movement in the hide & seek scene.
* Solved synchronization & collider problems of floating blocks.
* Created two large objects in the game scene (the parking lot and the slope) & solved collider problems.
* Enabled pick-up movement (pick up cubes and blocks).
* Enabled throw movement and control of throw power by long-time pressing of the left mouse.
* Map - use meshes to build a track for running
* Map - interior lights rendering
* Map - use textures to make the scene seems more real

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
* **Getting Close To A Floating Panel + G + W** to climb on the panel that is slightly higher than you (This is still under testing, only one side of the walls can be climbed, and you may encounter bugs).
