using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  


public class starting_start : MonoBehaviour {

	public void Button2(){
		Invoke ("startgame", .3f);
	}

	public void startgame(){
		Timer._TimeRemain = 50;
		Timer._totaldust=50;  //총 먼지 수
		Timer._eatdust=0;  //먹은 먼지 수 
		Timer._totaleatdust=0;//초기화
		SceneManager.LoadScene ("MainScene");
	}
}
