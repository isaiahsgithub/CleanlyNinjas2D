Video Demo: https://www.youtube.com/watch?v=vQ3JP3_Nq8o

GitHub Repo: https://github.com/isaiahsgithub/CleanlyNinjas2D

Name: Isaiah von Uders 

Student Number: 251330269


Development Platform: Unity 2D - 2021.3.9f1 (https://unity.com/releases/editor/whats-new/2021.3.9)

How to execute the game: Navigate to the folder: "Cleanly Ninjas 2D/Build" and run the "Cleanly Ninjas 2D.exe" file.

How to install the game for Unity Editor (not required if just running the exe): Open "Unity Hub", ensure you have Unity 2D version 2021.3.9f1 installed, click the "Add" button at the top right of Unity Hub, navigate to where the game is downloaded to, select the folder that holds the folders: "Assets", "Build", "Library", "Logs", "obj", "Packages", "ProjectSettings", "Temp", "UserSettings" and the files ".vsconfig", "Assembly-CSharp.csproj", "Cleanly Ninjas 2D.sln". Select this folder as the folder. Now that you have selected the games location for Unity Hub, you can click on the project name "Cleanly Ninjas 2D" under projects to open the game in the unity editor. Once the project has loaded, under the assets folder in the project tab of the unity editor, select the "Scenes" folder, and double click "MainMenu". Once this is selected, click on the play button at the top of the screen to begin playing in the Unity Editor. Additionally, you can go to "File" -> "Build Settings" -> and make sure the "Scenes In Build" are "Scenes/MainMenu" and "Scenes/SampleScene". Then you can click "Build and Run" to run the game as it's own build (this is already provided under the build folder as mentioned before, but in case if you want to do it manually). 

To look at the scipts: Navigate to the folder: "Cleanly Ninjas 2D/Assets/Scripts"

This is a horizontal slice of my 2D platformer game "Cleanly Ninjas." It features a main menu screen, that has 2 functional buttons: 
- Tutorial: Allows the user to play the tutorial, which is the "horizontal" slice of my game.
- Quit Game: Allows the user to quit the game. (Executable file only).
There is a third button called "Level Selection" but it is hidden when ran in the executable file. That is because the upon completion, the game will have a proper level selection screen for each level, but it is not implemented yet. After selecting the tutorial, you will be able to go through the core gameplay of Cleanly Ninjas.

Features: 
- A HUD that informs the user on how many pieces of soap they have collected, the time it is taking the user to progress through the level, and the ninja count. This ninja count is so that the player knows how many more chances they have to gather all pieces of soap and to go for optimization strategies. The HUD is fully implemented.
- Overlay UI that informs the player which ninja they are currently playing as (purple, red, green, yellow, or white). The timer does not increase while this overlay is active. But the second a player moves (or presses any key), the overlay disappears and the timer/game begins. This is fully implemented.
- Ninjas. The ninjas are represented by squares, but they have full functionality (moving, jumping, interacting with objects, not falling through floors, not passing through walls, etc.). 
- Map. The tutorial level is basic with very boring textures. But the level is still functional.
- Pieces of soap. Soap is the collectable object in the game, and in order to make the tutorial simple there is only 1 piece of soap to be collected. To collect a piece of soap, the player just walks in to it. The functionality of the soap is fully implemented.
- Doors. Doors take you from one level of an area to another. The door is fully functional, but the texture is temporary. 
- Blockages. Blockages are walls that the player cannot pass through unless if they interact with some interactable object somewhere on the level. The blockage disappears once the correct interactable object is interacted with. The blockages are fully functional, but using temporary textures.
- Levers. Levers are one way to deal with blockages. To interact with a lever you simply walk into it. This turns the lever from one direction to the other, and lights up green to indicate that it is activated. This is fully implemented.
- Counting Tiles. Counting tiles are tiles on the ground that need to be stepped on a certain amount of times before they remove the blockage. For example, if a counting tile has the number "3" on it, it means that the ninja has to step on this tile 3 times and then the blockage will be destroyed. Once the counting tile reaches 0, it also lights up green. This is fully implemented.
- Buttons. Buttons remove blockages while they are stepped on. The moment a ninja steps off of a button, the blockage returns. When stepping on a button, the top of the button slightly shrinks down (to demonstrate that it is being pressed), and it lights up green. This is fully implemented.
- Ninja Clones. After playing through the level as one Ninja, the player may press SPACE (see controls for more) to go back to the start of the level as a ninja clone, while their previous actions will be repeated. All the objects that the player performed as the previous ninja will be replayed and performed back at the exact same time that they were originally performed. For example, if the player interacts with a lever at 00:10, then upon replaying the level, at 00:10 the ninja clone will interact with the exact same lever, in the exact same way. This allows the player to speed up their traversal through the level, and try to optimize their clear routes. This is fully implemented.
- Clear flag. When reaching the end of the level as the white ninja, there is a flag that when reached congratulates the player. 2 buttons appear, allowing the user to either retry the level, or return to the main menu. This is fully implemented (but the textures will be updated to not be squares).
- Clear conditions. If a user collects all pieces of soap, then clears the level, the game recognizies that the player "100%"'d the level. If the player did not collect all pieces of soap in the level, then they cleared under the clear condition "Any %". This is fully implemented.
- Saving and Loading score. When clearing a level the game automatically checks your clear time with your best clear time (that is saved on disk). If your current performance is better, your new score is saved. If there is no existing score for the level, your current score will automatically be saved. The files are saved as text files, under: "C:\Users\<USERNAME>\AppData\LocalLow\DefaultCompany\Cleanly Ninjas 2D". The files are saved as 2 digit names, where the first digit is the level (0=tutorial), and the second digit represents the clear condition (0=100%, 1=any%). The contents of the file are a JSON of the best clear time. This is fully functional. Additionally, there is a function made to load the best scores for the level selection screen that is fully developed, but the level selection screen itself is not made yet (as it is outside the scope of this horizontal slice).

SampleScene is the tutorial scene. MainMenu is the main menu scene.

Things that are left to do:
- Change the Ninjas to not be squares, but be fully animated characters.
- Improve the looks of the level (but not too much, as stated in my pitch I want the textures to be basic so that it can run on a variety of computers).
- Make the game look better, with better textures
- Implement more levels under a level selection screen
- Add background music
- Add sound effects
- Level selection screen, with best clear times for both clear conditions displayed.
- Reward for "100%" clearing all of the levels.

Controls:
- Left/Right arrow keys to move left/right
- Up arrow key to jump
- "R" key to restart as current ninja clone
- "F" key to full restart (reset timer, spawn back in as the original purple ninja)
- Space key to end turn as current ninja.