using UnityEngine;

public class InterludioSuspeitos : MonoBehaviour
{
    [Header("UI e Áudio")]
    public GameObject painelMensagem;       // Painel com a mensagem escrita
    public UnityEngine.UI.Button botaoContinuar; // Botão para avançar
    public AudioClip audioMensagem;         // Áudio da mensagem

    [Header("Suspeitos")]
    public GameObject[] suspeitos;          // Suspeitos a aparecer depois

    private AudioSource audioSource;

    void Start()
    {
        // Cria AudioSource automaticamente
        audioSource = gameObject.AddComponent<AudioSource>();

        // Mostra painel e esconde suspeitos
        painelMensagem.SetActive(true);
        foreach(var s in suspeitos)
            s.SetActive(false);

        // Toca áudio
        if(audioMensagem != null)
            audioSource.PlayOneShot(audioMensagem);

        // Configura botão
        if(botaoContinuar != null)
            botaoContinuar.onClick.AddListener(Continuar);
    }

    public void Continuar()
    {
        // Esconde painel
        painelMensagem.SetActive(false);

        // Mostra suspeitos
        foreach(var s in suspeitos)
            s.SetActive(true);
    }
}
