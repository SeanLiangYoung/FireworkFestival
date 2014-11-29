using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour {
	public float fireworkTime;
	public int minFireworks;
	public int maxFireworks;
	private MouseLauncher _launcher;

	private float _elapsedTime = 0.0f;

	//public GameObject fireworksPlane;
	// Use this for initialization
	void Start () {
		_launcher = gameObject.GetComponent<MouseLauncher>() as MouseLauncher;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 launchPosition = new Vector3();//Input.mousePosition;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit,300.0f)) {
			launchPosition = hit.point;
			//launchPosition.z-=2.0f;
		}
		//launchPosition.z = 150;
		
		_elapsedTime += Time.deltaTime;
		if (_elapsedTime >= fireworkTime )
		{
			int numFireworks = Random.Range(minFireworks,maxFireworks);
			//Debug.LogError(launchPosition.ToString());
			_launcher.LaunchFrom(numFireworks,launchPosition);
			_elapsedTime = 0.0f;
		}
	}
}
