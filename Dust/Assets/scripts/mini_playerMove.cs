using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mini_playerMove : MonoBehaviour {

	public static float _acceleration=10.0f;
	public static float _minSpeed=4.0f;
	public static float _maxSpeed=8.0f;
	public static float _maxJumpHeight=200.0f;
	public static float _keyRelease = 0.5f;
	public float _xMove;

	public enum CONDITION{
		NONE=-1,
		RUN=0,
		JUMP,
		MISS,
		NUM,
	};

	public CONDITION stage = CONDITION.NONE;
	public CONDITION _nextStage = CONDITION.NONE;

	public float _conditionTimer = 0.0f;
	private bool _onLand = false;
	//	private bool is_collided=false;
	private bool _onKeyRel = false;

	void Start(){
		this._nextStage = CONDITION.RUN;
	}

	private void LandCheckFunc(){
		this._onLand = false;
		do {
			Vector3 s=this.transform.position;
			Vector3 e=s+Vector3.down*1.0f;
			RaycastHit hit;
			if(!Physics.Linecast(s,e,out hit)){
				break;
			}

			if(this.stage==CONDITION.JUMP){
				if(this._conditionTimer<Time.deltaTime*3.0f){
					break;
				}
			}

			this._onLand=true;

		} while(false);
	}

	void Update(){
		Vector3 velocity = this.GetComponent<Rigidbody> ().velocity;
		this.LandCheckFunc ();
		this._conditionTimer += Time.deltaTime;

		if (this._nextStage == CONDITION.NONE) {
			switch (this.stage) {
			case CONDITION.RUN:
				if (!this._onLand) { //달리는 중일때는 움직이기
				} else {
					if (Input.GetMouseButtonDown (0)) {
						this._nextStage = CONDITION.JUMP;
					}
				}
				break;
			case CONDITION.JUMP:
				if (this._onLand) {
					this._nextStage = CONDITION.RUN;
				}
				break;
			}
		}

		while (this._nextStage != CONDITION.NONE) {
			this.stage = this._nextStage;
			this._nextStage = CONDITION.NONE;
			switch (this.stage) {
			case CONDITION.JUMP:
				velocity.y = Mathf.Sqrt (2.0f * 9.8f * mini_playerMove._maxJumpHeight);
				this._onKeyRel = false;
				break;

			}
			this._conditionTimer = 0.0f;
		}

		switch (this.stage) {
		case CONDITION.RUN:
			velocity.x += mini_playerMove._acceleration * Time.deltaTime;
			if (Mathf.Abs (velocity.x) > mini_playerMove._maxSpeed) {
				velocity.x *= mini_playerMove._maxSpeed / Mathf.Abs (this.GetComponent<Rigidbody> ().velocity.x);
			}

			_xMove = 10.0f * Time.deltaTime * -1;
			this.transform.Translate (new Vector3 (_xMove, 0.0f, 0.0f));

			break;

		case CONDITION.JUMP:
			do {
				if (!Input.GetMouseButtonUp (0)) {
					break;
				}
				if (this._onKeyRel) {
					break;
				}
				if (velocity.y <= 0.0f) {
					break;
				}

				velocity.y *= _keyRelease;
				this._onKeyRel = true;
			} while(false);

			_xMove = 6.0f * Time.deltaTime * -1;
			this.transform.Translate (new Vector3 (_xMove, 0.0f, 0.0f));

			break;
		}
		this.GetComponent<Rigidbody> ().velocity = velocity;
	}

}