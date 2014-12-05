using UnityEngine;
using System.Collections;

public class Launcher : MonoBehaviour
{
	public GameObject[] particles;
	ParticleSystem.Particle[] currentParticles = new ParticleSystem.Particle[1000];

	private ParticleEmitter _particleEmitter;
	public int particle_index;

	private GameObject current_go;

	public GameObject fun;

	private ParticleSystem ps;
	/// <summary>
	/// Awake this instance.
	/// </summary>
	void Awake () {
		_particleEmitter = gameObject.GetComponent<ParticleEmitter>() as ParticleEmitter;
	}

	public void Launch( int num_shells, int height_level)
	{
		GameObject particle_go = particles[particle_index];
		if ( particle_go.GetComponent( typeof( ParticleSystem ) ) ) {
			if ( !current_go ) {
				GameObject go = ( GameObject )Instantiate( particle_go, this.transform.position, this.transform.rotation );
				current_go = go;
			}

			ps = ( ParticleSystem )current_go.GetComponent( typeof( ParticleSystem ) );
            ps.startLifetime = 1.5f + 0.5f * (height_level-1);
			ps.Emit( num_shells );
		}
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update() {
		
		if (ps!=null) {
			int length = ps.GetParticles(currentParticles); int i = 0;
				
			while (fun != null && i < length) {
				fun.transform.position = currentParticles[0].position;
				i++;
			}
		}
	}
}