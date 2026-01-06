using System.Collections;
using UnityEngine;
using TMPro; // se estiveres a usar TextMeshPro
// using UnityEngine.UI; // descomenta se estiveres a usar o Text normal em vez de TMP

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    [Header("UI")]
    public CanvasGroup dialogueGroup;         // CanvasGroup do DialogueBox (para controlar alpha)
    public TextMeshProUGUI dialogueText;      // Texto (TextMeshPro). Se não usares TMP, troca para UnityEngine.UI.Text

    [Header("Fade settings")]
    public float fadeSpeed = 2f;              // velocidade do fade (maior = mais rápido)

    private Coroutine currentFade;

    private void Awake()
    {
        // Singleton simples
        if (instance == null) instance = this;
        else Destroy(gameObject);

        // Garantir estado inicial
        if (dialogueGroup != null)
        {
            dialogueGroup.alpha = 0f;
            dialogueGroup.interactable = false;
            dialogueGroup.blocksRaycasts = false;
        }
    }

    // Mostra a caixa com o texto (fade in)
    public void ShowDialogue(string text)
    {
        if (dialogueText != null) dialogueText.text = text;
        if (currentFade != null) StopCoroutine(currentFade);
        currentFade = StartCoroutine(FadeIn());
    }

    // Esconde a caixa (fade out)
    public void HideDialogue()
    {
        if (currentFade != null) StopCoroutine(currentFade);
        currentFade = StartCoroutine(FadeOut());
    }

    IEnumerator FadeIn()
    {
        if (dialogueGroup == null) yield break;

        // tornar interactable apenas depois do fade terminar
        float t = dialogueGroup.alpha;
        while (t < 1f)
        {
            t += Time.deltaTime * fadeSpeed;
            dialogueGroup.alpha = Mathf.Clamp01(t);
            yield return null;
        }
        dialogueGroup.interactable = true;
        dialogueGroup.blocksRaycasts = true;
        currentFade = null;
    }

    IEnumerator FadeOut()
    {
        if (dialogueGroup == null) yield break;

        dialogueGroup.interactable = false;
        dialogueGroup.blocksRaycasts = false;

        float t = dialogueGroup.alpha;
        while (t > 0f)
        {
            t -= Time.deltaTime * fadeSpeed;
            dialogueGroup.alpha = Mathf.Clamp01(t);
            yield return null;
        }
        currentFade = null;
    }
}
