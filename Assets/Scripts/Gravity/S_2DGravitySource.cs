using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_2DGravitySource : MonoBehaviour
{
    // This script  add sources of gravity to the list in "CustomGravity".
    // All objects that are supose to affect gravity will inherit this script and overide GetGravity.

    public virtual Vector2 GetGravity(Vector2 position) //Gets gravity logic. Gravity shapes override this method.
    {
        return Physics2D.gravity;
    }
    void OnEnable() //Adds the gravity shape to the list in CustomGravity when enabled.
    {
        S_2DCustomGravity.Register(this);
    }
    private void OnDisable() //Removes the gravity shape from the list in CustomGravity when disabled.
    {
        S_2DCustomGravity.Unregister(this);
    }
}
