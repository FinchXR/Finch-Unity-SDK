# **Reference-API**

[<- Go back](../README.md) 

1. [Classes](#Classes)

   * 1.1 [FinchNodeManager](#Manage)
   * 1.2 [FinchNode](#Node)
   * 1.3 [FinchController](#Controller)
   * 1.4 [Buttons](#Buttons)
   * 1.5 [Swipe](#Swipe)

2. [Enums](#Enums)

## **<div id="Classes" /> 1. Classes**
   
* #### **<div id="Manage" />1.1 FinchNodeManager**  
    
    **Public static class** that provides functions to manage controller's state.

    Function | Description
    --- | --- 
    static [ControllerType ControllerType](./API-Example/GetControllerType.md) | Returns controller type.
    static [bool IsScanning](./API-Example/IsScanning.md) | Is Scanner searching right now.
    static [void StartScan](./API-Example/StartScan.md) | Activates scanner to search for nodes (controllers).
    static [void StopScan](./API-Example/StopScan.md) | Deactivate scanner.
    static [void SwapNodes](./API-Example/SwapNodes.md) | Swap nodes (FinchController.Left becomes FinchController.Right)
    static [bool IsConnected](./API-Example/IsConnected.md) | Is certain node connected.
    static [void DisconnectNode](./API-Example/DisconnectNode.md) | Disconnects node (controller).


* #### **<div id="Node" />1.2 FinchNode**  
  **Public abstract class** that provides information about Finch device.

    Function | Description
    --- | --- 
    [NodeType Node](./API-Example/NodeType.md) | Returns node type.
    [Quaternion Rotation](./API-Example/QuaternionRotate.md) | Returns node rotation.
    [Vector3 Position](./API-Example/Vector3Position.md) | Returns node position.
    [void HapticPulse](./API-Example/HapticPulse.md) | Sends command for haptic feedback to the node.
    [bool IsConnected](./API-Example/isConnectedNode.md) | Returns connection state of the node.
    [ushort BatteryCharge](./API-Example/BatteryCharge.md) | Returns battery level.

* #### **<div id="Controller" />1.3 FinchController**  
  **Public abstract class** that provides information about Finch controller.

    Function | Description
    --- | --- 
    static [FinchController Right](./API-Example/FinchControllerRight.md) | Returns right controller instance.
    static [FinchController Left](./API-Example/FinchControllerLeft.md) | Returns left controller instance.
    [FinchController GetController](./API-Example/FControllerGetController.md) | Returns controller instance.

* #### **<div id="Buttons" />1.4 Buttons**  
    
    **Public class** that provides buttons actions. This class is contained by FinchController class.   

    Function | Description
    --- | --- 
    [bool GetPressDown](./API-Example/ExtRStatGetPressDown.md) | Returns true if button was pressed down at this frame.
    [bool GetPress](./API-Example/ExtRStatGetPress.md) | Returns true if button is being pressed. 
    [bool GetPressUp](./API-Example/ExtRStatGetPressUp.md) | Returns true if button was released at this frame. 
    [float GetPressTime](./API-Example/ExtRStatGetPressTime.md) | Returns button pressing time in seconds.

* #### **<div id="Swipe" />1.5 Swipe**  
  
  **Public class** that provides swipe actions. 
  
  Function | Description
  --- | --- 
  [bool SwipeRight](./API-Example/SwipeRight.md) | Returns true, if Touchpad was swiped from left to right.
  [bool SwipeLeft](./API-Example/SwipeLeft.md) | Returns true, if Touchpad was swiped from right to left.
  [bool SwipeTop](./API-Example/SwipeTop.md) | Returns true, if Touchpad was swiped from bottom to top.
  [bool SwipeBottom](./API-Example/SwipeBottom.md) | Returns true, if Touchpad was swiped from from top to bottom.
  [Vector2 TouchAxes](./API-Example/TouchAxes.md) | Returns coordinates of the user's touch. 

## **<div id="Enums" /> 2. Enums**  

* #### **Enums** 

    Enum | Description
    --- | --- 
    [ShiftElement](./API-Example/ShiftElement.md) | Describes available button types of the FinchShift. 
    