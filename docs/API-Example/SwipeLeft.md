## SwipeLeft

Returns true if user has swiped from right to left.

* Namespace: `Finch`  

* API: `public bool SwipeLeft`  

Example:  
```
void Update()
{
   if (FinchController.Right.Swipes().SwipeLeft)
   {
         Debug.Log("From left to right.");
   }
}
```
