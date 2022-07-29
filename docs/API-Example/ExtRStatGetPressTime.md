## GetPressTime

For the certain press action returns time in milliseconds of how long certain controller's element was pressed.

* Namespace: `Finch`  

* API: `public static float GetPressTime(Chirality chirality, ShiftElement element)`   

Example:  
```
void Update()
{
  if (FinchController.Right.Buttons().GetPressTime(ShiftElement.HomeButton) > 0.5f)
  {
      Debug.Log("Button presse more then 0.5 sec");
  }
}
