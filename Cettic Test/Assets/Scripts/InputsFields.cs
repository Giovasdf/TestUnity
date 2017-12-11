using System.Collections;
using System.Collections.Generic;
using System.Net;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class InputsFields : MonoBehaviour {
	[SerializeField] private Button	btnHidePass;
	[SerializeField] private InputField pass;
	[SerializeField] private Sprite hide;
	[SerializeField] private Sprite notHide;


	//al iniciar define el tipo del input field(password) y asigna la respectiva imagen 
	void Start(){
		btnHidePass.image.sprite = hide;
		pass.contentType = InputField.ContentType.Password;

	}
	//al hacer click cambia entre los tipos password y standard, cambiando tambien la imagen	
	public void changeHidePass()
	{
		if (btnHidePass.image.sprite == notHide) {
			pass.contentType = InputField.ContentType.Password;
			btnHidePass.image.sprite = hide;
		} else {
			btnHidePass.image.sprite = notHide;
			pass.contentType = InputField.ContentType.Standard;

		}
	} 


}
