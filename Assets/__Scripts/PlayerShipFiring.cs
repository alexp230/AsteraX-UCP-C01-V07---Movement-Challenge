using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerShipFiring : MonoBehaviour
{
    [SerializeField] private GameObject Bullet_Prefab;
    [SerializeField] private Transform BulletParent;
    private TurretRotation TurretRotation_S;
    
    private const float BULLET_SPEED = 500f;

    void Start()
    {
        TurretRotation_S = this.GetComponentInChildren<TurretRotation>();
    }

    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
            SpawnAndFireBullet();
    }

    private void SpawnAndFireBullet()
    {
        GameObject bullet = Instantiate(Bullet_Prefab, this.transform.position, Quaternion.identity, BulletParent);
        bullet.GetComponent<Rigidbody>().AddForce(TurretRotation_S.MouseDirection * BULLET_SPEED);  
    }
}
