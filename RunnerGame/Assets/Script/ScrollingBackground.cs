using UnityEngine;
using System.Collections;

public class ScrollingBackground : MonoBehaviour {

	public bool scrolling,paralax;
	public float backgroundSize;
	public float paralaxSpeed;

	private Transform cameraTranform;
	private Transform[]layers;
	private float viewZone = 10;
	private int leftIndex ;
	private int rightIndex;
	private float lastCameraX;

	private void Start()
	{
		cameraTranform= Camera.main.transform;
		lastCameraX = cameraTranform.position.x;
		layers = new Transform[transform.childCount];
		for(int i=0; i< transform.childCount; i ++)
			layers[i] = transform.GetChild(i);

		leftIndex = 0;
		rightIndex= layers.Length-1;
	}

	private void Update()
	{

		if (paralax)
		{
			float deltaX = cameraTranform.position.x - lastCameraX;
			transform.position += Vector3.right * (deltaX * paralaxSpeed);
		}

		lastCameraX = cameraTranform.position.x;

		if (scrolling)
		{
			if(cameraTranform.position.x < (layers[leftIndex].transform.position.x + viewZone))
				ScrollLeft();

			if(cameraTranform.position.x > (layers[rightIndex].transform.position.x - viewZone))
				ScrollRight();
		}
	}

	private void ScrollLeft()
	{
		//int lastRight= rightIndex;
		layers[rightIndex].position = Vector3.right *(layers[leftIndex].position.x - backgroundSize);
		leftIndex= rightIndex;
		rightIndex--;
	
		if(rightIndex <0)
			rightIndex = layers.Length-1;

	}


	private void ScrollRight()
	{
		//int lastLeft= leftIndex;;
		layers[leftIndex].position = Vector3.right *(layers[rightIndex].position.x + backgroundSize);
		rightIndex= leftIndex;
		leftIndex++;

		if(leftIndex == layers.Length)
			leftIndex = 0;
	}
}