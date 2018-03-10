using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TouchPad : MonoBehaviour {

	public RectTransform _touchPad;
	public RectTransform _touchBackground;
	private int _touchCheck=-1;
	private Vector3 _startPosition = Vector3.zero;
	private float _radius= 0.0f;
	public playerMovement _player;
	private bool _Onbutton = false;


	void Start () {
		_startPosition = _touchBackground.position;
		_radius = _touchBackground.rect.width / 2.0f;
	}

	public void ButtonDown(){
		_Onbutton = true;
	}

	public void ButtonUp(){
		_Onbutton = false;
		InputFunc (_startPosition);
	}

	void FixedUpdate(){
		TouchInput ();

		#if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN || UNITY_WEBPLAYER
		InputFunc(Input.mousePosition);
		#endif
	}

	void TouchInput(){
		int i = 0;

		if (Input.touchCount > 0) {
			foreach (Touch touch in Input.touches) {
				i++;

				Vector3 touchPos = new Vector3 (touch.position.x, touch.position.y);

				if (touch.phase == TouchPhase.Began) {
					if (touch.position.x <= (_touchBackground.anchoredPosition.x + _touchBackground.sizeDelta.x)) {
						_touchCheck = i;
					}
				}

				if (touch.phase == TouchPhase.Moved|| touch.phase == TouchPhase.Stationary) {
					if (_touchCheck == i) {
						InputFunc (touchPos);
					}
				}

				if (touch.phase == TouchPhase.Ended) {
					if (_touchCheck == i) {
						_touchCheck = -1;
					}
				}
			}
		}
	}

	void InputFunc(Vector3 input){
		if (_Onbutton) {
			Vector3 diffVector = (input - _startPosition);

			if (diffVector.sqrMagnitude > _radius * _radius) {
				diffVector.Normalize ();

				_touchPad.position = _startPosition + diffVector * _radius;
			} else {
				_touchPad.position = input;
			}
		} else {
			_touchPad.position = _startPosition;
		}

		Vector3 diff = _touchPad.position - _startPosition;

		Vector2 normDiff = new Vector3 (diff.x / _radius, diff.y / _radius);

		if (_player != null) {
			_player.OnStickChanged (normDiff);
		}

	}

}
