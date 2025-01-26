using UnityEngine;

public class IceCube : MonoBehaviour
{
    public int movesLeft = 4;

    // Update is called once per frame
    void Update()
    {
        if (movesLeft == 0)
        {
            Destroy(gameObject);
        }
    }
}
