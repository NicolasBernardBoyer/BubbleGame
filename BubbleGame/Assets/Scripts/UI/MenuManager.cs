using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    Animator water;

    [SerializeField]
    Animator wavemovement;

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
        water.SetTrigger("");
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
