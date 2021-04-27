using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject canvasOcultar;
    public GameObject canvasMostrar;
    float tiempo = 0;
    bool start = false;
    string nombreNivel;

    private void Update()
    {
        if (start)
        {
            tiempo += Time.deltaTime;
        }

        if (tiempo > 10)
        {
            SceneManager.LoadScene(nombreNivel);
        }
    }
    public void cargarNivel(string pnombreNivel)
    {
        canvasOcultar.SetActive(false);
        canvasMostrar.SetActive(true);
        start = true;
        nombreNivel = pnombreNivel;
    }

    public void cerrarJuego()
    {
        Application.Quit();
    }

}
