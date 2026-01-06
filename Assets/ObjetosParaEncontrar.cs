using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjetosParaEncontrar : MonoBehaviour
{
    [Header("Som e Feedback")]
    public AudioClip somAoTocar;        // som do objeto
    public AudioClip feedbackAudio;     // feedback tipo "Boa, já tens 1 pista!"
    public float delayFeedback = 4f;    // tempo de espera antes do feedback

    // CONTADOR GLOBAL
    public static int objetosEncontrados = 0;
    public static int totalObjetos = 5; // ⚠️ confirma que tens mesmo 5 objetos

    [Header("UI")]
    public Image iconeNaBarra;          
    public Color encontradoColor = Color.white;
    public bool desaparecerDaBarra = true;

    [Header("Animação")]
    public bool objetoCorreto = false;
    private Animator jogadorAnimator;

    private bool jaEncontrado = false;

    void Start()
    {
        // IMPORTANTE: resetar contador quando a cena começa
        objetosEncontrados = 0;

        // encontra Animator do jogador
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            jogadorAnimator = player.GetComponentInChildren<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (jaEncontrado) return;
        if (!other.CompareTag("Player")) return;

        jaEncontrado = true;

        // CONTA ESTE OBJETO
        objetosEncontrados++;

        // Toca som do objeto PRIMEIRO
        if (somAoTocar != null)
            AudioSource.PlayClipAtPoint(somAoTocar, transform.position);

        // Toca feedback em áudio DEPOIS
        if (feedbackAudio != null)
            Invoke("TocarFeedback", delayFeedback);

        // Dispara animação no jogador
        if (jogadorAnimator != null)
        {
            if (objetoCorreto)
                jogadorAnimator.SetTrigger("Win");
            else
                jogadorAnimator.SetTrigger("Pickup");
        }

        // Atualiza barra de objetos
        if (iconeNaBarra != null)
        {
            if (desaparecerDaBarra)
                iconeNaBarra.gameObject.SetActive(false);
            else
                iconeNaBarra.color = encontradoColor;
        }

        // SE FOR O ÚLTIMO OBJETO → IR PARA SUSPEITOS
        if (objetosEncontrados >= totalObjetos)
        {
            Invoke("IrParaCenaSuspeitos", delayFeedback + 1f);
        }

        // Destrói o objeto
        Destroy(gameObject, delayFeedback + 1f);
    }

    void TocarFeedback()
    {
        if (feedbackAudio != null)
            AudioSource.PlayClipAtPoint(feedbackAudio, transform.position);
    }

    void IrParaCenaSuspeitos()
    {
        SceneManager.LoadScene("suspeitos");
    }
}
