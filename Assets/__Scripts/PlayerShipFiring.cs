using UnityEngine;

public class PlayerShipFiring : MonoBehaviour
{
    [SerializeField] private GameObject Bullet_Prefab;
    [SerializeField] private Transform BulletParent;
    private PlayerShipMovement PlayerShipMovement_S;
    

    private const float BULLET_SPEED = 500f;

    void Start()
    {
        PlayerShipMovement_S = this.GetComponent<PlayerShipMovement>();
    }

    void Update()
    {
        // if (Input.GetAxis("Fire1") != 0)
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject bullet = Instantiate(Bullet_Prefab, this.transform.position, Quaternion.identity, BulletParent);
            bullet.GetComponent<Rigidbody>().AddForce(PlayerShipMovement_S.MousePosition * BULLET_SPEED);            
        }
    }
}
