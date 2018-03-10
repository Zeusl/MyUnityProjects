using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp : MonoBehaviour {
	public static float hp;
	public Slider healthBarSlider;

	void Start () {
		hp = 700; //Timer._totaleatdust * 5;
		healthBarSlider.value = hp;
	}

	void OnTriggerEnter(Collider other){ //적을 만나면 hp감소
		if (other.gameObject.tag == "Enemy" && (healthBarSlider.value)>0) {
			healthBarSlider.value -= 23f;//3.3f;  

		} else {
			SceneManager.LoadScene ("EndingScene"); //ending_scene
		}
	}
}
