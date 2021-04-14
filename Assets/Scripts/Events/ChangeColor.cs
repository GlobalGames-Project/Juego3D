using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ChangeColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

		Action action = () => {
			Camera.main.backgroundColor = UnityEngine.Random.ColorHSV();
		};

		Button button = GetComponent<Button>();
		button.onClick.AddListener(() => {
			Popup popup = UIController.Instance.CreatePopup();
			//Init popup with params (canvas, text, text, text, action)
			popup.Init(UIController.Instance.MainCanvas,
				"Do you really want to change color?",
				"Maybe not",
				"Sure!",
				action
				);
		});
    }
}
