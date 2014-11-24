using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

public class BeatCreator : MonoBehaviour {

	public string fileName;
	private List<float[]> _beatList;
	public List<float> beatDurations;
	public List<float> beats;
	public AudioSource song;
	public GameObject cube;
	
	public Material red;
	public Material yellow;

	public float constant;

	private float _timeOffset;
	private int _currentBeat;

	public static BeatCreator instance;

	public int beatMarginForError;
	public bool testMode;
	
	
	public static BeatCreator Instance
	{
		get 
		{
			return instance;
		}
	}
	void Awake () {
		instance = this;
		_currentBeat = 0;
		_beatList = new List<float[]>();
		try
		{
			using (StreamReader sr = new StreamReader(fileName))
			{
				while (!sr.EndOfStream) {
					string[] line = sr.ReadLine().Split(new char[] { ' ' });
					_beatList.Add(new float[3]{float.Parse(line[0]),float.Parse(line[1]),float.Parse(line[2])});
				}
			}
		}
		catch (Exception e)
		{
			Debug.LogError("The file could not be read:");
			Debug.LogError(e.Message);
		}
		beats = new List<float>();
		beatDurations = new List<float>();
		float currTime = 0.0f;
		for (int i = 0; i < _beatList.Count; i++) {
			float e = _beatList[i][1];
			float E = _beatList[i][2];
			if (e > (constant * E)) {
				beats.Add(_beatList[i][0]);// - currTime);
				beatDurations.Add(_beatList[i][0]-currTime);
				currTime = _beatList[i][0];
				int misses = 0;
				while (misses < beatMarginForError) {
					if (i < _beatList.Count-1 && e > (constant * E) ) {
						i++;
						e = _beatList[i][1];
						E = _beatList[i][2];
						misses = 0;
					} else {
						i++;
						misses++;
					}
				}
			}
		}
		if (testMode) {
			PlaySong();
		}
	}
	// Use this for initialization
	void Start () {
	}

	public void PlaySong () {
		_timeOffset = Time.time;
		song.Play();
	}
	
	// Update is called once per frame
	void Update () {
		float time = Time.time-_timeOffset;
		if (cube != null) {
			if (time >= beats[_currentBeat]) {
				cube.GetComponent<MeshRenderer> ().material = red;
				_currentBeat++;
			} else {
				cube.GetComponent<MeshRenderer> ().material = yellow;
			}
		}
		/*if (song.isPlaying) {
			if (time >= _beatList[_currentBeat][0]) {
				float e = _beatList[_currentBeat][1];
				float E = _beatList[_currentBeat][2];
				if (e > (constant * E)) {
					cube.GetComponent<MeshRenderer> ().material = red;
				} else {
					cube.GetComponent<MeshRenderer> ().material = yellow;
				}
				_currentBeat++;
			}
		}*/
	}
}
