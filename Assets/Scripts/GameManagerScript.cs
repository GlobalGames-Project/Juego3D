using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject heart1, heart2, heart3, gameOver, blackScreen, momAwaken, ending1Text, ending2Text, ending3Text;
    public static int health, momSpawned, ending1, ending2, ending3;
    public int whereToRespawn;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;

        momSpawned = 0;
        ending1 = 0;
        ending2 = 0;
        ending3 = 0;

        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);
        blackScreen.gameObject.SetActive(false);
        momAwaken.gameObject.SetActive(false);
        ending1Text.gameObject.SetActive(false);
        ending2Text.gameObject.SetActive(false);
        ending3Text.gameObject.SetActive(false);


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
                blackScreen.gameObject.SetActive(true);
                Time.timeScale = 0;

                health = 0;

                if (Input.GetKey(KeyCode.R))
                {
                    Time.timeScale = 1;
                    UnityEngine.SceneManagement.SceneManager.LoadScene(whereToRespawn);
                    //Devolver sonido
                }
                break;

            default:
                if (Input.GetKey(KeyCode.R))
                {
                    Time.timeScale = 1;
                    SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
                    // UnityEngine.SceneManagement.SceneManager.LoadScene(whereToRespawn);
                    //Devolver sonido
                }
                break;



        }

        if (momSpawned == 1)
        {
            StartCoroutine(MomSpawnedText());
        }

        if (ending1 == 1)
        {
            StartCoroutine(Ending1Text());
        }

        if (ending2 == 1)
        {
            StartCoroutine(Ending2Text());
        }
        if (ending3 == 1)
        {
            StartCoroutine(Ending3Text());
        }

        IEnumerator MomSpawnedText()
        {
            momAwaken.SetActive(true);
            yield return new WaitForSeconds(5);
            momAwaken.SetActive(false);
            momSpawned = 0;
        }

        IEnumerator Ending1Text()
        {
            ending1Text.SetActive(true);
            blackScreen.SetActive(true);
            yield return new WaitForSeconds(10);
            ending1Text.SetActive(false);
            blackScreen.SetActive(false);
            ending1 = 0;
           // SceneManager.LoadScene("Dia 2");

        }

        IEnumerator Ending2Text()
        {
            ending2Text.SetActive(true);
            blackScreen.SetActive(true);
            yield return new WaitForSeconds(10);
            ending2Text.SetActive(false);
            blackScreen.SetActive(false);
            ending2 = 0;
            // SceneManager.LoadScene("Dia 3");

        }

        IEnumerator Ending3Text()
        {
            ending3Text.SetActive(true);
            blackScreen.SetActive(true);
            yield return new WaitForSeconds(10);
            ending3Text.SetActive(false);
            blackScreen.SetActive(false);
            ending2 = 0;
            // SceneManager.LoadScene("Dia 4");

        }
    }
}


