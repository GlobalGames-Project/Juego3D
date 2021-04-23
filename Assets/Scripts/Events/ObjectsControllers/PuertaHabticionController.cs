using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuertaHabticionController : MonoBehaviour
{
    int id_dialogoMadrePositivo = (int)EnumDialogosId.dialogoMadrePositivo; // id para los dialogos
    int id_dialogoMadreNegativo = (int)EnumDialogosId.dialogoMadreNegativo;
    public GameObject popUpBox;
    public static bool isActive = false;
    public GameObject light;
    public Text pregunta;
    public Button Bien;
    public Button Mal;
    // Start is called before the first frame update
    private void Update()
    {
		light.SetActive(isActive);
    }
    public void OnTriggerStay(Collider other)
	{

		if (isActive)
		{
			Bien.GetComponentInChildren<Text>().text = "Talk With Mom";
			Mal.GetComponentInChildren<Text>().text = "Insult Mom";
			if (Input.GetButton("Submit"))
			{
				isActive = false;
				popUpBox.SetActive(true);
				Bien.onClick.AddListener(() => {
					popUpBox.SetActive(false);
					EventGenerator.current.DialogueShow(id_dialogoMadrePositivo);
				});
				Mal.onClick.AddListener(() =>
				{
					popUpBox.SetActive(false);
					EventGenerator.current.DialogueShow(id_dialogoMadreNegativo);
					
				});
				light.SetActive(isActive);
				CamaController.talkMom();
			}

		}
	}

	
}
