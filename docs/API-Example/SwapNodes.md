## SwapNodes

* Namespace: `Finch`  

* API: `public static void SwapNodes(NodeType firstNode, NodeType secondNode)` 

Example:  
```
void Start()
{
   //If right controller hold in left hand
   FinchNodeManager.SwapNodes(NodeType.LeftHand, NodeType.RightHand);
}
```
