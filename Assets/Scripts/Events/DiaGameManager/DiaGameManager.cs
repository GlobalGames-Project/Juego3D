using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiaGameManager : MonoBehaviour
{
    public static EventObject eventObject;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
         eventObject = new EventObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        BinariSave.Save(eventObject);
    }
}
