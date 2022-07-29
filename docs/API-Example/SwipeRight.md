## SwipeRight

Returns true if user has swiped from left to right.

* Namespace: `Finch`  

* API: `public bool SwipeRight`  

Example:  
```
void Update()
{
   if (FinchController.Right.Swipes().SwipeRight)
   {
         Debug.Log("From left to right.");
   }
}
```
