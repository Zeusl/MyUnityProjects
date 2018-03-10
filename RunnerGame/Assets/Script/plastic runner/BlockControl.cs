using UnityEngine;
using System.Collections;

public class BlockControl : MonoBehaviour {
	public MapCreator map_creator = null; //MapCreator를 보관하는 변수

	// Use this for initialization
	void Start () {
		//MapCreator 를 가져와 멤버 변수 map_creator에 보관
		map_creator = GameObject.Find("GameRoot").GetComponent<MapCreator>();// find -> findwithtag
		//FindWithTag("Player");

	}

	// Update is called once per frame
	void Update () {
		if (this.map_creator.isDelete (this.gameObject)) { // 안 보이면
			GameObject.Destroy (this.gameObject); //자기자신 삭제 
		}
	}
}
