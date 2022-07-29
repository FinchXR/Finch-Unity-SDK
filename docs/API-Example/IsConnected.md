## IsConnected

* Namespace: `Finch` 

* API: `public static bool IsConnected(NodeType node)` 

Example:  
```
void Update()
{
     bool isNodeConnect = FinchNodeManager.IsConnected(NodeType.RightHand);
     Debug.Log("Node connection state: "+ isNodeConnect);
}
```
