# **Custom Scene Set Up by using "Finch Unity SDK v1.0.1" in Unity**

[<- Go back](../README.md) 

Some recommendations to set up custom scene by using "Finch Unity SDK v1.0.1" in Unity.   

1. Open Unity Hub and press the **Open** button

<img src="pictures/SetupScene/1-Open-Unity-Hub.png" width="600">

2. Select the folder with the Unity SDK project and open it.

<img src="pictures/SetupScene/2-Open-Unity-Folder.png" width="600">

3. Drag and drop the “Calibration” prefab to the Hierarchy window. 

<img src="pictures/SetupScene/3-Add-Calibration-prefab.png" width="600">

4. Drag and drop the “**LeftShiftController**” and “**RightShiftController**” prefabs to the Hierarchy window.

<img src="pictures/SetupScene/4-Add-controller-prefabs.png" width="600">

5. Press the right button in the Hierarchy window and press “Create Empty” to create a new GameObject.  
Add the “**Finch Manager**” component.  
Choose the “**Shift**” Controller Type.  
Drag and drop the “**Main camera**” scene to the Head.  

<img src="pictures/SetupScene/5-Edit-Gameobjects.png" width="600">

6. In the “Calibration” prefab for each prefab included (**ConnectionSet**, **BindsControllerStep** and **ShiftRecenterStep**) add “Main camera” to the follower script (“Object to follow”):

<img src="pictures/SetupScene/6-Edit-Calibration-prefabs.png" width="600">

## “Follower” is not needed unless you want the calibration steps to follow the direction of gaze.





