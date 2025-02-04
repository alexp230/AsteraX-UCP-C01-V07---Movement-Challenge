using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerShipMovement : MonoBehaviour
{
    private float Speed = 400f;
    private Rigidbody _RigidBody;


    void Start()
    {
        _RigidBody = this.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"), 0).normalized;
        MoveCharacter(movement);
    }


    private void MoveCharacter(Vector3 direction)
    {
        _RigidBody.velocity = direction * Speed * Time.fixedDeltaTime;
    }

}