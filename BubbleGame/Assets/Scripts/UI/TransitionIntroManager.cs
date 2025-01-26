using UnityEngine;

public class TransitionIntroManager : MonoBehaviour
{
    [SerializeField]
    Animator wave;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wave.SetTrigger("GoWave");
        Destroy(gameObject,2);
    }

    
}
