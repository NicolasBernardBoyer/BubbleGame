using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int pearlsColliding;
    public GameObject cursor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreatePearl(GameObject pearl, Vector3 pos)
    {
        if (pearlsColliding == 2)
        {
            Instantiate(pearl, pos, Quaternion.identity);
            pearlsColliding= 0;
        }
    }
}
