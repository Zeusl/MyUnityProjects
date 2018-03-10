using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

//엄마 random 스크립트
public class Random_MomDoor : MonoBehaviour {

	public static int com;
	public static GameObject mompos;

	// Update is called once per frame
	void Start () {
		com= Random.Range (1, 5);
		if (com == 1) {
			mompos = GameObject.FindGameObjectWithTag ("Door");
		} else if (com == 2) {
			mompos = GameObject.FindGameObjectWithTag ("Door1");
		} else if (com == 3) {
			mompos = GameObject.FindGameObjectWithTag ("Door2");
		} else if (com == 4) {
			mompos = GameObject.FindGameObjectWithTag ("Door3");
		}
	}
}
