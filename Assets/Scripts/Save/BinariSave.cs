using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

public class BinariSave : MonoBehaviour {

    private static string URL = Application.dataPath + "/Scripts/Save/Saves/save.dat";

    public static void Save(EventObject eventObject)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fileStream = File.Create((URL));

        bf.Serialize(fileStream, eventObject);

        fileStream.Close();
        Debug.Log("Saved");
    }

    public static EventObject Load()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fileStream = File.Open((URL), FileMode.Open);

        EventObject eventObject = bf.Deserialize(fileStream) as EventObject;

        fileStream.Close();

        return eventObject;
    }
}
