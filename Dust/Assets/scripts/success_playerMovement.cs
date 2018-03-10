using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class success_playerMovement : MonoBehaviour {

	void Update () {
		float xMove = 1.0f * Time.deltaTime;
		this.transform.Translate (new Vector3 (0.0f, 0.0f, xMove));

		if (this.transform.position.z <= 67) {
			SceneManager.LoadScene ("StartingScene");
		}
	}
}
