using UnityEngine;
using System.Collections;

public class RigidBodyOn : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update()
	{
		Ray ray;
		RaycastHit hit;

		if( Input.GetMouseButtonDown( 0 ) ) 
		{
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out hit))
			{
				if( hit.transform == transform )
				{
					transform.gameObject.AddComponent<Rigidbody>();
					Destroy( transform.GetComponent<HoverExpand>() );
					Destroy( transform.GetComponent<RandomRotate>() );
					Destroy( transform.GetComponent<RigidBodyOn>() );
				}
			}
		}

	}
}
