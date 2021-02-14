# Tower_Defense
This is a position defense Android game made by Patrick McDaniel for his Senior Project at Oregon Institute of Technology.  This will cover courses CST 412, CST 422 and CST 432.


This is an augmented reality game where the user holds their Android device in front of them. When the user rotates their body or moves their phone up or down it
pans the camera around in a 3d environment.  The 3d environment is created by taking an equirectangular (a type of 360 degree) photograph from the real world and superimposing enemies in it.  The user cannot move their character, only adjust where the camera is pointed.  There will be various levels where a
variety of enemies advance towards the user, it is the users's objective to shoot the enemy before they reach the user.  When the enemy reaches the user they will
attack the user until the user's health is reduced to 0.  The user will be scored based on their performance on each level.  After each level they will have the
opportunity to purchase upgraded weapons for the upcoming level. The user's performance will be graded on things such as how much health they lost, and how quickly
they complete the level.

There are several C# scripts that govern the mechanics of this game. These are located in the Tower Defense/Assets/Scripts folder. 

EnemyController.cs            Controls the movements and actions of the enemy

EnemyCount.cs                 Controls the current amount and the spawn locations of the enemy.

Guns.cs                       Controls which gun is selected and its properties.

GyroCamera.cs                 Uses the accelerometer in the user's device to control camera movement.

MouseCamera.cs                Allows the use of the mouse to pan the camera when testing the application on a pc.

User.cs                       Governs things such as the user's hit points.
