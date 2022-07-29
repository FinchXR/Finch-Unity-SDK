## HapticPulse

Defines controller vibration time in milliseconds. Provides vibration pattern.

* Namespace: `Finch` 

* API: `static void HapticPulse(NodeType node, FinchHapticPattern pattern)`

Example:  
```
void Update()
{
     //Long vibration on left controller
     FinchController.Left.HapticPulse(FinchHapticPattern.LongClick);
}
```
