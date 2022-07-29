## GetPressUp

Returns true in the form of idnumber (enum integer), if the corresponding Shift's element is pressed up.

* Namespace: `Finch`  

* API: `public static bool GetPressUp(Chirality chirality, ShiftElement element)`  

Example:  
```
void Update()
{
  if (FinchController.Right.Buttons().GetPressUp(ShiftElement.HomeButton))
  {
      Debug.Log("End pressing home button.");
  }
}
```
