using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using LitJson;
using UnityEngine.UI;


public class Services : MonoBehaviour {

	[SerializeField] private InputField nameINPUT;
	[SerializeField] private InputField passwordINPUT;
	string UrlPost;
	void Start()
	{
		UrlPost = "http://localhost:8089/users/login";
		StartCoroutine (Post());
	}



	//da error 500 
	IEnumerator Post () {
		
		WWWForm form = new WWWForm();
		form.AddField("name", "Andres");
		form.AddField("password", "Andres");

		Hashtable headers = new Hashtable();

		headers.Add("api_token", "cTtWsCPUnUDjV08M608Ja5bimkkKuUUMn7VkeTy66OycR7FLfvwI9CNHNfgC");

		headers.Add("Content-Type", "application/json"); 

		// Create a download object
		WWW download = new WWW( UrlPost, form);

		// Wait until the download is done
		yield return download;

		if(!string.IsNullOrEmpty(download.error)) {
			print( "Error downloading: " + download.error );
		} else {
			// show the highscores
			Debug.Log(download.text);
		}
	}



}
