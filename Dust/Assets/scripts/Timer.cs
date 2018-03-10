using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
	public static float _TimeRemain = 50;
	public static float _totaldust=50;  //총 먼지 수
	public static float _eatdust=0;  //먹은 먼지 수 
	public static float _totaleatdust=0;  //누적 _eatdust수
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		_TimeRemain -= Time.deltaTime; 
	}

	void OnGUI(){
		GUIStyle dustStyle = new GUIStyle ();
		dustStyle.normal.textColor = Color.yellow;
		dustStyle.fontSize = 20;
		dustStyle.fontStyle = FontStyle.Bold;

		GUIStyle myStyle = new GUIStyle ();
		myStyle.normal.textColor = Color.white;
		myStyle.fontStyle = FontStyle.Bold;
		myStyle.fontSize = 20;

		if (_TimeRemain > 0) {
			GUI.Label (new Rect (0, 0,Screen.width/2, Screen.height/2), " Timer : "+(int)_TimeRemain,myStyle);
			GUI.Label (new Rect (0, 25, Screen.width / 2, Screen.height / 2), " Dust : " + (int)_eatdust +" / " +(int)_totaldust, dustStyle);
			GUI.Label (new Rect (0, 50, Screen.width / 2, Screen.height / 2), " Total Eating: " + (int)_totaleatdust, dustStyle);
		} else {//게임 over ....엔딩씬 연결
			GUI.Label (new Rect (100, 100, 100, 100), " ");
			SceneManager.LoadScene("EndingScene");
		}
	}
}
