using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]
public class playerMovement : MonoBehaviour {

	protected Animator _dustanim;

	// Use this for initialization
	void Start () {
		_dustanim = GetComponent<Animator>();
	}

	float h, v;

	public void OnStickChanged(Vector2 stickPos){
		h=stickPos.x;
		v=stickPos.y;
	}


	// Update is called once per frame
	void Update () {
		if (_dustanim) {

			Rigidbody rigidbody = GetComponent<Rigidbody> ();


			if (rigidbody) {
				Vector3 speed = rigidbody.velocity;
		
				speed.x = 4 * h;
				speed.z = 4 * v;
				rigidbody.velocity = speed;


				if (h != 0f && v != 0f) {
					transform.rotation = Quaternion.LookRotation(new Vector3 (h, 0f, v));
					Vector3 _move = new Vector3 (h, 0f, v);
					_move += transform.TransformDirection (_move);
					_move *= Time.deltaTime*3.0f;
					_move += transform.position;
					transform.position = _move;
				}
			}
		}
	}
}
