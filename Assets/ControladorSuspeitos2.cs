using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class ControladorSuspeitosCenario2 : MonoBehaviour
{
    public TextMeshProUGUI textoMensagem;
    public AudioSource audioFonte;

    [Header("Áudios")]
    public AudioClip audioIntroducao;
    public AudioClip audioMariaInocente;
    public AudioClip audioInesInocente;
    public AudioClip audioLeoCulpado;

    [Header("Botões")]
    public Button botaoMaria;
    public Button botaoInes;
    public Button botaoLeo;

    void Start()
    {
        // Desativar botões no início para o jogador ouvir a explicação
        botaoMaria.interactable = false;
        botaoInes.interactable = false;
        botaoLeo.interactable = false;

        // Tocar áudio de introdução (Quem roubou os doces?)
        if (audioIntroducao != null)
        {
            audioFonte.PlayOneShot(audioIntroducao);
            Invoke("AtivarBotoes", audioIntroducao.length);
        }
        else
        {
            AtivarBotoes();
        }
    }

    void AtivarBotoes()
    {
        botaoMaria.interactable = true;
        botaoInes.interactable = true;
        botaoLeo.interactable = true;

        textoMensagem.text = "Quem achas que roubou os doces da Carolina?";
    }

    public void EscolheuMaria()
    {
        audioFonte.Stop(); // Para o áudio anterior se o jogador clicar rápido
        audioFonte.PlayOneShot(audioMariaInocente);
        textoMensagem.text = "A Maria é inocente! Tenta de novo!";
    }

    public void EscolheuInes()
    {
        audioFonte.Stop();
        audioFonte.PlayOneShot(audioInesInocente);
        textoMensagem.text = "A Inês é inocente! Tenta de novo!";
    }

    public void EscolheuLeo()
    {
        audioFonte.Stop();
        audioFonte.PlayOneShot(audioLeoCulpado);
        textoMensagem.text = "Muito bem! O Leo é o verdadeiro culpado";
        
        // Espera 7 segundos (tempo para ouvir o áudio) e muda de cena
        Invoke("IrParaProximoNivel", 9f);
    }

    void IrParaProximoNivel()
    {
        // Garante que o nome da cena está correto no Build Settings
        SceneManager.LoadScene("UltimoNivel"); 
    }
}