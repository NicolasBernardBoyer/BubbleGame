using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FindFirstObjectByType<AudioManager>().Play("BGM");
    }

    public void ApplyPercent(Slider a)
    {
        FindFirstObjectByType<AudioManager>().UpdateVolume(a.value);
    }

    public void PlaySFX()
    {
        FindFirstObjectByType<AudioManager>().Play("Water");
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
