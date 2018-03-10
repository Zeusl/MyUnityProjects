using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mini_followingMom : MonoBehaviour {

	public GameObject player;
	public float player_xpos;
	public Vector3 this_position;

	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update(){
		player_xpos = player.transform.position.x;
		this_position = this.transform.position;

		if (player_xpos - this.transform.position.x > 3.0f) {
			float xMove = 10.0f * Time.deltaTime;
			this.transform.Translate (new Vector3 (xMove, 0.0f, 0.0f));
		}



		if (player_xpos - this.transform.position.x > -10.0f) {
			float xMove = 8.0f * Time.deltaTime;
			this.transform.Translate (new Vector3 (xMove, 0.0f, 0.0f));
		}else{
			this.transform.position = new Vector3 (this_position.x - 5.0f, this_position.y, this_position.z);
		}
	}
}
