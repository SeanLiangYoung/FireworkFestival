using UnityEngine;
using System.Collections;

public class LauncherManager : MonoBehaviour
{
	public GameObject[] launchers;

	public void LaunchFireworks( char c, int num_shells )
	{
		int launcher_index = 0;

		if ( c == 'A' ) {
			launcher_index = 0;
		}
		else if ( c == 'S' ) {
			launcher_index = 1;
		}
		else if ( c == 'D' ) {
			launcher_index = 2;
		}
		else if ( c == 'F' ) {
			launcher_index = 3;
		}
		else if ( c == 'J' ) {
			launcher_index = 4;
		}
		else if ( c == 'K' ) {
			launcher_index = 5;
		}
		else if ( c == 'L' ) {
			launcher_index = 6;
		}
		else if ( c == ';' ) {
			launcher_index = 7;
		}

		LaunchFireworks( launcher_index, num_shells );
	}
	
	private void LaunchFireworks( int launcher_index, int num_shells )
	{
		GameObject launcher_go = launchers[launcher_index];
		if ( launcher_go.GetComponent( typeof( Launcher ) ) ) {
			Launcher launcher_script = ( Launcher )launcher_go.GetComponent( typeof( Launcher ) );
			launcher_script.Launch( num_shells );
		}
	}
}