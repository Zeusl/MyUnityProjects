using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class DoorMove : MonoBehaviour {  //애기 먼지들 먹는 것도 포함--tag "Baby")

	void OnTriggerEnter(Collider _col){
		if (_col.transform.tag == "Door") {
			if (Random_MomDoor.com == 1) {
				SceneManager.LoadScene (7); //거실
			}
			transform.position = new Vector3 (28.9f, 0.98f, 21.3f);
			Timer._TimeRemain = 50;
			Timer._totaldust=50;  //총 먼지 수 리셋
			Timer._eatdust=0; 
		} else if (_col.transform.tag == "Door1") {
			if (Random_MomDoor.com == 2) {
				SceneManager.LoadScene (6);  //침실
			}
			transform.position = new Vector3 (70.5f, 0.98f, -55.2f);
			Timer._TimeRemain = 50;
			Timer._totaldust=50;
			Timer._eatdust=0; 
		} else if (_col.transform.tag == "Door3") {
			if (Random_MomDoor.com == 4) {
				SceneManager.LoadScene (9); //베란다씬_추가전
			}
			transform.position = new Vector3 (29.78f, 0.98f, -4.72f);
			Timer._TimeRemain = 50;
			Timer._totaldust=50;
			Timer._eatdust=0; 
		} else if (_col.transform.tag == "Door2") {
			if (Random_MomDoor.com == 3) {
				SceneManager.LoadScene (8); //주방
			}
			transform.position = new Vector3 (82.6f, 0.98f, -22.2f);
			Timer._TimeRemain = 50;
			Timer._totaldust=50;
			Timer._eatdust=0; 

		} else if (_col.transform.tag =="Baby") {
			Timer._eatdust += 1;
			Timer._totaleatdust += 1;
		}

	}


}