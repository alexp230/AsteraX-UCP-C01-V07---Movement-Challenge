using UnityEngine;

public class TurretRotation : MonoBehaviour
{
    public Vector3 MouseDirection;

    void Update()
    {
        RotateTurret();
    }

    private void RotateTurret()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.back * Camera.main.transform.position.z); 
        this.transform.LookAt(mousePosition, Vector3.back);

        MouseDirection = (mousePosition - this.transform.position).normalized;
    }
}
