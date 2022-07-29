## GetPressDown

Returns true in the form of idnumber (enum integer), if the corresponding Shift's element was pressed down.

* Namespace: `Finch`  

* API: `public static bool GetPressDown(Chirality chirality, ShiftElement element)`  

Example:  
```
void Update()
{
  if (FinchController.Right.Buttons().GetPressDown(ShiftElement.HomeButton))
  {
      Debug.Log("Start pressing home button.");
  }
}
```
