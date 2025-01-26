using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int pearlsColliding;
    public GameObject cursor;
    public GameObject iceCube;
    public Canvas UI;
    public float iceDelay = 45.0f;
    public int totalScore = 0;

    [SerializeField] TMPtext scoreText = 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //check for ice timer, create the ice if it is up
        IceTimer();
        if (iceDelay <= 0)
        {
            createIce();
            iceDelay = 45.0f;
        }
    }

    //check for specifically two objects colliding, if so instantiate a new one
    public void CreatePearl(GameObject pearl, Vector3 pos)
    {
        if (pearlsColliding == 2)
        {
            Instantiate(pearl, pos, Quaternion.identity);
            pearlsColliding= 0;
        }
    }

    //spawn ice cubes X times
    private void createIce()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(iceCube, new Vector3(Random.Range(-2.9f, 3.0f),
            cursor.transform.position.y-1, cursor.transform.position.z), Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360))));
        }
    }

    //timer that determines when ice is dropped
    private void IceTimer()
    {
        if (iceDelay > 0)
        {
            iceDelay -= Time.deltaTime;
        }
    }
}
