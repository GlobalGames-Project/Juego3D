using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TagTriggers : MonoBehaviour
{
    public GameObject mom;
    private int motherSpawned = 0;

    private void OnTriggerEnter(Collider other)

    {
        if (other.tag == "FallHitbox1")
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            GameManagerScript.health = 0;

        }

        if (other.tag == "Mom")
        {
            GameManagerScript.health = 0;

        }
        if (other.tag == "MomStartChasing")
        {
            mom.SetActive(true);
            if (motherSpawned == 0)
            {

                SoundManagerScript.PlaySound("momSpawn");
                GameManagerScript.momSpawned = 1;

            }
            motherSpawned = 1;
        }
        if (other.tag == "EndingCheckpoint1")
        {
            GameManagerScript.ending1 = 1;

        }
        if (other.tag == "EndingCheckpoint2")
        {
            GameManagerScript.ending2 = 1;

        }
    }
}
