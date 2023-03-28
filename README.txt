GitHub Repo: https://github.com/isaiahsgithub/CleanlyNinjas2D

Name: Isaiah von Uders 

Development Platform: Unity 2D - 2021.3.9f1 (https://unity.com/releases/editor/whats-new/2021.3.9)

How to execute the game: Navigate to the folder: "Cleanly Ninjas 2D/Build" and run the "Cleanly Ninjas 2D.exe" file.

How to install the game for Unity Editor (not required if just running the exe): Open "Unity Hub", ensure you have Unity 2D version 2021.3.9f1 installed, click the "Add" button at the top right of Unity Hub, navigate to where the game is downloaded to, select the folder that holds the folders: "Assets", "Build", "Library", "Logs", "obj", "Packages", "ProjectSettings", "Temp", "UserSettings" and the files ".vsconfig", "Assembly-CSharp.csproj", "Cleanly Ninjas 2D.sln". Select this folder as the folder. Now that you have selected the games location for Unity Hub, you can click on the project name "Cleanly Ninjas 2D" under projects to open the game in the unity editor. Once the project has loaded, under the assets folder in the project tab of the unity editor, select the "Scenes" folder, and double click "MainMenu". Once this is selected, click on the play button at the top of the screen to begin playing in the Unity Editor. Additionally, you can go to "File" -> "Build Settings" -> and make sure the "Scenes In Build" are "Scenes/MainMenu" and "Scenes/SampleScene". Then you can click "Build and Run" to run the game as it's own build (this is already provided under the build folder as mentioned before, but in case if you want to do it manually). 

To look at the scipts: Navigate to the folder: "Cleanly Ninjas 2D/Assets/Scripts"

To look at the citations for the external assets - Refer to the file: "Cleanly Ninjas 2D/Assets/Sources for External Assets.txt"

Features: 
- A HUD that informs the user on how many pieces of soap they have collected, the time it is taking the user to progress through the level, and the ninja count. This ninja count is so that the player knows how many more chances they have to gather all pieces of soap and to go for optimization strategies. The HUD is fully implemented.
- Overlay UI that informs the player which ninja they are currently playing as (purple, red, green, yellow, or white). The timer does not increase while this overlay is active. But the second a player moves (or presses any key), the overlay disappears and the timer/game begins. This is fully implemented.
- Ninjas. The ninjas are fully animated and there are 5 different colors of Ninjas (Purple, Red, Yellow, Green, Blue). They have full functionality (moving, jumping, interacting with objects, not falling through floors, not passing through walls, etc.)
- Map. There is one tutorial level, and 3 playable levels. The levels are fully textured, and as stated in the proposal, are fairly basic, to ensure that all users, regardless of PC specifications, can play Cleanly Ninjas.
- Pieces of soap. Soap is the collectable object in the game, and each level has different amounts of soap scattered throughout the level. To collect a piece of soap, the player just walks into it. Upon collecting a piece of soap, a sound que is played.
- Portals/Doors. Portals/Doors take you from one level of an area to another.  
- Blockages. Blockages are walls that the player cannot pass through unless if they interact with some interactable object somewhere on the level. The blockage disappears once the correct interactable object is interacted with. The blockages are fully functional, and are squares that have a caution tape material.
- Levers. Levers are one way to deal with blockages. To interact with a lever you simply walk into it. This turns the lever from one direction to the other, and lights up green to indicate that it is activated. 
- Counting Tiles. Counting tiles are tiles on the ground that need to be stepped on a certain amount of times before they remove the blockage. For example, if a counting tile has the number "3" on it, it means that the ninja has to step on this tile 3 times and then the blockage will be destroyed. Once the counting tile reaches 0, it also lights up green. 
- Buttons. Buttons remove blockages while they are stepped on. The moment a ninja steps off of a button, the blockage returns. When stepping on a button, the top of the button slightly shrinks down (to demonstrate that it is being pressed), and it lights up green. 
- Ninja Clones. After playing through the level as one Ninja, the player may press SPACE (see controls for more) to go back to the start of the level as a ninja clone, while their previous actions will be repeated. All the objects that the player performed as the previous ninja will be replayed and performed back at the exact same time that they were originally performed. For example, if the player interacts with a lever at 00:10, then upon replaying the level, at 00:10 the ninja clone will interact with the exact same lever, in the exact same way. This allows the player to speed up their traversal through the level, and try to optimize their clear routes. 
- Clear flag. When reaching the end of the level, there is a flag that when reached congratulates the player. 2 buttons appear, allowing the user to either retry the level, or return to the main menu. Upon clearing a level, congratulatory music plays.
- Clear conditions. If a user collects all pieces of soap, then clears the level, the game recognizies that the player "100%"'d the level. If the player did not collect all pieces of soap in the level, then they cleared under the clear condition "Any %".
- Saving and Loading score. When clearing a level the game automatically checks your clear time with your best clear time (that is saved on disk). If your current performance is better, your new score is saved. If there is no existing score for the level, your current score will automatically be saved. The files are saved as text files, under: "C:\Users\<USERNAME>\AppData\LocalLow\DefaultCompany\Cleanly Ninjas 2D". The files are saved as 2 digit names, where the first digit is the level (0=tutorial), and the second digit represents the clear condition (0=100%, 1=any%). The contents of the file are a JSON of the best clear time. Additionally, when opening the level selection screen, the best scores for each level (under both clear conditions) are loaded and displayed to the player. 
- Pause Menu. The player can press the ESC key to pause and unpause the game. When paused, no actions can be performed except for: "Unpause" and "Return to Main Menu". This is to ensure the integrity of the clear time is maintained, and to ensure that no ninja clones unintentionally move (giving the player an unfair advantage) while the timer is paused.
- Background Music. For the Main Menu, Level Selection Screen, and all Levels, there is background music playing. This background music loops to ensure that once it is finished playing it does not get quiet.
- Intro Cutscene. When the game is first loaded, a custom intro cutscene plays. Similar to other games, this cutscene can be skipped (resulting in the player going to the main menu) by pressing any key on the keyboard/mouse click. There is informative glowing text at the bottom of the screen to inform the player that they can skip the intro cutscene. If the player does not skip the cutscene, they will move to the main menu automatically once the cutscene is completed.
- Unlockable Reward (Outro Cutscene). If a player clears all levels under the level selection screen under the "100%" clear condition, a mysterious button that was previously labeled as "???" will become fully opaque and have its label change to "Epilogue". Upon clicking this button, a custom cutscene plays, showing that the ninja escaped the disgusting laboratory thanks to all of the soap he collected (by becoming slippery, he was able to slip through the locked gate). Once this cutscene finishes, a thank you message shows up on the screen, thanking the player for taking the time to play Cleanly Ninjas. From here, they can return to the main menu by pressing the "Return To Main Menu" button that also appears after the cutscene is completed.
- Level Selection Screen. This scene shows all of the available levels that a player can play. If a player has cleared a level under either "Any%" or "100%" clear conditions, their best time under the respected category will be shown next to the level. If the player has not cleared the level, a default time of "99:59" will be displayed.

Scenes:
- IntroCutscene: This scene contains the skippable intro cutscene. Upon completion, the player will automatically move to the Main Menu.
- MainMenu: This scene is the main menu, from here the player can access: "Level Selection Screen", "Tutorial", and "Quit Game".
- LevelSelectScene: This scene contains all of the available levels to play, the epilogue (secret ending), and the players best clear times under each clear condition (Any% and 100%). The player can return to the main menu from the "Return to Main Menu" button at the bottom of the screen.
- SampleScene: This scene contains all the levels.
- OutroCutscene: This scene contains the outro cutscene. The player can return to the Main Menu scene from here.


Controls:
- Left/Right arrow keys to move left/right
- Up arrow key to jump
- "R" key to restart as current ninja clone
- "F" key to full restart (reset timer, spawn back in as the original purple ninja)
- Space key to end turn as current ninja.
- "ESC" Key to pause/unpause the game. From here, the player can return to the main menu, or unpause the game.

For full "patch-notes" and version history, you can read the changelog here: https://github.com/isaiahsgithub/CleanlyNinjas2D/commits/main 