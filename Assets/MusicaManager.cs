using UnityEngine;

public class MusicaManager : MonoBehaviour
{
    public static MusicaManager instancia;

    public AudioSource musicaFundo;

    [Range(0f, 1f)]
    public float volumeJogo = 0.1f;

    void Awake()
    {
        if (instancia != null)
        {
            Destroy(gameObject);
            return;
        }

        instancia = this;
        DontDestroyOnLoad(gameObject);

        if (musicaFundo != null)
        {
            musicaFundo.loop = true;
            musicaFundo.volume = volumeJogo;
            musicaFundo.Play();
        }
    }

    // mudar volume por código
    public void DefinirVolume(float novoVolume)
    {
        if (musicaFundo != null)
            musicaFundo.volume = novoVolume;
    }
}
