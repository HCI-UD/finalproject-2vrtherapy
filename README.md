# ShoulderVRAssessment - Lauren Thesis Modifications
Oculus Quest integration for the iss3 branch of the project (contact sesegear@udel.edu for questions)

Trouble setting up after git clone? 
I personally had to remove Oculus Quest stuff because of dependency issues and me not having the correct things downloaded on the new PC
Make sure all the scripts attached to game objects are initialized correctly ... this is very tedious
You also need to go to the Asset Store and get VRTK

# Data Collection Scripts
*collectCoordinates.cs - called in TaskCounter.cs when the user hits their first dot i.e. starts the task, collects the X, Y, Z, pitch, yaw, and roll of each dot of the model. This helps you compare the data from the controller and can be visualized/compared using R. This means that the user should not change the location of the model (pressing the left trigger) once they hit their first dot because then the collected data will not be accurate since it moved. 
*exportController.cs - called in TaskCounter.cs right when they start the task (perhaps this should also be when they hit their first dot that way its more in sync with collectCoordinates.cs), collects the X, Y, Z, pitch, yaw, and roll of each dot of the right hand controller (the paintbrush the user draws with). Stops collecting data when the victory animation plays once the task is completed (should this be when they hit their last dot?)
*exportHits.cs - called in changeColorOnEnter.cs when the task starts i.e. taskController has 0 hit dots, every time the color changes from red to green on a dot, add a new line to the file recording what cyliner number (taken from the game object name of each dot), time, and date hit. This helps you determine what order they hit each dot, what dots they missed/hit out of order (note that some dots are very close together so some mistakes are reasonable), and how long they took to complete the task (subtract start time from end time). 

# New Features
*2D Square Repeatable- for Amit, square model that is smaller and can be played multiple times without having to go through the after menu and reselect square. Benefits include being able to perform the square task multiple times in the same position/rotation continuously without a pause. This was done by using a SpecialTaskCounter.cs script that is called in the main MenuScript.cs
*Horizontal Model- if you press the left trackpad (big circle button) it flips any of the levels horizontally. The code is in TaskController.cs and is called from the LeftControllerAlias game object.
*Square and Chicken Models - before, you were not able to play these but I've made them responsive to the game by adding change color on enter scripts and colliders to each dot in the models. 
