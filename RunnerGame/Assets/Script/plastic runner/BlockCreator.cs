using UnityEngine;
using System.Collections;

public class BlockCreator : MonoBehaviour {

	public GameObject[] blockPrefabs; //블록을 저장할 배열
	private int block_count =0;// 생성한 블록의 개수

	public void createBlock(Vector3 block_position){
		int next_block_type = this.block_count % this.blockPrefabs.Length;
		//만들어야할 블록의 색을 구별시킴, 순서지정  block_count: 생성한 블록 수

		GameObject go = GameObject.Instantiate(this.blockPrefabs[next_block_type]) as GameObject;
		// 블록을 생성하고 go에 보관

		go.transform.position = block_position; // 블록 위치 이동... block_position을 선언한적 없음.???????????????????
		//go.transform.position.y=block_position.y;
		this.block_count++;  // 블록 갯수 증가
	}
}
