using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class S_TransformExtension
{
    public static Vector2 AsVector2(this Vector3 v)
    {
        return new Vector2(v.x, v.y);
    }
}
