using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class ControladorSuspeitosCenario3 : MonoBehaviour
{
    public TextMeshProUGUI textoMensagem;
    public AudioSource audioFonte;

    [Header("Áudios")]
    public AudioClip audioIntroducao;
    public AudioClip audioSaraInocente;
    public AudioClip audioAnaInocente;
    public AudioClip audioVeraCulpada;

    [Header("Botões")]
    public Button botaoSara;
    public Button botaoAna;
    public Button botaoVera;

    void Start()
    {
        // Desativar botões no início para o jogador ouvir a explicação
        botaoSara.interactable = false;
        botaoAna.interactable = false;
        botaoVera.interactable = false;

        // Tocar áudio de introdução
        if (audioIntroducao != null)
        {
            audioFonte.PlayOneShot(audioIntroducao);
            Invoke(nameof(AtivarBotoes), audioIntroducao.length);
        }
        else
        {
            AtivarBotoes();
        }
    }

    void AtivarBotoes()
    {
        botaoSara.interactable = true;
        botaoAna.interactable = true;
        botaoVera.interactable = true;

        textoMensagem.text = "Quem roubou o livro?";
    }

    public void EscolheuSara()
    {
        audioFonte.Stop();
        audioFonte.PlayOneShot(audioSaraInocente);
        textoMensagem.text = "A Sara é inocente! Tenta de novo!";
    }

    public void EscolheuAna()
    {
        audioFonte.Stop();
        audioFonte.PlayOneShot(audioAnaInocente);
        textoMensagem.text = "A Ana é inocente! Tenta de novo!";
    }

    public void EscolheuVera()
    {
        audioFonte.Stop();
        audioFonte.PlayOneShot(audioVeraCulpada);
        textoMensagem.text = "Muito bem! A Vera é a verdadeira culpada";

        // Espera o áudio acabar antes de mudar de cena
        Invoke(nameof(IrParaProximoNivel), audioVeraCulpada.length);
    }

    void IrParaProximoNivel()
    {
        SceneManager.LoadScene("diplomafinal");
    }
}
