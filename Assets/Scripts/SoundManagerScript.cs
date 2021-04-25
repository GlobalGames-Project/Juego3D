using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip momSpawn;
    public static AudioClip enemyShot;


    static AudioSource audioSrc;
    // Start is called before the first frame update

    void Start()
    {
        momSpawn = Resources.Load<AudioClip>("momSpawn");
        enemyShot = Resources.Load<AudioClip>("enemyShot");


        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "momSpawn":
                audioSrc.PlayOneShot(momSpawn);
                break;
            case "enemyShot":
                audioSrc.PlayOneShot(enemyShot);
                break;
        }
    }

}
