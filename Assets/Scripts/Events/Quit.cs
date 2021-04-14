using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Quit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		Action action = () => {
			Application.Quit();
		};

		Button button = GetComponent<Button>();
		button.onClick.AddListener(() => {
			Popup popup = UIController.Instance.CreatePopup();
			//Init popup with params (canvas, text, text, text, action)
			popup.Init(UIController.Instance.MainCanvas,
				"Are you sure you want to quit?",
				"Stay here",
				"Bye Bye",
				action
				);
		});
	}
}
