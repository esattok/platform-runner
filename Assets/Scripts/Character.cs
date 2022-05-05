using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected CharacterMovementController movementController;
    public bool IsMoving;
    Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        IsMoving = true;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (IsMoving)
        {
            movementController.MoveForward();
        }

        if (transform.position.y < -3f && transform.position.z < 395.91f)
        {
            transform.position = startPosition;
        }
    }

    protected void MovePlayerLeft()
    {
        if (IsMoving)
        {
            movementController.MoveLeft();
        }
    }

    protected void MovePlayerRight()
    {
        if (IsMoving)
        {
            movementController.MoveRight();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Mandatory Obstacle"))
        {
            transform.position = startPosition;
        }
    }
}

