#pragma strict

var sndStep : AudioClip;
function Start () {
	
}
function OnCollisionEnter(coll: Collision){
	if(coll.gameObject.tag== "DoorSound")
		AudioSource.PlayClipAtPoint(sndStep, transform.position);
}

function Update () {
	
}
