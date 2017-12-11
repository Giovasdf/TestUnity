using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour {

	public void menu () {
		SceneManager.LoadScene (0);
	}
	
	public void Juego () {
		SceneManager.LoadScene (1);
	}
}
