using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControllerOld : MonoBehaviour
{

	public static UIControllerOld Instance;

	public Transform UICanvas;

    // Start is called before the first frame update
    void Start()
    {
		if (Instance != null) {
			Destroy(this.gameObject);
			return;
		}
		Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void CreatePopup(string text, string closeText, string doText, System.Action action) {
		GameObject popup = GameObject.Instantiate(Resources.Load("UI/Popup")) as GameObject;
		PopupTestOld popupScript = popup.GetComponent<PopupTestOld>();
		popupScript.Init(UICanvas, text, doText, closeText, action);
	}
}
