## SwipeBottom

Returns true if user has swiped from top to bottom.

* Namespace: `Finch`  

* API: `public bool SwipeBottom`  

Example:  
```
void Update()
{
   if (FinchController.Right.Swipes().SwipeBottom)
   {
      Debug.Log("From up to down.");
   }
}
```
