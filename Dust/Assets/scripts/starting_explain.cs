using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  

public class starting_explain : MonoBehaviour {

	public void Button3(){
		Invoke ("startexplain", .3f);
	}

	public void startexplain(){
		SceneManager.LoadScene ("ExplainScene"); //("MainScene");
	}
}