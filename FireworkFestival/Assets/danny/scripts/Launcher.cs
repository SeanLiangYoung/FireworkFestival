using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Launcher : MonoBehaviour
{
	public GameObject[] particles;
	ParticleSystem.Particle[] currentParticles = new ParticleSystem.Particle[1000];
	private List<Note> noteObjects;

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
		noteObjects = new List<Note>();
	}

	public void Launch( int num_shells, int height_level, Note note)
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
			if (note != null) { 
				noteObjects.Add(note);
				note.notes = noteObjects;
			}
		}
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update() {
		
		if (ps!=null) {
			int length = ps.GetParticles(currentParticles); int i = 0;
			//Debug.LogError(length);
			while (fun != null && i < length) {
				for (int j = 0; j < noteObjects.Count; j++) {
					noteObjects[j].transform.position = currentParticles[j].position;
				}
				//fun.transform.position = currentParticles[0].position;
				i++;
			}
		}
	}
}