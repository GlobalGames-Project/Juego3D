using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{

    public static float tiempo = 0.0f; // Tiempo real que transcurre
    private float valHora = 60f; // Valor de lo que es 1h en el juego
    public int horario = 0; // En que horario se encuentra, 0 es el principio y segun cuanto este dividido el dia X es el final
    // Start is called before the first frame update
    public string nextScene;
    public Light dayLight;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempo += 1 * Time.deltaTime;
        if (tiempo>= valHora*0.1f && horario==0)
        {
            horario++;
            EventGenerator.current.MamaTimeEnter();
        }
        
        if(tiempo > valHora * 2.7)
        {
            dayLight.intensity = 0.2f;
        }
        if(tiempo > valHora * 3)
        {
            SceneManager.LoadScene(nextScene);
        }
    }

    
}
