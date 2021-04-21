using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class PcController : MonoBehaviour
{
	 int id_dialogo_LoL = (int)EnumDialogosId.dialogoJugarPC; // id para los dialogos
	public GameObject popUpBox;
	public Text pregunta;
	public Button Paja;
	public Button Lolete;

    void Start()
	{
		popUpBox.SetActive(false);
	}


	public void OnTriggerEnter(Collider other)
	{
		popUpBox.SetActive(true);
		Lolete.onClick.AddListener(() => {
			popUpBox.SetActive(false);
			EventGenerator.current.DialogueShow(id_dialogo_LoL);
		});
	}
	}
