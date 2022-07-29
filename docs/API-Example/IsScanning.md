## IsScanning

* Namespace: `Finch`  

* API: `public static bool IsScanning` 

Example:  
```
void Update()
{
    bool isScanning = FinchNodeManager.IsScanning;
    
    if (isScanning)
    {
        Debug.Log("Scanner scanning right now");
    }
}
```
