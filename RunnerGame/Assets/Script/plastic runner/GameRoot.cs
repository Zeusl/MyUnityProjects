using UnityEngine;
using System.Collections;

public class GameRoot : MonoBehaviour {
	public float step_timer = 0.0f;
	public PlayerControl player = null;
	void Start()
	{ 
		//LivesText = GameObject.Find ("LivesText");
		this.player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerControl> ();
	}     
	 
	void Update () {
		this.step_timer += Time.deltaTime;
	//	if (this.player.isPlayEnd ()) {
		// 	LivesText.SendMessage ("CountDown");  //Lives가 이상. 원하는 대로 안됨.
		//	Application.LoadLevel ("Reset");  //오류남.
		//	Application.LoadLevel(Application.loadedLevel);  //("Reset"); 를 바꿈.  화면밖으로 안 내려감.
	//	}
	}

	public float getPlayTime()
	{
		float time;
		time = this.step_timer;
		return(time);
	}
}
