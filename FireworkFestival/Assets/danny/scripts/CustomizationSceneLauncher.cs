using UnityEngine;
using System.Collections;

public class CustomizationSceneLauncher : MonoBehaviour
{
	public GameObject[] particles;

	private GameObject current_go;
	private Transform star;

	void Start()
	{
		star = gameObject.transform.FindChild( "star" );

		GameObject particle_go = particles[0];
		if ( particle_go.GetComponent( typeof( ParticleSystem ) ) ) {
			GameObject go = ( GameObject )Instantiate( particle_go, this.transform.position, this.transform.rotation );
			current_go = go;
		}
	}

	public void SwapParticleSystems( int particle_index )
	{
		GameObject particle_go = particles[particle_index];
		if ( particle_go.GetComponent( typeof( ParticleSystem ) ) ) {
			Destroy( current_go );
			GameObject go = ( GameObject )Instantiate( particle_go, this.transform.position, this.transform.rotation );
			current_go = go;
		}
	}

	public void PlayParticleSystem()
	{
		SetStarVisibility( true );

		if ( current_go != null ) {
			ParticleSystem ps = ( ParticleSystem )current_go.GetComponent( typeof( ParticleSystem ) );
			ps.Play();
		}
		else {
			Debug.Log( "Cannot play particle system b/c particle system has not yet been instantiated." );
		}
	}

	public void StopParticleSystem()
	{
		SetStarVisibility( false );

		if ( current_go != null ) {
			ParticleSystem ps = ( ParticleSystem )current_go.GetComponent( typeof( ParticleSystem ) );
			ps.Stop ();
		}
		else {
			Debug.Log( "Cannot stop particle system b/c particle system has not yet been instantiated." );
		}
	}

	private void SetStarVisibility( bool display_star )
	{
		if ( display_star ) {
			if ( star != null ) {
				star.renderer.enabled = true;
			}
		}
		else {
			if ( star != null ) {
				star.renderer.enabled = false;
			}
		}
	}
}