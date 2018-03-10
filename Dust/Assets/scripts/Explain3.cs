using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class Explain3 : MonoBehaviour {

	void Update(){
		if (Input.GetMouseButtonDown (0)) {
			SceneManager.LoadScene ("ExplainScene3"); 
		}
	}
}
