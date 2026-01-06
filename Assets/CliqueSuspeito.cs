using UnityEngine;

public class CliqueSuspeito : MonoBehaviour
{
    public ControladorSuspeitos controlador;
    public string nomeSuspeito;

    void OnMouseDown()
    {
        if (nomeSuspeito == "Jose")
            controlador.EscolheuJose();

        if (nomeSuspeito == "Lucas")
            controlador.EscolheuLucas();

        if (nomeSuspeito == "Ivo")
            controlador.EscolheuIvo();
    }
}
