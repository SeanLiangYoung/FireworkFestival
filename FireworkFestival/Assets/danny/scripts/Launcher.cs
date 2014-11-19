using UnityEngine;
using System.Collections;

public class Launcher : MonoBehaviour
{
	public GameObject[] particles;

	private GameObject current_go;

	// Use this for initialization
	void Start()
	{

	}
	
	// Update is called once per frame
	void Update()
	{
	
	}

	public void Launch()
	{
		// DEBUG.
//		Debug.Log( "Inside Launch()." );

		//int i = Random.Range( 0, particles.Length );
		int i = 7;

		GameObject particle_go = particles[i];
		if ( particle_go.GetComponent( typeof( ParticleSystem ) ) ) {
//			ParticleSystem ps = ( ParticleSystem )particle_go.GetComponent( typeof( ParticleSystem ) );
//			ps.Emit( 1 );

			if ( current_go ) {
				Destroy( current_go );
			}

			GameObject go = ( GameObject )Instantiate( particle_go, this.transform.position, this.transform.rotation );
			current_go = go;

			ParticleSystem ps = ( ParticleSystem )current_go.GetComponent( typeof( ParticleSystem ) );
//			ps.Play();
			ps.Emit( 1 );

			// DEBUG.
//			Debug.Log( "Trying to call ParticleSystem methods." );
		}
	}
}