using UnityEngine;
using UnityEngine.UI;

public class IntroducaoComSkip : MonoBehaviour
{
    public GameObject painelIntroducao;   // Painel da introdução
    public AudioSource audioIntroducao;   // Áudio da introdução
    public Button botaoIgnorar;           // Botão "Ignorar introdução"
    public void AvancarIntroducao()
{
    Debug.Log("BOTÃO FUNCIONOU");
}


    void Start()
    {
        if (painelIntroducao != null)
            painelIntroducao.SetActive(true);

        if (audioIntroducao != null)
            audioIntroducao.Play();

        if (botaoIgnorar != null)
            botaoIgnorar.onClick.AddListener(SkipIntroducao);
    }

    // Método chamado pelo botão
    public void SkipIntroducao()
    {
        if (audioIntroducao != null && audioIntroducao.isPlaying)
            audioIntroducao.Stop();

        if (painelIntroducao != null)
            painelIntroducao.SetActive(false);

        Debug.Log("Introdução ignorada e áudio parado!");
    }
}

