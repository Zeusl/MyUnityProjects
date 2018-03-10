using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class back : MonoBehaviour {

	public void Button5(){
		Invoke ("backto", .3f);
	}
	public void backto(){
		SceneManager.LoadScene ("StartingScene"); 
	}
}
