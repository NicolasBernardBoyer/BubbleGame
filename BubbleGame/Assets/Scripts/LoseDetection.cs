using UnityEngine;

public class LoseDetection : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ice" || collision.tag == "evo1" || collision.tag == "evo2" || collision.tag == "evo3"
            || collision.tag == "evo4" || collision.tag == "evo5" || collision.tag == "evo6" || collision.tag == "evo7"
            || collision.tag == "evo8" || collision.tag == "evo9" || collision.tag == "evo10")
        {
            FindFirstObjectByType<GameManager>().lose = true;
        }
    }
}
