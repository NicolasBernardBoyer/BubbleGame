using UnityEngine;

public class IceCube : MonoBehaviour
{
    public int movesLeft = 10;

    // Update is called once per frame
    void Update()
    {
        if (movesLeft == 0)
        {
            Destroy(gameObject);
        }
    }
}
