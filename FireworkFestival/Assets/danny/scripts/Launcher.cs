using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Launcher : MonoBehaviour
{
	public GameObject[] particles;
	public ParticleSystem[] secondaryParticles;


	private ParticleSystem.Particle[] currentParticles = new ParticleSystem.Particle[1000];
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
            //ps.startLifetime = 1.5f + 0.5f * (height_level-1);
			//ps.particleEmitter.col
			ps.Emit( num_shells );
			if (note != null) { 
				noteObjects.Add(note);
				note.notes = noteObjects;
				int length = ps.GetParticles(currentParticles);
				note.particle = currentParticles[length-1];
				note.launcher = this;
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
			int deletion = -1;
			while ( i < length) {
				for (int j = 0; j < noteObjects.Count; j++) {
					noteObjects[j].transform.position = currentParticles[j].position;
				}
				i++;
			}
//			
//			ParticleSystem.Particle[] newCurrentParticles = new ParticleSystem.Particle[1000];
//			int postDeletion = 0;
//			if (deletion > -1) {
//				for (int k = 0; k < length; k++) {
//					if (k!=deletion) {
//						newCurrentParticles[k-postDeletion] = currentParticles[k];
//					} else {
//						postDeletion = 1;
//					}
//				}
//				previousLength = length-1;
//				Debug.LogError("did this??");
//				ps.SetParticles(newCurrentParticles,length-1);
//			}
		}
	}

	public void TriggerExplosion () {
		int length = ps.GetParticles(currentParticles);
		currentParticles[0].lifetime = 0.0f;
		ps.SetParticles(currentParticles,length);
		ParticleSystem secondaryPs = Instantiate( secondaryParticles[particle_index], currentParticles[0].position, Quaternion.identity ) as ParticleSystem;
		//secondaryPs.gameObject.transform.position = currentParticles[0].position;
		secondaryPs.startLifetime = 0.01f;
		//secondaryPs.startSpeed = 0.0f;
		secondaryPs.Emit(1);
//		for (int i =0; i < 1000; i ++) {
//			secondaryPs.Emit(currentParticles[0].position,currentParticles[0].velocity,1.0f,2.0f,currentParticles[0].color);
//		}

	}

	public void DeleteFirework () {
			
		/*
		int length = ps.GetParticles(currentParticles);
		ParticleSystem.Particle[] newCurrentParticles = new ParticleSystem.Particle[1000];
		int postDeletion = 0;
		for (int k = 0; k < length-1; k++) {
			//if (k!=deletion) {
				newCurrentParticles[k] = currentParticles[k+1];
			//} else {
			//	postDeletion = 1;
			//}
		}
		previousLength = length-1;
		Debug.LogError("did this??");
		ps.SetParticles(newCurrentParticles,length-1);*/
	}
}