using UnityEngine;

public class Pearl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject next;
    public bool isColliding = false;
    public int pointsWorth;
    int direction = 0;
    float speed = 2.0f;
    bool hasDropped = false;

    void Start()
    {
        direction = Random.Range(0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        //rotate the object once its fallen
        if (direction == 0 && hasDropped)
        {
            transform.Rotate(0, 0, 6.0f * speed * Time.deltaTime);
        } else if (direction == 1 && hasDropped)
        {
            transform.Rotate(0, 0, -6.0f * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hasDropped = true;
        if (CompareTag(collision.gameObject.tag) && isColliding == false && GetComponent<Rigidbody2D>().bodyType != RigidbodyType2D.Kinematic)
        {
            if (next != null)
            {
                FindFirstObjectByType<GameManager>().pearlsColliding += 1;
                FindFirstObjectByType<GameManager>().CreatePearl(next, (transform.position + collision.transform.position)/2);
            } else
            {
                FindFirstObjectByType<GameManager>().Bomba();
            }
            isColliding = true;
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
    private void OnDestroy()
    {
        if (FindFirstObjectByType<GameManager>() != null)
        {
            FindFirstObjectByType<GameManager>().totalScore += pointsWorth;
        }

    }
}
