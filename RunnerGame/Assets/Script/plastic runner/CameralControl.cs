using UnityEngine;
using System.Collections;

public class CameralControl : MonoBehaviour {

	private GameObject player = null;
	private Vector3 position_offset = Vector3.zero; 

	// Use this for initialization
	void Start () {  // this --- 이 아이가 적용할 대상. 카메라
		this.player = GameObject.FindGameObjectWithTag ("Player");
		this.position_offset = this.transform.position - this.player.transform.position; //카메라의 위치와 플레이어의 위의 차이를 보관하는 변ㅜ


	}

	// Update is called once per frame
	void LateUpdate () {
		Vector3 new_position = this.transform.position;  //카메라의 현재위치를 new_position에 할당
		new_position.x = this.player.transform.position.x + this.position_offset.x; 
		// 플레이어의 x좌에 차이 값을 더서 new_position의 x 에 대입
		this.transform.position = new_position; // 카메라 위치를 새로운 위치 new_position으로 갱신

	}
}
