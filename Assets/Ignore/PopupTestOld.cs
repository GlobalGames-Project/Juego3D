using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PopupTestOld : MonoBehaviour
{

	[SerializeField]Button _button;
	[SerializeField] Button _closeButton;
	[SerializeField] Text _buttonText;
	[SerializeField] Text _closeButtonText;
	[SerializeField] Text _popupText;

    // Start is called before the first frame update
    void Start()
    {
		_closeButton.onClick.AddListener(() => {
			GameObject.Destroy(this.gameObject);
		});
    }

	public void Init(Transform canvas, string popupText, string buttonText, string closeButtonText, Action action) {
		transform.SetParent(canvas);
		transform.localScale = Vector3.one;
		RectTransform rect = GetComponent<RectTransform>();

		rect.offsetMax = rect.offsetMin = Vector2.zero;

		_button.onClick.AddListener(() => {
			action();
			GameObject.Destroy(this.gameObject);
		});
		_popupText.text = popupText;
		_buttonText.text = buttonText;
		_closeButtonText.text = closeButtonText;
	}

}
