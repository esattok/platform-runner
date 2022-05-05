using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : Character
{
    [SerializeField] Sensor sensor;
    [SerializeField] LayerMask obstacleLayer;
    [SerializeField] float visualDistance;
    [SerializeField] GameObject model;
    

    protected override void Update()
    {
        base.Update();

        Transform obstacle = sensor.CheckObject(visualDistance, obstacleLayer);
        

        if (!obstacle) return;

        var direction = transform.position.x - obstacle.position.x;
        
        if (direction < 0)
            MovePlayerLeft();
        else
            MovePlayerRight();
    }

    public void DisableCharacter()
    {
        GetComponent<Collider>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        model.SetActive(false);
        enabled = false;
    }
}

