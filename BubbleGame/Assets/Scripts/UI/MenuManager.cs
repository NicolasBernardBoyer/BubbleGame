using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    public Animator water;

    [SerializeField]
    public Animator wavemovement;

    [SerializeField]
    public Animator board;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FindFirstObjectByType<AudioManager>().Play("BGM");
    }

    public void ApplyPercent(Slider a)
    {
        FindFirstObjectByType<AudioManager>().UpdateVolume(a.value);
    }

    public void PlayButton()
    {
        FindFirstObjectByType<AudioManager>().Play("Water");
        water.SetTrigger("FillScreen");
        wavemovement.SetTrigger("GoWave");
        //Go fruits
        StartCoroutine(TransitionWaiter());
    }

    IEnumerator TransitionWaiter()
    {
        yield return new WaitForSeconds(2.5F);

    }

    public void OptionButton()
    {
        FindFirstObjectByType<AudioManager>().Play("BoardSlide");
        board.SetTrigger("Drop");
    }

    public void CloseButton()
    {
        FindFirstObjectByType<AudioManager>().Play("BoardSlide");
        board.SetTrigger("GoUp");
    }

    public void QuitGame()
    {
        StartCoroutine(ExitAnimation());
    }

    IEnumerator ExitAnimation()
    {
        //Play Outro animation with trigger
        yield return new WaitForSeconds(2f);
        Application.Quit();
    }

    public void MoveToNextScene()
    {
        SceneManager.LoadScene(1);
    }
}
