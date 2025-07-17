using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int pearlsColliding;
    public GameObject cursor;
    public GameObject iceCube;
    public GameObject loseScreen;
    public GameObject winScreen;
    public float iceDelay = 45.0f;
    public int totalScore = 0;

    public bool lose = false;

    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text timerText;
    [SerializeField] int scoreToWin;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lose = false;
        loseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //check for ice timer, create the ice if it is up
        if (!lose)
        {
            IceTimer();
            WinCondition();
        } else
        {
            loseScreen.SetActive(true);
        }
        if (iceDelay <= 0)
        {
            createIce();
            iceDelay = 45.0f;
        }
        timerText.text = iceDelay.ToString("F0");
        scoreText.text = totalScore.ToString();
    }

    public void WinCondition()
    {
        if (totalScore >= scoreToWin)
        {
            winScreen.SetActive(true);
        }
    }

    //check for specifically two objects colliding, if so instantiate a new one
    public void CreatePearl(GameObject pearl, Vector3 pos)
    {
        if (pearlsColliding == 2)
        {
            if (FindFirstObjectByType<AudioManager>() != null)
            {
                FindFirstObjectByType<AudioManager>().PlayPop();
            }
            Instantiate(pearl, pos, Quaternion.identity);
            pearlsColliding = 0;
        }
    }

    //spawn ice cubes X times
    private void createIce()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(iceCube, new Vector3(Random.Range(-2.9f, 3.0f),
            cursor.transform.position.y-2.0f, 90.0f), Quaternion.Euler(new Vector3(0, 0, Random.Range(0, 360))));
        }
    }

    //timer that determines when ice is dropped
    private void IceTimer()
    {
        if (iceDelay > 0)
        {
            iceDelay -= Time.deltaTime;
        }
    }
    public void Bomba()
    {
        if (FindFirstObjectByType<AudioManager>() != null)
        {
            FindFirstObjectByType<AudioManager>().PlayBomba();
        }
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
