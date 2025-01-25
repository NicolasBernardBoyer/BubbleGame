using UnityEngine;

public class Pearl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject next;
    public bool isColliding = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (CompareTag(collision.gameObject.tag) && isColliding == false){
            Destroy(collision.gameObject);
            if (next != null)
            {
                FindFirstObjectByType<GameManager>().pearlsColliding += 1;
                FindFirstObjectByType<GameManager>().CreatePearl(next, transform.position);
            }
            isColliding = true;
            Destroy(gameObject);
        }
    }
}
