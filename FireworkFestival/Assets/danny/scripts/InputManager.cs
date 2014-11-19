using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{	
	public LauncherManager launcher_manager;
	
	void Update()
	{
		int num_shells = 1;

		if ( Input.GetKeyDown( KeyCode.A ) ) {
			launcher_manager.LaunchFireworks( 'A', num_shells );
		}
		if ( Input.GetKeyDown( KeyCode.S ) ) {
			launcher_manager.LaunchFireworks( 'S', num_shells );
		}
		if ( Input.GetKeyDown( KeyCode.D ) ) {
			launcher_manager.LaunchFireworks( 'D', num_shells );
		}
		if ( Input.GetKeyDown( KeyCode.F ) ) {
			launcher_manager.LaunchFireworks( 'F', num_shells );
		}
		if ( Input.GetKeyDown( KeyCode.J ) ) {
			launcher_manager.LaunchFireworks( 'J', num_shells );
		}
		if ( Input.GetKeyDown( KeyCode.K ) ) {
			launcher_manager.LaunchFireworks( 'K', num_shells );
		}
		if ( Input.GetKeyDown( KeyCode.L ) ) {
			launcher_manager.LaunchFireworks( 'L', num_shells );
		}
		if ( Input.GetKeyDown( KeyCode.Semicolon ) ) {
			launcher_manager.LaunchFireworks( ';', num_shells );
		}
	}
}