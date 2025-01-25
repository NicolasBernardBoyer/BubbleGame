using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    Animator buttonAnimator;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        buttonAnimator = GetComponent<Animator>();
    }

    public void buttonclick()
    {
        buttonAnimator.SetTrigger("Click");
    }
}
