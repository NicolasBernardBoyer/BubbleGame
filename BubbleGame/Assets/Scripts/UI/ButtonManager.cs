using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    string[] popsfx = { "Pop1", "Pop2", "Pop3", "Pop4" };

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void buttonclick()
    {
        int temp = Random.Range(0, 4);
        AudioManager tempAM = FindFirstObjectByType<AudioManager>();
        tempAM.Play(popsfx[temp]);
    }
}
