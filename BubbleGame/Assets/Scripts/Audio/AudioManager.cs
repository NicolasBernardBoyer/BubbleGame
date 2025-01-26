using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public float percentage = 1f;
    public static AudioManager instance;

    string[] popsfx = { "Pop1", "Pop2", "Pop3", "Pop4" };
    void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.volume = s.volume*percentage;
            s.source.clip = s.clip;
            s.source.loop = s.loop;
        }
    }

    public void PlayBomba()
    {
        Play("Bomba");
    }

    public void PlayPop()
    {
        int temp = Random.Range(0, 4);
        Play(popsfx[temp]);
    }

    public void Play(string name)
    {
        foreach (Sound s in sounds)
        {
            if (s.name==name)
            {
                s.source.Play();
                return;
            }
        }

        Debug.Log("No such audio clip found");
    }
    
    public void UpdateVolume(float currentpercentage)
    {
        if (currentpercentage != percentage)
        {
            percentage = currentpercentage;
            foreach (Sound s in sounds)
            {
                s.source.volume = s.volume * percentage;
            }
        }
    }
}
