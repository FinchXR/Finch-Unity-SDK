## FControllerGetController

Returns controller instance according to its chirality.

* Namespace: `Finch`  

* API: `public static ControllerType ControllerType`  

Example:  
```
void Update()
{
   //Get right controller instance
   FinchController controller = FinchController.GetController(Chirality.Right);
   Debug.Log(controller.IsConnected);
}
```
