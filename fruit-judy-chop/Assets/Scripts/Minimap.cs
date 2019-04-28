using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform blade;
    
    void LateUpdate()
    {
        Vector3 newpos = blade.position;
        newpos.z = transform.position.z;
        transform.position = newpos;
    }
}
