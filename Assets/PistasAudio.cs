using UnityEngine;

public class PistasAudio : MonoBehaviour
{
    public AudioClip pista1;
    public AudioClip pista2;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void TocarPista1()
    {
        audioSource.clip = pista1;
        audioSource.Play();
    }

    public void TocarPista2()
    {
        audioSource.clip = pista2;
        audioSource.Play();
    }
}

