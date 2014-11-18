using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour {


	Vector3 velocity;
	// Use this for initialization
	void Start () {

		velocity = new Vector3( 0.1f, 0.0f, 0.0f );
	}

	void FixedUpdate()
	{
		gameObject.transform.Translate( velocity );
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void Die()
	{
		Destroy( gameObject );
	}
}
