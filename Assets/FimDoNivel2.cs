using UnityEngine;
using UnityEngine.SceneManagement;

public class FimDoNivel2 : MonoBehaviour
{
    public GameObject botaoContinuar;
    public string nomeDaCenaSuspeitos = "suspeitos2"; // Define aqui a cena correta

    public void MostrarBotao()
    {
        botaoContinuar.SetActive(true);
    }

    public void IrParaSuspeitos()
    {
        SceneManager.LoadScene(nomeDaCenaSuspeitos);
    }
}