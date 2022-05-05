using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementController : MonoBehaviour
{
    [SerializeField] Transform character;
    [SerializeField] Rigidbody characterRB;
    [SerializeField] float verticalMovementSpeed = 1;
    [SerializeField] float horizontalMovementSpeed = 1;


    public void MoveForward()
    {
        Move(character.forward * verticalMovementSpeed);
    }

    public void MoveRight()
    {
        Move(character.right * horizontalMovementSpeed);
    }

    public void MoveLeft()
    {
        Move(character.right * horizontalMovementSpeed * -1);
    }


    public void Move(Vector3 moveVector)
    {
        character.position += moveVector * Time.deltaTime;
    }

    public void MoveWithForce(Vector3 moveVector)
    {
        characterRB.AddForce(moveVector);
    }




}
