using UnityEngine;
using static UnityEngine.ParticleSystem;
using UnityEngine.Rendering;
using System.ComponentModel.Design.Serialization;
using UnityEngine.UI;

public class CursorController : MonoBehaviour
{
    public GameObject[] pearls;
    bool holdingPearl = true;
    public GameObject currentPearl;
    public GameObject pearlToUse;
    public GameObject nextIndicator;
    public float placeDelay = 0.0f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentPearl = Instantiate(pearls[0], new Vector3(transform.position.x + Random.Range(-0.01f, 0.01f), transform.position.y, 100.0f), Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360))));
        currentPearl.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        currentPearl.GetComponent<Collider2D>().enabled = false;
        int pearlNum = RandomizePearl();

        pearlToUse = pearls[pearlNum];
        nextIndicator.GetComponent<Image>().sprite = pearls[pearlNum].GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (FindFirstObjectByType<GameManager>().lose == false)
        {
            CountDelay();

            //Get the mouse position, and move the cursor's x position according to the mouse's position
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            Vector3 camPos = Camera.main.ScreenToWorldPoint(mousePos);
            camPos.x = Mathf.Clamp(camPos.x, -2.5f, 2.5f);
            transform.position = new Vector3(camPos.x, transform.position.y, transform.position.z);

            if (holdingPearl)
            {
                currentPearl.transform.position = new Vector3(transform.position.x, transform.position.y, 90.0f);
            }

            //Allow the player to place a pearl only if the delay between placing is over
            if (Input.GetButtonDown("Fire1") && placeDelay <= 0)
            {
                currentPearl.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                currentPearl.GetComponent<Collider2D>().enabled = true;
                //increase move count only if ice is present on the board
                IceCube[] iceCubes = FindObjectsByType<IceCube>(FindObjectsSortMode.None);
                foreach (IceCube cube in iceCubes)
                {
                    cube.movesLeft--;
                }
                holdingPearl = false;
                placeDelay = 1.0f;
            }

            if (placeDelay <= 0 && holdingPearl == false)
            {
                //create a new pearl and reset the timer
                currentPearl = Instantiate(pearlToUse, new Vector3(transform.position.x + Random.Range(-0.01f, 0.01f), transform.position.y, 100), Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360))));
                currentPearl.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                currentPearl.GetComponent<Collider2D>().enabled = false;
                int pearlNum = RandomizePearl();

                pearlToUse = pearls[pearlNum];
                nextIndicator.GetComponent<Image>().sprite = pearlToUse.GetComponent<SpriteRenderer>().sprite;
                holdingPearl = true;
            }
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
        return Random.Range(0, 4);
    }
}
