using UnityEngine;
using System.Collections;

public class RandomRotate : MonoBehaviour {

	private float rotateStart;
	private Vector3 goalEuler;
	private float rotateTimer;
	private const float ROTATE_SPEED = 1.0f;
	private const float RANDOM_ROT_Y_MIN = -20.0f;
	private const float RANDOM_ROT_Y_MAX = 20.0f;
	private const float RANDOM_ROT_TIMER_MIN = 0.5f;
	private const float RANDOM_ROT_TIMER_MAX = 2.0f;

	// Use this for initialization
	void Start () {

		rotateStart = transform.localEulerAngles.y;
		ResetGoal();
		ResetRotateTimer();

	}

	private void ResetGoal()
	{
		goalEuler = new Vector3( 0.0f, Random.Range( RANDOM_ROT_Y_MIN, RANDOM_ROT_Y_MAX ) - rotateStart, 0.0f);
	}

	private void ResetRotateTimer()
	{
		rotateTimer = Random.Range( RANDOM_ROT_TIMER_MIN, RANDOM_ROT_TIMER_MAX );
	}
	
	// Update is called once per frame
	void Update () {

		rotateTimer -= Time.deltaTime;

		if( rotateTimer <= 0.0f )
		{
			ResetGoal();
			ResetRotateTimer();
		}

		transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler( goalEuler ), Time.deltaTime * ROTATE_SPEED );
	}
}
