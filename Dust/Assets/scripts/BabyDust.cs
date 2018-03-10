using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyDust : MonoBehaviour {
	public GameObject explosion;

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {
			Instantiate (explosion, col.transform.position,col.transform.rotation);	//Particle
			Destroy (this.gameObject);
		}
	}
}
