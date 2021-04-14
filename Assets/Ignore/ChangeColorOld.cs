using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColorOld : MonoBehaviour
{
	// Start is called before the first frame update
	void Start() {
		Button button = GetComponent<Button>();

		System.Action action;
		action = () => { Camera.main.backgroundColor = Random.ColorHSV(); };

		button.onClick.AddListener(() => {
			UIControllerOld.Instance.CreatePopup(
				"Do you really want to change the color of the background?",
				"Maybe not",
				"Sure!",
				action);
			}
		);
    }
}
