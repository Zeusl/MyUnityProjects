using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mini_playerExit : MonoBehaviour {

	void Update () {
		if (this.transform.position.x >= 1392) {
			SceneManager.LoadScene ("SuccessScene");
		}
	}
}
