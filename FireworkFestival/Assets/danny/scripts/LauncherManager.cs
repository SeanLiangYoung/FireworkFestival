using UnityEngine;
using System.Collections;

public class LauncherManager : MonoBehaviour
{
	public GameObject[] launchers;

	// DEBUG.
	private float timeBetweenLaunches;
	private float timeSinceLastLaunch;

	// Use this for initialization
	void Start()
	{
		// DEBUG.
		timeBetweenLaunches = 2.0f;
		timeSinceLastLaunch = 0.0f;
	}
	
	// Update is called once per frame
	void Update()
	{
		// DEBUG.
		timeSinceLastLaunch += Time.deltaTime;
		if ( timeSinceLastLaunch > timeBetweenLaunches ) {
			timeSinceLastLaunch = 0.0f;
			LaunchFireworks( 1 );
		}
	}

	// Launch n number of fireworks randomly from the Launcher game objects in the scene.
	public void LaunchFireworks( int n )
	{
		// DEBUG.
//		Debug.Log( "Inside LaunchFireworks()." );

		int start_index = Random.Range( 0, launchers.Length );

		for ( int i = 0; i < n; ++i ) {
			int launcher_index = start_index + i;
			while ( launcher_index >= launchers.Length ) {
				launcher_index %= launchers.Length;
			}

			GameObject launcher_go = launchers[launcher_index];
			if ( launcher_go.GetComponent( typeof( Launcher ) ) ) {
				Launcher launcher_script = ( Launcher )launcher_go.GetComponent( typeof( Launcher ) );
				launcher_script.Launch();
			}
		}
	}
}