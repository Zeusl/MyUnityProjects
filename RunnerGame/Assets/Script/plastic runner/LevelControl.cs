using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelData{
	public struct Range{//범위를 표현하는 구조체
		public int min; //범위 최소값
		public int max; //범위 최대값
	};
	public float end_time; //종료시간
	public float player_speed; // 플레이어 속도

	public Range floor_count; // 발판 블록 수의 범위
	public Range hole_count;  //구멍 개수 범위
	public Range height_diff; //발판 높이 범위

	public LevelData()
	{
		this.end_time=15.0f;
		this.player_speed=6.0f;
		this.floor_count.min=10;
		this.floor_count.max=10;
		this.hole_count.min=2;
		this.hole_count.max=6;
		this.height_diff.min=-2;  //0
		this.height_diff.max=-2;  //0
	}
}
public class LevelControl : MonoBehaviour {
	private List<LevelData> level_datas=new List<LevelData>();
	public int HEIGHT_MAX=12;   //20
	public int HEIGHT_MIN=-15;   //-4

	public struct CreationInfo{
		public Block.TYPE block_type; // 블록의 종류
		public int max_count;//블록 최 대 갯수
		public int height;//블록을 배치할 높이
		public int current_count;//작성한 블록의 높이
	};

	public CreationInfo previous_block;//이전에 어떤 블ㅗㄱ을 만들었는가
	public CreationInfo current_block;//지금 어떤 블록을 만들어야 하는가
	public CreationInfo next_block;//작성한 블록의 개수

	public int block_count= 0;//생성한 블록의 총수
	public int level = 0;// 난이도

	private void clear_next_block(ref CreationInfo block){
		//전달받은 블록을 초기화.
		block.block_type = Block.TYPE.FLOOR; 
		block.max_count = 15;
		block.height = -20;
		block.current_count = 0;
	}

	public void initialize(){

		this.block_count = 0;//블럭의 총수를 초기화.
		//이전, 현재, 다음 블록을 각각 clear next block에 넘겨서 초기화.
		this.clear_next_block (ref this.previous_block);
		this.clear_next_block (ref this.current_block);
		this.clear_next_block (ref this.next_block);
	}

	private void update_level(ref CreationInfo current, CreationInfo previous, float passage_time)
	{
		float local_time = Mathf.Repeat (passage_time, this.level_datas [this.level_datas.Count - 1].end_time);
		int i;
		for(i=0;i<this.level_datas.Count-1; i++){
			if(local_time<=this.level_datas[i].end_time){
				break;
			}
		}
		this.level=i;

		current.block_type = Block.TYPE.FLOOR;
		current.max_count = 1;

		if(this.block_count>=10){
			LevelData level_data;
			level_data = this.level_datas [this.level];

			switch(previous.block_type){
			case Block.TYPE.FLOOR:
				current.block_type = Block.TYPE.HOLE;
				current.max_count = Random.Range(level_data.hole_count.min, level_data.hole_count.max);
				current.height = previous.height;
				break;
			case Block.TYPE.HOLE:
				current.block_type = Block.TYPE.FLOOR;
				current.max_count = Random.Range (level_data.floor_count.min, level_data.floor_count.max);
				int height_min = previous.height + level_data.height_diff.min;
				int height_max = previous.height + level_data.height_diff.max;
				height_min = Mathf.Clamp (height_min, HEIGHT_MIN, HEIGHT_MAX);
				height_max = Mathf.Clamp (height_max, HEIGHT_MIN, HEIGHT_MAX);
				current.height = Random.Range(height_min, height_max);
				break;
			}
		}
	}

	public void loadLevelData(TextAsset level_data_text)
	{
		string level_texts = level_data_text.text;
		string[] lines = level_texts.Split ('\n');

		foreach(var line in lines){
			if(line==""){
				continue;
			};
			Debug.Log(line);
			string[] words = line.Split ();
			int n = 0;
			LevelData level_data = new LevelData ();

			foreach(var word in words){
				if(word.StartsWith("#")){
					break;
				}
				if(word== ""){
					continue;
				}

				switch(n){
				case 0: level_data.end_time=float.Parse(word);
					break;
				case 1: level_data.player_speed=float.Parse(word);
					break;
				case 2: level_data.floor_count.min= int.Parse(word);
					break;
				case 3: level_data.floor_count.max = int.Parse(word);
					break;
				case 4: level_data.hole_count.min= int.Parse(word);
					break;
				case 5: level_data.hole_count.max= int.Parse(word);
					break;
				case 6: level_data.height_diff.min=int.Parse(word);
					break;
				case 7: level_data.height_diff.max=int.Parse(word);
					break;
				}
				n++;
			}
			if(n>=8){
				this.level_datas.Add(level_data);
			}else{
				if(n==0){
					
				}else{
					Debug.LogError("[LevelData] Out of parameter.\n");
				}
			}
		}
		if(this.level_datas.Count==0){
			Debug.LogError("[LevelData] Has no data.\n");
			this.level_datas.Add (new LevelData());
		}
	}

	public float getPlayerSpeed()
	{
		return(this.level_datas [this.level].player_speed);
	}

	//public void update()
	public void update(float passage_time)
	{
		//이번에 만든 블록 개수를 증가.
		this.current_block.current_count++;
		//이번에 만든 블록 개가 max count 이상이면
		if (this.current_block.current_count >= this.current_block.max_count) {
			this.previous_block = this.current_block;
			this.current_block = this.next_block;
			//다음에 만들 블록의 내용을 초기화.
			this.clear_next_block (ref this.next_block);
			//다음번에 만들 블록을 설정.
			//this.update_level(ref this.next_block, this.current_block);
			this.update_level (ref this.next_block, this.current_block, passage_time);
		}
		this.block_count++;//블록의 총 수를 증가.
	}
}