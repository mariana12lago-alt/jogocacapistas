using UnityEngine;

public class AvancarIntro : MonoBehaviour
{
    [Header("Objetos da Introdução")]
    public GameObject painelIntro; // Painel/Canvas com UI da intro
    public AudioSource audioNarracao; // Áudio da tua narração
    public GameObject dialogueBox; // O DialogueBox que dá erro
    
    [Header("Objetos do Jogo")]
    public GameObject painelJogo; // Painel/elementos do jogo
    public GameObject jogador; // Player (opcional)
    
    void Start()
    {
        // Garante que a intro e dialogueBox estão ativos no início
        if (painelIntro != null)
            painelIntro.SetActive(true);
        
        // IMPORTANTE: Ativa o DialogueBox para a coroutine funcionar
        if (dialogueBox != null)
            dialogueBox.SetActive(true);
            
        if (painelJogo != null)
            painelJogo.SetActive(false);
            
        if (jogador != null)
            jogador.SetActive(false);
    }
    
    // Método para o botão chamar
    public void PularIntroducao()
    {
        // Para o áudio se estiver a tocar
        if (audioNarracao != null && audioNarracao.isPlaying)
        {
            audioNarracao.Stop();
        }
        
        // Para todas as coroutines do DialogueManager
        DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();
        if (dialogueManager != null)
        {
            dialogueManager.StopAllCoroutines();
        }
        
        // Desativa a introdução
        if (painelIntro != null)
        {
            painelIntro.SetActive(false);
        }
        
        // Desativa o DialogueBox
        if (dialogueBox != null)
        {
            dialogueBox.SetActive(false);
        }
        
        // Ativa o jogo
        if (painelJogo != null)
        {
            painelJogo.SetActive(true);
        }
        
        if (jogador != null)
        {
            jogador.SetActive(true);
        }
        
        // Desbloqueia o cursor e movimento (se necessário)
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
