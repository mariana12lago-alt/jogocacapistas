using UnityEngine;

public class GestorPistasNivel3 : MonoBehaviour
{
    public AudioClip pista1;
    public AudioClip pista2;
    public AudioClip pista3;
    public AudioClip pista4;
    public AudioClip pista5;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void TocarPista1()
    {
        TocarPista(pista1);
    }

    public void TocarPista2()
    {
        TocarPista(pista2);
    }

    public void TocarPista3()
    {
        TocarPista(pista3);
    }

    public void TocarPista4()
    {
        TocarPista(pista4);
    }

    public void TocarPista5()
    {
        TocarPista(pista5);
    }

    void TocarPista(AudioClip clip)
    {
        if (clip == null || audioSource == null) return;

        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }
}

