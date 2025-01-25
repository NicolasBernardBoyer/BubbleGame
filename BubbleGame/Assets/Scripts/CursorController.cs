using UnityEngine;

public class CursorController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Mouse X") < 0)
        {
            Debug.Log("Mouse moved left");
        } else if (Input.GetAxis("Mouse X") > 0)
        {
            Debug.Log("Mouse moved right");
        }
    }
}
