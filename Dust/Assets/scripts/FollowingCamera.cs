using UnityEngine;
using System.Collections;

public class FollowingCamera : MonoBehaviour
{
	public float _distanceAway = 4f;			
	public float _distanceUp   = 5f;			

	public Transform follow;

	void Update ()
	{
		transform.rotation=follow.transform.rotation;
	}
}
	