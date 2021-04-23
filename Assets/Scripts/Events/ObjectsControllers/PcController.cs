using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class PcController : MonoBehaviour
{
	 int id_dialogo_LoL = (int)EnumDialogosId.dialogoJugarPC; // id para los dialogos
	int id_evento_lol = (int)NightmareEventosEnum.EventosEnum.eventoDisparoRacimo;
	public GameObject popUpBox;
	public bool isActive = true;
	public GameObject light;
	public Text pregunta;
	public Button Paja;
	public Button Lolete;

    


	public void OnTriggerStay(Collider other)
	{
		
		if (isActive)
		{
			Lolete.GetComponentInChildren<Text>().text = "LoL";
			Paja.GetComponentInChildren<Text>().text = "Paja";
			if (Input.GetButton("Submit"))
			{
				isActive = false;
				popUpBox.SetActive(true);
				Lolete.onClick.AddListener(() => {
					popUpBox.SetActive(false);
					EventGenerator.current.DialogueShow(id_dialogo_LoL);
					DiaGameManager.eventObject.setActiveEvento(id_evento_lol);
				});
				Paja.onClick.AddListener(() =>
				{
					Paja.GetComponentInChildren<Text>().text = "FBI is Watching";
				});
				light.SetActive(isActive);
			}

		}
	}
	 
	
}
