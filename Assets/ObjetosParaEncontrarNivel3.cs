using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjetosParaEncontrarNivel3 : MonoBehaviour
{
    [Header("Som e Feedback")]
    public AudioClip somAoTocar;        
    public AudioClip feedbackAudio;     
    public float delayFeedback = 4f;    

    // CONTADOR GLOBAL
    public static int objetosEncontrados = 0;
    public static int totalObjetos = 6;

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
        objetosEncontrados = 0;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            jogadorAnimator = player.GetComponentInChildren<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (jaEncontrado) return;
        if (!other.CompareTag("Player")) return;

        jaEncontrado = true;
        objetosEncontrados++;

        if (somAoTocar != null)
            AudioSource.PlayClipAtPoint(somAoTocar, transform.position);

        if (feedbackAudio != null)
            Invoke("TocarFeedback", delayFeedback);

        if (jogadorAnimator != null)
        {
            if (objetoCorreto)
                jogadorAnimator.SetTrigger("Win");
            else
                jogadorAnimator.SetTrigger("Pickup");
        }

        if (iconeNaBarra != null)
        {
            if (desaparecerDaBarra)
                iconeNaBarra.gameObject.SetActive(false);
            else
                iconeNaBarra.color = encontradoColor;
        }

        if (objetosEncontrados >= totalObjetos)
        {
            Invoke("IrParaCenaSuspeitos", delayFeedback + 1f); // ✅ Agora está igual
        }

        Destroy(gameObject, delayFeedback + 1f);
    }

    void TocarFeedback()
    {
        if (feedbackAudio != null)
            AudioSource.PlayClipAtPoint(feedbackAudio, transform.position);
    }

    void IrParaCenaSuspeitos() // ✅ Nome correto
    {
        SceneManager.LoadScene("suspeitos3");
    }
}
