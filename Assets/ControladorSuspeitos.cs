using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class ControladorSuspeitos : MonoBehaviour
{
    public TextMeshProUGUI textoMensagem;

    public AudioSource audioFonte;

    public AudioClip audioIntroducao;
    public AudioClip audioJoseInocente;
    public AudioClip audioLucasInocente;
    public AudioClip audioCulpado;

    public Button botaoJose;
    public Button botaoLucas;
    public Button botaoIvo;

    void Start()
    {
        // Desativar botões no início
        botaoJose.interactable = false;
        botaoLucas.interactable = false;
        botaoIvo.interactable = false;

        // Tocar áudio de introdução
        audioFonte.PlayOneShot(audioIntroducao);

        // Ativar botões depois do áudio acabar
        Invoke("AtivarBotoes", audioIntroducao.length);
    }

    void AtivarBotoes()
    {
        botaoJose.interactable = true;
        botaoLucas.interactable = true;
        botaoIvo.interactable = true;

        textoMensagem.text = "Quem achas que é o culpado?";
    }

    public void EscolheuJose()
    {
        audioFonte.PlayOneShot(audioJoseInocente);
        textoMensagem.text = "O polícia José é inocente! Tenta de novo!";
    }

    public void EscolheuLucas()
    {
        audioFonte.PlayOneShot(audioLucasInocente);
        textoMensagem.text = "O médico Lucas é inocente! Tenta de novo!";
    }

    public void EscolheuIvo()
    {
        audioFonte.PlayOneShot(audioCulpado);
        textoMensagem.text = "Muito bem! Encontraste o culpado!";
        Invoke("IrParaProximoNivel", 7f);
    }

    void IrParaProximoNivel()
    {
        SceneManager.LoadScene("Nível2");
    }
}
