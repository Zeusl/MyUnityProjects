using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  
using UnityEngine.SceneManagement;

public class starting_story : MonoBehaviour {
	
	public void Button(){
		Invoke ("startstory", .3f);
	}

	public void startstory(){
		SceneManager.LoadScene ("StoryScene"); //("MainScene");
	}
}
