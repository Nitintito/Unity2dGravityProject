using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_2DCamera : MonoBehaviour
{
    [SerializeField] Transform focusTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (focusTarget != null)
        {
            transform.position = focusTarget.transform.position;
        }
    }
}
