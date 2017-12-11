using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	[SerializeField] private float speed;
	[SerializeField] private Animator anim;
	private Rigidbody rb;

	[SerializeField] private GameManagerCS gamemanager ;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		//asigna la velocidad obtenida de la API
		speed = gamemanager.valorPlayerSpeedActual;
		//X y Z son 2 variables para guardar el movimiento
		var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed*15;
		var z = Input.GetAxis("Vertical") * Time.deltaTime * speed ;
		//rotacion del personaje 
		transform.Rotate(0, x, 0);
		//movimiento hacia adelante y atras
		transform.Translate(0, 0, z);


		//Animacion Correr Adelante
		if (Input.GetKey (KeyCode.UpArrow)||Input.GetKey (KeyCode.W)) {
			anim.SetInteger ("run",1);
		}

		//Volver al idle con flechas y W,S
		if (Input.GetKeyUp (KeyCode.UpArrow)||Input.GetKeyUp (KeyCode.W)||Input.GetKeyUp (KeyCode.DownArrow)||Input.GetKeyUp (KeyCode.S)) {
			anim.SetInteger ("run",0);
		}
		//Animacion Correr Atras

		if (Input.GetKey (KeyCode.DownArrow)||Input.GetKey (KeyCode.S)) {
			anim.SetInteger ("run",3);
		}

	}
	//Cuando entra en colision suma el puntaje y destruye la lata
	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "lata"){
			gamemanager.Puntaje += gamemanager.valorPuntajeActual;
			Destroy (col.gameObject);
		}
	}
}
