using UnityEngine;
using static UnityEngine.ParticleSystem;
using UnityEngine.Rendering;

public class CursorController : MonoBehaviour
{
    public GameObject pearl;


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

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(pearl, new Vector3(transform.position.x + Random.Range(-0.01f,0.01f), transform.position.y, transform.position.z), Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360))));
        }
    }
}
