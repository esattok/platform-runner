using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatformRotation : MonoBehaviour
{
    [SerializeField] float speed = 30f;
    [SerializeField] Vector3 rotateDirection = new Vector3(0, 0, 1);
    [SerializeField] Vector3 forceVector = new Vector3(1, 0, 0);
    HashSet<CharacterMovementController> movementControllers = new HashSet<CharacterMovementController>();


    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, rotateDirection, Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        var movementController = collision.gameObject.GetComponent<CharacterMovementController>();
        if (movementController != null)
        {
            movementControllers.Add(movementController);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        var movementController = collision.gameObject.GetComponent<CharacterMovementController>();
        if (movementController != null)
        {
            if (movementControllers.Contains(movementController))
            {
                movementControllers.Remove(movementController);
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        foreach (var movementController in movementControllers)
        {
            movementController.Move(forceVector * Time.deltaTime);
        }
    }
}
