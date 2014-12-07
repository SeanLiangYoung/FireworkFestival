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
				int length = ps.GetParticles(currentParticles);
				note.particle = currentParticles[length-1];
				previousLength++;
			}
		}
	}

	private int previousLength = 0;
	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update() {
		
		if (ps!=null) {
			int length = ps.GetParticles(currentParticles);
			int i = 0;
			if (length < previousLength) {
				int deleteNumber = previousLength - length;
				for (int j = 0; j < deleteNumber; j ++) {
					if (j < noteObjects.Count) {
						noteObjects[j].Die();
					}
				}
				if (deleteNumber <= noteObjects.Count) {
					noteObjects.RemoveRange(0,deleteNumber);
				}
			}
			previousLength = length;
			while ( i < length) {
				for (int j = 0; j < noteObjects.Count; j++) {
					noteObjects[j].transform.position = currentParticles[j].position;
				}
				i++;
			}
		}
	}
}