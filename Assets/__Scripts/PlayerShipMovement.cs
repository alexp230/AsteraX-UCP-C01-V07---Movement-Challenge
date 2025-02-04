using UnityEngine;

public class PlayerShipMovement : MonoBehaviour
{
    private float Speed = 400f;
    private Rigidbody _RigidBody;
    public Vector3 MousePosition;


    void Start()
    {
        _RigidBody = this.GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal") ,Input.GetAxis("Vertical"), 0).normalized;
        moveCharacter(movement);


        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z; // Keep the z position the same

        Vector3 direction = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        MousePosition = direction;
    }


    private void moveCharacter(Vector3 direction)
    {
        _RigidBody.velocity = direction * Speed * Time.fixedDeltaTime;
    }
    
}