using UnityEngine;
using System.Collections;

public class Song : MonoBehaviour {
	public string songName;

	public AudioClip audioClip;
	[HideInInspector] public AudioSource audioSource;
	public bool firstSong;
	public int constant;
	public int minBeatLength;
	// Use this for initialization
	void Start () {
		if (firstSong) {
			SceneProperties.currentSongName = songName;
		}
		audioSource = gameObject.AddComponent<AudioSource>() as AudioSource;
		audioSource.clip = audioClip;
		BeatCreator.Instance.AddSong(this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
