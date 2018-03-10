using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mini_fallingMom : MonoBehaviour {

	public bool is_grounded;

	void Update(){
		if (this.transform.position.y <= -0.5f) {
			is_grounded = true;
			this.GetComponent<Rigidbody> ().AddForce (Vector3.up * 50.0f, ForceMode.Impulse);
		}
		if (is_grounded) {
			this.transform.Translate (new Vector3 (0.0f, 21.6f, 0.0f));
			is_grounded = false;
		}
	}
}
