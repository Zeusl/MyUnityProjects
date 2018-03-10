using UnityEngine;
using System.Collections;
// 멤버변수 설정, Start(), create_floor_block(), update()

public class Block{
	public enum TYPE {//블럭 종류를 나타내는 열거체
		NONE = -1,
		FLOOR = 0, //마루
		HOLE,//구멍
		NUM,//블록이 몇 종류인지 나타낸다. 
	};
};

public class MapCreator : MonoBehaviour {
	private GameRoot game_root=null;
	public TextAsset level_data_text = null;
	
	public static float BLOCK_WIDTH = 1.0f;     // 질문 static으로 해줄거면 차라리 private로 해주지...왜????
	public static float BLOCK_HEIGHT = 0.2f;
	public static float BLOCK_NUM_IN_SCREEN = 24;
	// levelControl 과 MapCreator를 연계시킴.
	private LevelControl level_control = null;

	private struct FloorBlock
	{
		public bool is_created; // 블록이 만들어 졌는가 아닌가     t f 로만
		public Vector3 position; //블록의 위치
	};

	private FloorBlock last_block;  // 마지막에 생성한 블록
	private PlayerControl player = null;  //씬 상의 player를 보관
	private BlockCreator block_creator; // BlockCreator를 보관 


	// Use this for initialization
	void Start () {
		this.player = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerControl>();
		//this.player = GameObject.FindGameObjectWithTag ("Player");
		//this.player= go.GetComponent<PlayerControl> ();
		this.last_block.is_created= false;
		this.block_creator = this.gameObject.GetComponent<BlockCreator>();  //blockcreator스크립트 저장  변수에 저장

		// levelControl 과 MapCreator를 연계시킴.
		this.level_control = new LevelControl();//////////////////////1월 10일 수정  / new.levelcontrol();를 바꿈
		this.level_control.initialize();

		this.level_control.loadLevelData (this.level_data_text);
		this.game_root = this.gameObject.GetComponent<GameRoot>();
		this.player.level_control = this.level_control;


	}


	private void create_floor_block(){ // 블록 만들 위치 설정하고 
		Vector3 block_position; // 블록을 만들 위치

		if (! this.last_block.is_created) { //last 블록이 생성되지 않을 경우
			block_position = this.player.transform.position; //player의 위치와 같게 해줌
			block_position.x -= BLOCK_WIDTH * ((float)BLOCK_NUM_IN_SCREEN / 2.0f);
			//블록의 x위치를 화면의 절반만큼 왼쪽으로 이동
			block_position.y = -1.0f; // 블록의 y위치는 0으로  // 원ㄹ래ㅐ는 0.0f
		}else {
			block_position = this.last_block.position;  // 이번 블록의 위치를 지난 번 블록의 위치와 동일하게 설정
		}

		block_position.x += BLOCK_WIDTH; //블록을 1블록만큼 오른쪽으로 이동

		//this.block_creator.createBlock (block_position); // 이제까지 코드에서 설정한 block_position을 건네준다
		//this.level_control.update();
		this.level_control.update(this.game_root.getPlayTime());
		block_position.y = level_control.current_block.height * BLOCK_HEIGHT;

		LevelControl.CreationInfo current = this.level_control.current_block;

		if (current.block_type == Block.TYPE.FLOOR) {
			this.block_creator.createBlock(block_position);
		}
			
		this.last_block.position = block_position;  // last_block 의 위치를 이번 위치로 갱신
		this.last_block.is_created = true;  // 블록이 생성되었으므로 last_block의 is_created 를 true로 설정
	}
	// Update is called once per frame
	void Update () {
		float block_generate_x = this.player.transform.position.x; // 플레이어의 x 위치를 가져옴
		//그리고 그 화면의 반 만큼 오른쪽으로 이동.
		// 이 위치가 블록을 생성하는 문 턱 값이 된다.
		block_generate_x += (BLOCK_WIDTH * ((float)BLOCK_NUM_IN_SCREEN + 1 / 2.0f));

		while (this.last_block.position.x < block_generate_x) {
			this.create_floor_block ();
		}

	}
	public bool isDelete(GameObject block_object){
		
		bool ret = false;//반환값
		//player부터 반 화ㄴ만큼 왼쪽에 위치
		// 이 위가 사지느랴 마느냐를 결정하는 문턱값이 됨.
		float left_limit = this.player.transform.position.x - BLOCK_WIDTH * ((float)BLOCK_NUM_IN_SCREEN / 2.0f);

		if (block_object.transform.position.x < left_limit){
			ret =true;//반환값을 true (사 라 져 도 좋 다.)
		}
		return (ret);// 판정 결과를 돌려줌.
	}

}
