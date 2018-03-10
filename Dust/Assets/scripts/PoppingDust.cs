using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoppingDust : MonoBehaviour {

	/*public GameObject player;
	public GameObject dust_jump;
	public Animator ani;
	public int popState;

	void OnTriggerEnter(Collider Other){
		if (Other.transform.tag == "Player") {
			player.transform.position = new Vector3 (27.39f, 1.31f, 9.938f);
			ani = dust_jump.GetComponent<Animator> ();
			ani.Play ("popping");
		}
	}*/

	public GameObject dust_jump;

	private Animator ani;
	private bool popping;
	private GameObject player;
	private float ypos,xpos,zpos;

	void Start(){
		ani = dust_jump.GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		ypos = player.transform.position.y;
	}
		
	void OnTriggerEnter(Collider Other){
		if (Other.transform.tag == "Player") {
			xpos = player.transform.position.x;
			zpos = player.transform.position.z;
			ypos = player.transform.position.y;
			popping = true;
			ani.SetBool ("pop", popping);
			ypos += 10;
			player.transform.position = new Vector3 (xpos, ypos, zpos);
		}
	}

	void OnTriggerExit(Collider other){
		if (other.transform.tag == "Player") {
			popping = false;
			ani.SetBool ("pop", false);
		}
	}
		
}
