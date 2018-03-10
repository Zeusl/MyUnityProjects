using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class TextScript : MonoBehaviour {
	public Text ObjText; 

	// Use this for initialization
	void Start () {
		
	}
		
	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "DoorSound") {
			ObjText.text = "!!ARREST!!";
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
