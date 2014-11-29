using UnityEngine;
using System.Collections;

public class Launcher : MonoBehaviour
{
	public GameObject[] particles;
	public int particle_index;

	private GameObject current_go;

	public void Launch( int num_shells )
	{
		GameObject particle_go = particles[particle_index];
		if ( particle_go.GetComponent( typeof( ParticleSystem ) ) ) {
			if ( !current_go ) {
				GameObject go = ( GameObject )Instantiate( particle_go, this.transform.position, this.transform.rotation );
				current_go = go;
			}

			ParticleSystem ps = ( ParticleSystem )current_go.GetComponent( typeof( ParticleSystem ) );
			ps.Emit( num_shells );
		}
	}
}