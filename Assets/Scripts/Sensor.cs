using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    
    public Transform CheckObject(float radius, LayerMask layer)
    {
        var center = transform.position + transform.forward * radius;
        var colliders = Physics.OverlapSphere(center, radius, layer);

        return colliders.Length>0?colliders[0].transform:null;
    }
}
