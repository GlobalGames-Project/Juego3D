using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject heart1, heart2, heart3, gameOver;
    public static int health;
    public int whereToRespawn;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);



    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }

        if (health > 3)
            health = 3;

        switch (health)
        {
            case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                break;
            case 2:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                break;
            case 1:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;
            case 0:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                gameOver.gameObject.SetActive(true);

                health = 0;

                if (Input.GetKey(KeyCode.R))
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene(whereToRespawn);
                    //Devolver sonido
                }
                break;

            default:
                if (Input.GetKey(KeyCode.R))
                {
                    SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
                    // UnityEngine.SceneManagement.SceneManager.LoadScene(whereToRespawn);
                    //Devolver sonido
                }
                break;



        }


    }

}
