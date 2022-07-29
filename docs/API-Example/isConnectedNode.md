## isConnected

Checking that the FinchShift is connected.

* Namespace: `Finch` 

* API: `public static bool IsConnected(NodeType node)`

Example:  
```
void Update()
{
     bool isNodeConnect = FinchController.Left.IsConnected;

     Debug.Log("Left controller connection state: "+ isNodeConnect);
}
```
