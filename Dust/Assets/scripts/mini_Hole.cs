using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class mini_Hole : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if (other.transform.tag == "Player") {
			SceneManager.LoadScene ("EndingScene");
		}
	}
}
