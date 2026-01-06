using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void IniciarJogo()
    {
        SceneManager.LoadScene("CenarioJogo");
    }

    public void SairJogo()
    {
        Application.Quit();
    }
}