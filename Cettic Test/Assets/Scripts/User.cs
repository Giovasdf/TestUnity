using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour {
	//clase generica para deserializar el json

	public int id { get; set; }
	public string nameUser { get; set; }
	public string email { get; set; }
	public string password { get; set; }
	public string token { get; set; }
}

