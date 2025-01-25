using UnityEngine;

public class AudioDemo : MonoBehaviour
{
    public void PlaySFX()
    {
        FindFirstObjectByType<AudioManager>().Play("Water");
    }
}
