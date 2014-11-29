using UnityEngine;
using System.Collections;

public class CustomizationSceneLauncher : MonoBehaviour
{
	public GameObject[] particles;

	private int curr_particle_index;
	private int curr_launcher_index;
	private GameObject current_go;
	private int[] launcher_particle_correspondences;

	void Start()
	{
		curr_particle_index = 0;
		curr_launcher_index = 0;
		launcher_particle_correspondences = new int[] {0, 0, 0, 0, 0, 0, 0, 0};
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
			curr_launcher_index = 0;
		}
		else if ( Input.GetKeyDown( KeyCode.S ) ) {
			curr_launcher_index = 1;
		}
		else if ( Input.GetKeyDown( KeyCode.D ) ) {
			curr_launcher_index = 2;
		}
		else if ( Input.GetKeyDown( KeyCode.F ) ) {
			curr_launcher_index = 3;
		}
		else if ( Input.GetKeyDown( KeyCode.J ) ) {
			curr_launcher_index = 4;
		}
		else if ( Input.GetKeyDown( KeyCode.K ) ) {
			curr_launcher_index = 5;
		}
		else if ( Input.GetKeyDown( KeyCode.L ) ) {
			curr_launcher_index = 6;
		}
		else if ( Input.GetKeyDown( KeyCode.Semicolon ) ) {
			curr_launcher_index = 7;
		}
	}
	
	public void SwapParticleSystems()
	{
		launcher_particle_correspondences[curr_launcher_index] = curr_particle_index;

		GameObject particle_go = particles[curr_particle_index];
		if ( particle_go.GetComponent( typeof( ParticleSystem ) ) ) {
//			if ( current_go ) {
//				Destroy( current_go );
//			}
//			
//			if ( !current_go ) {
//				GameObject go = ( GameObject )Instantiate( particle_go, this.transform.position, this.transform.rotation );
//				current_go = go;
//			}

			Destroy( current_go );
			GameObject go = ( GameObject )Instantiate( particle_go, this.transform.position, this.transform.rotation );
			current_go = go;
			
			ParticleSystem ps = ( ParticleSystem )current_go.GetComponent( typeof( ParticleSystem ) );
			ps.Play ();
		}
	}
}