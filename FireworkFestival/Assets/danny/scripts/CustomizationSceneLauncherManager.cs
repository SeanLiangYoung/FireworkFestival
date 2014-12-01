using UnityEngine;
using System.Collections;

public class CustomizationSceneLauncherManager : MonoBehaviour
{
	public GameObject[] launchers;

	private int curr_particle_index;
	private int prev_launcher_index;
	private int curr_launcher_index;
	private int[] launcher_particle_correspondences;
	private bool freestyle_mode;
	
	void Start()
	{
		curr_particle_index = 0;
		prev_launcher_index = 0;
		curr_launcher_index = 0;
		launcher_particle_correspondences = new int[] {0, 0, 0, 0, 0, 0, 0, 0};
		freestyle_mode = false;

		InitializeFireworkLaunchers();
	}
	
	void Update()
	{
		if ( Input.GetKeyDown( KeyCode.Space ) ) {
			if ( freestyle_mode ) {
				// Cleanup for transition from freestyle mode to customization mode.
				SetStarVisibilityForAllLaunchers( false );
				GameObject launcher_go = launchers[curr_launcher_index];
				if ( launcher_go.GetComponent( typeof( CustomizationSceneLauncher ) ) ) {
					CustomizationSceneLauncher launcher_script = ( CustomizationSceneLauncher )launcher_go.GetComponent( typeof( CustomizationSceneLauncher ) );
					launcher_script.PlayParticleSystem();
				}
			}
			else {
				// Cleanup for transition from customization mode to freestyle mode.
				StopAllLaunchers();
				SetStarVisibilityForAllLaunchers( true );
			}

			freestyle_mode = !freestyle_mode;
		}

		if ( freestyle_mode ) {
			DetectFreestyleModeInput();
		}
		else {
			DetectCustomizationModeInput();
		}
	}

	private void DetectCustomizationModeInput()
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

	private void DetectFreestyleModeInput()
	{
		GameObject launcher_go;
		CustomizationSceneLauncher launcher_script;

		if ( Input.GetKeyDown( KeyCode.A ) ) {
			launcher_go = launchers[0];
			if ( launcher_go.GetComponent( typeof( CustomizationSceneLauncher ) ) ) {
				launcher_script = ( CustomizationSceneLauncher )launcher_go.GetComponent( typeof( CustomizationSceneLauncher ) );
				launcher_script.LaunchOneShell();
			}
		}
		if ( Input.GetKeyDown( KeyCode.S ) ) {
			launcher_go = launchers[1];
			if ( launcher_go.GetComponent( typeof( CustomizationSceneLauncher ) ) ) {
				launcher_script = ( CustomizationSceneLauncher )launcher_go.GetComponent( typeof( CustomizationSceneLauncher ) );
				launcher_script.LaunchOneShell();
			}
		}
		if ( Input.GetKeyDown( KeyCode.D ) ) {
			launcher_go = launchers[2];
			if ( launcher_go.GetComponent( typeof( CustomizationSceneLauncher ) ) ) {
				launcher_script = ( CustomizationSceneLauncher )launcher_go.GetComponent( typeof( CustomizationSceneLauncher ) );
				launcher_script.LaunchOneShell();
			}
		}
		if ( Input.GetKeyDown( KeyCode.F ) ) {
			launcher_go = launchers[3];
			if ( launcher_go.GetComponent( typeof( CustomizationSceneLauncher ) ) ) {
				launcher_script = ( CustomizationSceneLauncher )launcher_go.GetComponent( typeof( CustomizationSceneLauncher ) );
				launcher_script.LaunchOneShell();
			}
		}
		if ( Input.GetKeyDown( KeyCode.J ) ) {
			launcher_go = launchers[4];
			if ( launcher_go.GetComponent( typeof( CustomizationSceneLauncher ) ) ) {
				launcher_script = ( CustomizationSceneLauncher )launcher_go.GetComponent( typeof( CustomizationSceneLauncher ) );
				launcher_script.LaunchOneShell();
			}
		}
		if ( Input.GetKeyDown( KeyCode.K ) ) {
			launcher_go = launchers[5];
			if ( launcher_go.GetComponent( typeof( CustomizationSceneLauncher ) ) ) {
				launcher_script = ( CustomizationSceneLauncher )launcher_go.GetComponent( typeof( CustomizationSceneLauncher ) );
				launcher_script.LaunchOneShell();
			}
		}
		if ( Input.GetKeyDown( KeyCode.L ) ) {
			launcher_go = launchers[6];
			if ( launcher_go.GetComponent( typeof( CustomizationSceneLauncher ) ) ) {
				launcher_script = ( CustomizationSceneLauncher )launcher_go.GetComponent( typeof( CustomizationSceneLauncher ) );
				launcher_script.LaunchOneShell();
			}
		}
		if ( Input.GetKeyDown( KeyCode.Semicolon ) ) {
			launcher_go = launchers[7];
			if ( launcher_go.GetComponent( typeof( CustomizationSceneLauncher ) ) ) {
				launcher_script = ( CustomizationSceneLauncher )launcher_go.GetComponent( typeof( CustomizationSceneLauncher ) );
				launcher_script.LaunchOneShell();
			}
		}
	}

	private void InitializeFireworkLaunchers()
	{
		for ( int i = 0; i < 8; ++i ) {
			GameObject launcher_go = launchers[i];
			if ( launcher_go.GetComponent( typeof( CustomizationSceneLauncher ) ) ) {
				CustomizationSceneLauncher launcher_script = ( CustomizationSceneLauncher )launcher_go.GetComponent( typeof( CustomizationSceneLauncher ) );
				curr_particle_index = launcher_particle_correspondences[i];
				launcher_script.SetParticleSystem( curr_particle_index );
				launcher_script.StopParticleSystem();
			}
		}
	}

	private void SwapParticleSystems()
	{
		launcher_particle_correspondences[curr_launcher_index] = curr_particle_index;
        
        //Store the firework index for cross-scene access
        PlayerPrefs.SetInt( curr_launcher_index.ToString(), curr_particle_index);

		GameObject launcher_go = launchers[curr_launcher_index];
		if ( launcher_go.GetComponent( typeof( CustomizationSceneLauncher ) ) ) {
			CustomizationSceneLauncher launcher_script = ( CustomizationSceneLauncher )launcher_go.GetComponent( typeof( CustomizationSceneLauncher ) );
			launcher_script.SetParticleSystem( curr_particle_index );
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

	private void StopAllLaunchers()
	{
		for ( int i = 0; i < 8; ++i ) {
			GameObject launcher_go = launchers[i];
			if ( launcher_go.GetComponent( typeof( CustomizationSceneLauncher ) ) ) {
				CustomizationSceneLauncher launcher_script = ( CustomizationSceneLauncher )launcher_go.GetComponent( typeof( CustomizationSceneLauncher ) );
				launcher_script.StopParticleSystem();
			}
		}
	}

	private void SetStarVisibilityForAllLaunchers( bool display_star )
	{
		for ( int i = 0; i < 8; ++i ) {
			GameObject launcher_go = launchers[i];
			if ( launcher_go.GetComponent( typeof( CustomizationSceneLauncher ) ) ) {
				CustomizationSceneLauncher launcher_script = ( CustomizationSceneLauncher )launcher_go.GetComponent( typeof( CustomizationSceneLauncher ) );
				launcher_script.SetStarVisibility( display_star );
			}
		}
	}
}