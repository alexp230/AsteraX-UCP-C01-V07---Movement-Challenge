using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    private Vector3 ScreenBounds;
    private float ObjectWidth;
    private float ObjectHeight;

    void Start()
    {
        // Get screen bounds in world coordinates
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, this.transform.position.z));

        // Calculate object size based on its renderer
        Renderer objRenderer = this.GetComponent<Renderer>();
        if (objRenderer != null)
        {
            ObjectWidth = objRenderer.bounds.extents.x; // Half-width
            ObjectHeight = objRenderer.bounds.extents.y; // Half-height
        }
    }

    void Update()
    {
        Vector3 newPos = this.transform.position;

        // Wrap horizontally (X-axis)
        if (this.transform.position.x > (ScreenBounds.x + ObjectWidth))
            newPos.x = -ScreenBounds.x - ObjectWidth;
        else if (this.transform.position.x < (-ScreenBounds.x - ObjectWidth))
            newPos.x = ScreenBounds.x + ObjectWidth;

        // Wrap vertically (Y-axis)
        if (this.transform.position.y > (ScreenBounds.y + ObjectHeight))
            newPos.y = -ScreenBounds.y - ObjectHeight;
        else if (this.transform.position.y < (-ScreenBounds.y - ObjectHeight))
            newPos.y = ScreenBounds.y + ObjectHeight;

        this.transform.position = newPos;
    }

}
