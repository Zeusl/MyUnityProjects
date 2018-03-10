using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Reset : MonoBehaviour {
	
	/*
	void Update () {
		if(Input.GetKey(KeyCode.S)){
			Application.LoadL evel ("GameScene");
		}
	} 
	public int lives=3;
	public Text LivesText;

	// Use this for initialization
	void Start () {
		LivesText = this.gameObject.GetComponent<Text>();
		LivesText.text = "Lives: " + lives.ToString ();
	}
	//LivesText.SendMessage ("CountDown");  다른 스크립트에서 live  -- 함수에 접근하려고 할 때.

	// Update is called once per frame
	void Update () {
		LivesText.text = "Lives: " + lives.ToString ();
		if (lives == 0) {
			Application.LoadLevel ("GameScene");
		}
	}



	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			lives--;
			//LivesText.text = "Lives: " + lives.ToString ();
		}
	}*/

	public int damage = 1;
	public Text livesText;

	private int lives;

	void Start(){
		playerStats stats = GetComponent<Collider>().gameObject.GetComponent<playerStats> ();
		lives = stats.health;
		livesText.text = "Lives: " + lives.ToString();
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == "Player") {
			playerStats stats = collider.gameObject.GetComponent<playerStats> ();
			stats.TakeDamage (this.damage);
			lives = stats.health;
			if(lives>0)
				livesText.text = "Lives: " + lives.ToString ();
			if (lives == 2) 
				//Application.LoadLevel ("Lives2");
				SceneManager.LoadScene (2);
				//Application.LoadLevel (Application.loadedLevel);  //("Reset"); 를 바꿈.  화면밖으로 안 내려감.
			if (lives == 1)
			//	Application.LoadLevel ("Lives1");
				SceneManager.LoadScene (3);
			//	Application.LoadLevel ("Lives1");
			if (lives == 0)
				SceneManager.LoadScene (4);
		}
	}
}
