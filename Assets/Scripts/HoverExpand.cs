using UnityEngine;
using System.Collections;

public class HoverExpand : MonoBehaviour {

	private Vector3 startPosition;

	private const float OFFSET_Z = 0.05f;
	private const float SCALE_SPEED = 2.0f;
	private const float MOVE_SPEED = 2.0f; 
	private const float START_SCALE = 1.0f;
	private const float GOAL_SCALE = 1.05f;

	// Use this for initialization
	void Start () {
	
		startPosition = transform.localPosition;

	}
	
	// Update is called once per frame
	void Update()
	{
		Ray ray;
		RaycastHit hit;
		bool thisHit = false;

		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(ray, out hit))
		{
			if( hit.transform == transform )
			{
				thisHit = true;
				transform.localScale = Vector3.Slerp( transform.localScale, new Vector3( GOAL_SCALE, GOAL_SCALE, GOAL_SCALE ), Time.deltaTime * SCALE_SPEED );
				transform.localPosition = Vector3.Slerp( transform.localPosition, new Vector3( startPosition.x, startPosition.y, startPosition.z + OFFSET_Z ), Time.deltaTime * MOVE_SPEED );
			}
		}

		if( !thisHit )
		{
			transform.localScale = Vector3.Slerp( transform.localScale, new Vector3( START_SCALE, START_SCALE, START_SCALE ), Time.deltaTime * SCALE_SPEED );
			transform.localPosition = Vector3.Slerp( transform.localPosition, new Vector3( startPosition.x, startPosition.y, startPosition.z ), Time.deltaTime * MOVE_SPEED );
		}
	}
}
