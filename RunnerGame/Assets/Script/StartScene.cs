using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartScene : MonoBehaviour {

	 //Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space))
			SceneManager.LoadScene (1);
	}
}
