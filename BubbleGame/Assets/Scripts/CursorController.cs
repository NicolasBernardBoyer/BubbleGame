using UnityEngine;
using static UnityEngine.ParticleSystem;
using UnityEngine.Rendering;

public class CursorController : MonoBehaviour
{
    public GameObject pearl;
    public float placeDelay = 0.0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CountDelay();

        //Get the mouse position, and move the cursor's x position according to the mouse's position
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 camPos = Camera.main.ScreenToWorldPoint(mousePos);
        camPos.x = Mathf.Clamp(camPos.x, -2.5f, 2.5f);
        transform.position = new Vector3(camPos.x, transform.position.y, camPos.z);

        //Allow the player to place a pearl only if the delay between placing is over
        if (Input.GetButtonDown("Fire1") && placeDelay <= 0)
        {
            //create a new pearl and reset the timer
            Instantiate(pearl, new Vector3(transform.position.x + Random.Range(-0.01f,0.01f), transform.position.y, transform.position.z), Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360))));
            placeDelay = 1.0f;
        }
    }

    private void CountDelay()
    {
        if (placeDelay > 0)
        {
            placeDelay -= Time.deltaTime;
        }
    }

    public int RandomizePearl()
    {
        return Random.Range(1, 5);
    }
}
