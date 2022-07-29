## GetPress

Returns true in the form of idnumber (enum integer), if the corresponding Shift's element is currently pressed. 

* Namespace: `Finch`  

* API: `public static bool GetPress(Chirality chirality, ShiftElement element)`   

Example:  
```
void Update()
{
   if (FinchController.Right.Buttons().GetPress(ShiftElement.HomeButton))
  {
      Debug.Log("Pressing home button.");
  }
}
```
