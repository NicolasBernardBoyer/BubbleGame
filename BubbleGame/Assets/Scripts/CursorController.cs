using UnityEngine;

public class CursorController : MonoBehaviour
{
    public float speed = 0.1f;
    public Camera cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 camPos = Camera.main.ScreenToWorldPoint(mousePos);
        camPos.x = Mathf.Clamp(camPos.x, -2.5f, 2.5f);
        transform.position = new Vector3(camPos.x, transform.position.y, camPos.z);
    }
}
