# ShoulderVRAssessment for Oculus Quest

Oculus Quest integration for the iss3 branch of the project (contact sesegear@udel.edu for questions)

# Changes Made
Removed SteamVR and added Oculus Integration Asset. This allows program to be run with an Oculus Quest when it is disconnected from the PC, removing the constraint of a physical cable for the user.

# Setup Instructions
1. After opening the project in Unity, select the VRShoulderAssessmentChicken Scene from the Assets Folder
2. In the Build Settings (File->Build Settings) switch the platform to Android. Make sure the Oculus Quest is plugged into the computer and selected as the run device (may need to hit refresh and wait a moment) and that the compression method is LZ4. Click on switch platform (this may take a few minutes). 
3. Click on Build. 
4. Once it has finished building, unplug the Oculus Quest from the PC. Put on the headset, and naivgate to Apps (the icon with 9 little dots on the right side of the bottom menu) and select "Unknown Source" from the menu in the top right corner of the Apps screen. Then, select upperExtremityTracing from the top of the list of apps to launch the program. 
