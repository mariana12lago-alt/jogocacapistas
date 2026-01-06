using UnityEngine;
using UnityEngine.SceneManagement;

public class FimDoNivel : MonoBehaviour
{
    public GameObject botaoContinuar;

    public void MostrarBotao()
    {
        botaoContinuar.SetActive(true);
    }

    public void IrParaSuspeitos()
    {
        SceneManager.LoadScene("suspeitos");
    }
}
