using System.Collections;
using UnityEngine;

public class IntroNarration : MonoBehaviour
{
    public AudioSource audioSource;        // AudioSource da narração
    public AudioClip introClip;            // Clip da introdução
    public GameObject painelIntroducao;    // Painel que contém texto e botão skip

    [TextArea(4,8)]
    public string introText = "Olá detetive! O João está muito triste… alguém roubou a bola dele no jardim! " +
                              "Precisamos muito da tua ajuda para descobrir quem foi o ladrão. " +
                              "Encontra os 5 objetos escondidos pelo jardim. Eles aparecem na barra lá em baixo. " +
                              "Boa sorte, super detetive!";

    [HideInInspector]
    public bool skipRequested = false;     // Flag para saber se o jogador clicou em skip

    void Start()
    {
        if (audioSource == null)
        {
            Debug.LogError("[IntroNarration] AudioSource não está atribuído!");
            return;
        }
        if (introClip == null)
        {
            Debug.LogError("[IntroNarration] introClip não está atribuído!");
            return;
        }
        if (painelIntroducao != null)
            painelIntroducao.SetActive(true);

        audioSource.clip = introClip;
        audioSource.Play();

        if (DialogueManager.instance != null)
            DialogueManager.instance.ShowDialogue(introText);

        StartCoroutine(WaitUntilAudioEndsThenHide());
    }

    IEnumerator WaitUntilAudioEndsThenHide()
    {
        // Espera até o áudio acabar ou skip ser solicitado
        while (audioSource.isPlaying && !skipRequested)
            yield return null;

        // Para o áudio se ainda estiver a tocar
        if (audioSource.isPlaying)
            audioSource.Stop();

        // Fecha o painel de forma segura
        if (painelIntroducao != null)
            painelIntroducao.SetActive(false);

        skipRequested = false;
    }

    // Método público para ligar ao botão "Skip"
    public void SkipIntroducao()
    {
        skipRequested = true;
    }
}

