## SwipeTop

Returns true if user has swiped from bottom to top.

* Namespace: `Finch`  

* API: `public bool SwipeTop`  

Example:  
```
void Update()
{
   if (FinchController.Right.Swipes().SwipeTop)
   {
         Debug.Log("From down to up.");
   }
}
```
