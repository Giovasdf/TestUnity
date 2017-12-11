using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class GameManagerCS : MonoBehaviour {

	[SerializeField]private float timeScene;
	public float valorPlayerSpeedActual;
	public float Puntaje;
	public float valorPuntajeActual;

	[SerializeField]private Text txtpuntaje;
	[SerializeField]private Text txtTiempo;
	[SerializeField]private Text txtPuntajeFinal;

	[SerializeField]private GameObject panel;


	string Url;
	string response;

	ConfigGame configReal = new ConfigGame(); 

	void Start(){
		configReal.durationTime = 2f;

		Url = "http://localhost:8089/config";
		StartCoroutine (GetData ());
		panel.SetActive (false);
		Time.timeScale = 1;


	}
	void Update(){
		configReal.durationTime -= Time.deltaTime;
		if (configReal.durationTime < 1) {
			Debug.Log ("Perdiste");
			panel.SetActive (true);
			txtPuntajeFinal.text = "Tu Puntaje Fue: " + Puntaje.ToString();
			Time.timeScale = 0;
			//llamar post 

		}
		txtTiempo.text = "Tiempo Restante: " + Mathf.Round(configReal.durationTime).ToString ();
		txtpuntaje.text = "Puntuacion: " + Puntaje.ToString ();
	}


	//metodo Get Trae los 3 datos solicitados y los asigna a variables que se usan en las otras clases
	IEnumerator GetData()
	{
		Hashtable headers = new Hashtable();
		headers.Add("api_token", "cTtWsCPUnUDjV08M608Ja5bimkkKuUUMn7VkeTy66OycR7FLfvwI9CNHNfgC");
		headers.Add("id", "2");
		headers.Add("Content-Type", "application/json"); 

		WWW www = new WWW(Url, null, headers);

		yield return www;
		List<ConfigGame> config = JsonConvert.DeserializeObject<List<ConfigGame>>(www.text);

		configReal.PlayerSpeed =  config [0].PlayerSpeed;
		configReal.PtosPerItem =  config [0].PtosPerItem;
		configReal.durationTime =  config [0].durationTime;


			// Show results as text
		Debug.Log ("www: "+config[0].PlayerSpeed.ToString());
		valorPuntajeActual = config [0].PtosPerItem;
		valorPlayerSpeedActual = config [0].PlayerSpeed;
	}




}
