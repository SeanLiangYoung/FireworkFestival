using UnityEngine;
using System.Collections;

public class LauncherManager : MonoBehaviour
{
	public GameObject[] launchers;
	public static LauncherManager instance;

	public static LauncherManager Instance
	{
		get 
		{
			return instance;
		}
	}
	void Awake () {
		instance = this;
	}


	public void LaunchFireworks(int num_shells, int lv,Note note = null)
	{
		int launcher_index = Random.Range(0,launchers.Length-1);

		/*if ( c == 'A' ) {
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
		}*/

		//launcher_index = 7;
		LaunchFireworks( launcher_index, num_shells, lv, note);
	}

    public void SetFireworkType(int launcher_index, int firework_index)
    {
        GameObject launcher = launchers[launcher_index];
        Launcher launcher_script = launcher.GetComponent<Launcher>();
        launcher_script.particle_index = firework_index;
    }
	
	private void LaunchFireworks( int launcher_index, int num_shells, int height_level, Note note)
	{
		GameObject launcher_go = launchers[launcher_index];
		if ( launcher_go.GetComponent( typeof( Launcher ) ) ) {

			Launcher launcher_script = ( Launcher )launcher_go.GetComponent( typeof( Launcher ) );

            launcher_script.Launch(num_shells, height_level, note);
            
		}
	}
}