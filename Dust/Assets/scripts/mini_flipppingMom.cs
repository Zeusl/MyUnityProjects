using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mini_flipppingMom : MonoBehaviour {

	public float _xpos;
	private bool _currentMompos;

	void Update(){
		_xpos = this.transform.position.x;

		if(_xpos>=497){
			float xMove = 7.0f * Time.deltaTime*-1.0f;
			this.transform.Translate (new Vector3 (xMove, 0.0f, 0.0f));
			_currentMompos = true;
		} else if(_xpos<=456){
			float xMove = 7.0f * Time.deltaTime;
			this.transform.Translate (new Vector3 (xMove, 0.0f, 0.0f));
			_currentMompos = false;
		}

		if (_currentMompos) {
			float xMove = 7.0f * Time.deltaTime * -1.0f;
			this.transform.Translate (new Vector3 (xMove, 0.0f, 0.0f));
		} else {
			float xMove = 7.0f * Time.deltaTime;
			this.transform.Translate (new Vector3 (xMove, 0.0f, 0.0f));
		}


	}
}
