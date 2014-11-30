using UnityEngine;
using System.Collections;

public class CustomizationSceneLauncherManager : MonoBehaviour
{
	public GameObject[] launchers;

	private int curr_particle_index;
	private int prev_launcher_index;
	private int curr_launcher_index;
	private int[] launcher_particle_correspondences;
	
	void Start()
	{
		curr_particle_index = 0;
		prev_launcher_index = 0;
		curr_launcher_index = 0;
		launcher_particle_correspondences = new int[] {0, 0, 0, 0, 0, 0, 0, 0};

		InitializeFireworkLaunchers();
		UpdateFireworkLaunchers();
		SwapParticleSystems();
	}
	
	void Update()
	{
		if ( Input.GetKeyDown( KeyCode.RightArrow ) ) {
			++curr_particle_index;
			curr_particle_index = ( curr_particle_index > 7 ) ? 0 : curr_particle_index;
			SwapParticleSystems();
		}
		else if ( Input.GetKeyDown( KeyCode.LeftArrow ) ) {
			--curr_particle_index;
			curr_particle_index = ( curr_particle_index < 0 ) ? 7 : curr_particle_index;
			SwapParticleSystems();
		}
		
		if ( Input.GetKeyDown( KeyCode.A ) ) {
			prev_launcher_index = curr_launcher_index;
			curr_launcher_index = 0;
			UpdateFireworkLaunchers();
		}
		else if ( Input.GetKeyDown( KeyCode.S ) ) {
			prev_launcher_index = curr_launcher_index;
			curr_launcher_index = 1;
			UpdateFireworkLaunchers();
		}
		else if ( Input.GetKeyDown( KeyCode.D ) ) {
			prev_launcher_index = curr_launcher_index;
			curr_launcher_index = 2;
			UpdateFireworkLaunchers();
		}
		else if ( Input.GetKeyDown( KeyCode.F ) ) {
			prev_launcher_index = curr_launcher_index;
			curr_launcher_index = 3;
			UpdateFireworkLaunchers();
		}
		else if ( Input.GetKeyDown( KeyCode.J ) ) {
			prev_launcher_index = curr_launcher_index;
			curr_launcher_index = 4;
			UpdateFireworkLaunchers();
		}
		else if ( Input.GetKeyDown( KeyCode.K ) ) {
			prev_launcher_index = curr_launcher_index;
			curr_launcher_index = 5;
			UpdateFireworkLaunchers();
		}
		else if ( Input.GetKeyDown( KeyCode.L ) ) {
			prev_launcher_index = curr_launcher_index;
			curr_launcher_index = 6;
			UpdateFireworkLaunchers();
		}
		else if ( Input.GetKeyDown( KeyCode.Semicolon ) ) {
			prev_launcher_index = curr_launcher_index;
			curr_launcher_index = 7;
			UpdateFireworkLaunchers();
		}
	}

	private void InitializeFireworkLaunchers()
	{
		for ( int i = 0; i < 8; ++i ) {
			GameObject launcher_go = launchers[i];
			if ( launcher_go.GetComponent( typeof( CustomizationSceneLauncher ) ) ) {
				CustomizationSceneLauncher launcher_script = ( CustomizationSceneLauncher )launcher_go.GetComponent( typeof( CustomizationSceneLauncher ) );
				curr_particle_index = launcher_particle_correspondences[i];
				launcher_script.SwapParticleSystems( curr_particle_index );
			}
		}
	}

	private void SwapParticleSystems()
	{
		launcher_particle_correspondences[curr_launcher_index] = curr_particle_index;

		GameObject launcher_go = launchers[curr_launcher_index];
		if ( launcher_go.GetComponent( typeof( CustomizationSceneLauncher ) ) ) {
			CustomizationSceneLauncher launcher_script = ( CustomizationSceneLauncher )launcher_go.GetComponent( typeof( CustomizationSceneLauncher ) );
			launcher_script.SwapParticleSystems( curr_particle_index );
		}
	}

	private void UpdateFireworkLaunchers()
	{
		curr_particle_index = launcher_particle_correspondences[curr_launcher_index];

		GameObject launcher_go = launchers[prev_launcher_index];
		if ( launcher_go.GetComponent( typeof( CustomizationSceneLauncher ) ) ) {
			CustomizationSceneLauncher launcher_script = ( CustomizationSceneLauncher )launcher_go.GetComponent( typeof( CustomizationSceneLauncher ) );
			launcher_script.StopParticleSystem();
		}

		launcher_go = launchers[curr_launcher_index];
		if ( launcher_go.GetComponent( typeof(CustomizationSceneLauncher ) ) ) {
			CustomizationSceneLauncher launcher_script = ( CustomizationSceneLauncher )launcher_go.GetComponent( typeof( CustomizationSceneLauncher ) );
			launcher_script.PlayParticleSystem();
		}
	}
}