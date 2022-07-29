## StartScan

* Namespace: `Finch`  

* API: `public static bool StartScan(FinchCore.Finch_ScannerType type)` 

Example:  
```
void Update()
{
    // Start scanner to connect nodes.
    bool isScannerStartSuccesfully = FinchNodeManager.StartScan(Internal.FinchCore.Finch_ScannerType.Advertising);

    if (isScannerStartSuccesfully)
    {
        Debug.Log("Scanner started successfully");
    }
}
```
