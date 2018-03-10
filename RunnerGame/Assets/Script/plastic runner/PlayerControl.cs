using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	public GameObject LivesText;
	public static int lives=3;
	public int jumpcount=0;
//	Text LivesText;

	private float click_timer = -1.0f;  //버튼이 눌린시간
	private float CLICK_GRACE_TIME=0.2f;/// 점프하고 싶은 의사를 받아들일 시간  // 0.5였음.

	public static float ACCELERATION =10.0f;
	public static float SPEED_MIN =4.0f;
	public static float SPEED_MAX =6.0f;
	public static float JUMP_HEIGHT_MAX =3.8f;
	public static float JUMP_KEY_RELEASE_REDUCE =0.5f;
	public static float PLAYER_HEIGHT = -4.0f; 

	public float current_speed=0.0f;
	public LevelControl level_control=null;

	public float jump;
	Animator animator= new Animator();
	Rigidbody2D rb; 

	public enum STEP {   //Player의 각종 상태를 나타내는 자료형
		NONE = -1,  //상태 정보 없음.
		RUN = 0,
		JUMP,
		MISS,
		NUM, // 상태가 몇 종류가 있는 지 보여줌 =3이다. none는 제외하고 숫자 세는 거임.
	};
		
	public STEP step = STEP.NONE; //Player 의 현재 상태 
	public STEP next_step = STEP.NONE; // 다음 상태

	public float step_timer= 0.0f; //경과 시간
	bool grounded = false; 
	bool is_key_released = false; // 버튼이 떨어졌는가.

	void Start () {
		LivesText = GameObject.Find ("LivesText");
		//LivesText = GetComponent<Text>; //compoent 멤버 중 TEXT라는 멤버에 접근
		this.next_step = STEP.RUN;  // 게임을 시작하자마자 달려나가게 하고 싶어서
		animator= GetComponent<Animator>();
		rb= GetComponent<Rigidbody2D>();

	}

	public bool isPlayEnd()
	{
		bool ret = false;
		switch (this.step) {
		case STEP.MISS:
			ret = true;
			break;
		}
		return(ret);
	}

	private void check_grounded()
	{
		//this.grounded = false;
		do {
			Vector2 s = this.transform.position; //player의 현재 위치
			Vector2 e = s + Vector2.down * 1.0f; // s부터 아래로 1.0f 로 이동한 위치
			RaycastHit hit;
			if (! Physics.Linecast(s, e, out hit)) {
				break;
			}
			if (this.step == STEP.JUMP) {
				if (this.step_timer < Time.deltaTime * 3.0f) {
					animator.SetBool ("isJumping", true);
					rb.velocity = new Vector2 (rb.velocity.x,jump);
					break;
				}
			}
			this.grounded = true; // 점프 직후가 아닐때만 아래를 실행.
		} while(false);
	}

	void Update (){
		//LivesText.text = "Lives: " + lives;
		this.transform.Translate (new Vector2 (0.0f * Time.deltaTime, 0.0f));//한결같은 움직임.
	
		Vector2 velocity = this.GetComponent<Rigidbody2D> ().velocity;
		this.current_speed = this.level_control.getPlayerSpeed ();
		this.check_grounded ();

		switch (this.step) {

		case STEP.RUN:
		case STEP.JUMP:
			if (this.grounded) {
				animator.SetBool ("isJumping", false);
			}
			
			if (this.transform.position.y < PLAYER_HEIGHT) {
				
				this.next_step = STEP.MISS;
			}
			break;
		}

		this.step_timer += Time.deltaTime;// 경과시간을 체크.

		if (Input.GetKey (KeyCode.Space)) {
			this.click_timer = 0.0f;

		} else {
			if (this.click_timer >= 0.0f) {
				this.click_timer += Time.deltaTime;
			}
		}

		if (this.next_step == STEP.NONE) {
			
			switch (this.step) {
			case STEP.RUN:
				if (0.0f <= this.click_timer && this.click_timer <= CLICK_GRACE_TIME) {
					if (this.grounded) {
						this.click_timer = -1.0f;
						this.next_step = STEP.JUMP;
					}
				}
			/*	if (!this.grounded) {  // 달리는 중이고 아무것도 하지 않는다. 
					//animator.SetBool ("isJumping", false);
				} else {
					if (Input.GetKey(KeyCode.Space)) {
						if (this.grounded) {
							this.next_step = STEP.JUMP;
							//this.step = STEP.RUN;
						}
					}
				}*/
				break;

			case STEP.JUMP:  
				if (this.grounded) { 
					this.next_step = STEP.RUN;//착지를 했다면 다시 뛰어야함.
				}
				break;
			}
		}

		while (this.next_step != STEP.NONE) { //상태가 변하는 중
			this.step = this.next_step;
			this.next_step = STEP.NONE;

			switch (this.step) {	
			case STEP.JUMP:
				jumpcount++;
				if (jumpcount == 20)//25번 점프하면 win
					SceneManager.LoadScene (5);
				animator.SetBool ("isJumping", true);
				rb.velocity = new Vector2 (rb.velocity.x, jump);
				velocity.y = Mathf.Sqrt (2.0f * 9.8f * PlayerControl.JUMP_HEIGHT_MAX);///!!!!!!!!!!!!!!!
				this.is_key_released = false;
				this.next_step = STEP.RUN;
				break;
			}
			this.step_timer = 0.0f;//상태가 변했음으로 경ㅘ시간을 제로로 리셋.
		}
		switch (this.step) {
		case STEP.RUN:
			velocity.x += PlayerControl.ACCELERATION * Time.deltaTime;

			//if (Mathf.Abs (velocity.x) > PlayerControl.SPEED_MAX) {
			//	velocity.x *= PlayerControl.SPEED_MAX / Mathf.Abs (this.GetComponent<Rigidbody2D> ().velocity.x);
			//}// 최고속도 이하로 유지하게 만든다. 
			if (Mathf.Abs (velocity.x) > this.current_speed) {
				velocity.x *= this.current_speed / Mathf.Abs (velocity.x);
			}
			break;

		case STEP.JUMP:
			do { 
				if (!Input.GetKey (KeyCode.Space)) {
					break;
				}
				if (this.is_key_released) {
					break;
				}
				if (velocity.y <= 0.0f) {
					break;
				}
					
				velocity.y *= JUMP_KEY_RELEASE_REDUCE;

				this.is_key_released = true;

			} while(false);
			break;

		case STEP.MISS:
			velocity.x -= PlayerControl.ACCELERATION * Time.deltaTime;
			if (velocity.x < 0.0f) {//player 속도가 마이너스면.
				velocity.x = 0.0f;//0으로 한다.
			}
			break;
		}
		this.GetComponent<Rigidbody2D>().velocity = velocity;  ///
	}

	void OnTriggerEnter2D(Collider2D col){  //check if grounded
		grounded = true;
		//if (col.tag == "FALL") {
		//}
	}

		//animator.SetBool("isJumping",false); //동영상 마지막에 없어짐.
		//}
	
	void OnTriggerExit2D(){
		grounded=false;
	}

}
