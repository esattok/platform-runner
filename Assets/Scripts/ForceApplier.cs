using UnityEngine;

public class ForceApplier : MonoBehaviour
{
    [SerializeField] float force = 40f;

    private void OnCollisionEnter(Collision collision)
    {
        var movementController = collision.gameObject.GetComponent<CharacterMovementController>();
        if (movementController != null)
        {
            var diff = movementController.transform.position - collision.GetContact(0).point;
            diff.y = 0;
            var forceVector = diff.normalized * force;

            movementController.MoveWithForce(forceVector * Time.deltaTime * 1000);

        }
    }
}
