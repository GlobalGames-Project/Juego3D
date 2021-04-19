using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitOld : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
		Button button = GetComponent<Button>();

		System.Action action;
		action = () => { Application.Quit(); };

		button.onClick.AddListener(() => {
			UIControllerOld.Instance.CreatePopup(
				"Do you really want to quit?",
				"No",
				"Bye Bye",
				action);
		}
		);
	}
}
