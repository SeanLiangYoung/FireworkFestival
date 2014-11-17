using UnityEngine;
using System.Collections;

public class BeatDetector : MonoBehaviour {
	public AudioSource song;
	public GameObject cube;

	public Material red;
	public Material yellow;

	public float constant;
	public float constantT;
	public int necessaryBeats;
	public int resetBeats;
	public int enoughBeats = 0;
	public int elapsedBeats = 0;
	
	float[] historyBuffer = new float[43];
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
		//compute instant sound energy
		float[] channelRight = song.audio.GetSpectrumData (1024, 1, FFTWindow.Hamming);
		float[] channelLeft = song.audio.GetSpectrumData (1024, 2, FFTWindow.Hamming);
		
		float e = sumStereo (channelLeft, channelRight);
		
		//compute local average sound evergy
		float E = sumLocalEnergy ()/historyBuffer.Length; // E being the average local sound energy
		
		//calculate variance
		float sumV = 0;
		for (int i = 0; i< 43; i++) 
			sumV += (historyBuffer[i]-E)*(historyBuffer[i]-E);
		
		float V = sumV/historyBuffer.Length;
		constantT = (float)((-0.0025714 * V) + 1.5142857);
		//Debug.Log(constantT);
		float[] shiftingHistoryBuffer = new float[historyBuffer.Length]; // make a new array and copy all the values to it
		
		for (int i = 0; i<(historyBuffer.Length-1); i++) { // now we shift the array one slot to the right
			shiftingHistoryBuffer[i+1] = historyBuffer[i]; // and fill the empty slot with the new instant sound energy
		}
		
		shiftingHistoryBuffer [0] = e;
		
		for (int i = 0; i<historyBuffer.Length; i++) {
			historyBuffer[i] = shiftingHistoryBuffer[i]; //then we return the values to the original array
		}
		
		//float constant = 1000000.50f;
		if (e > (constant * E)) { // now we check if we have a beat
			enoughBeats++;
		}
		if (enoughBeats > necessaryBeats){//(e > (constant * E)) { // now we check if we have a beat
			//Debug.LogError("beatfired");
			enoughBeats = 0;
			cube.GetComponent<MeshRenderer> ().material = red;
		} else {
			cube.GetComponent<MeshRenderer> ().material = yellow;
		}

		elapsedBeats++;
		if (elapsedBeats > resetBeats) {
			elapsedBeats = 0;
			enoughBeats = 0;
		}
		
		Debug.Log ("Avg local: " + E);
		Debug.Log ("Instant: " + e);
		Debug.Log ("History Buffer: " + historybuffer());
		
		Debug.Log ("sum Variance: " + sumV);
		Debug.Log ("Variance: " + V);
		
		Debug.Log ("Constant: " + constant);
		Debug.Log ("--------");
	}
	
	float sumStereo(float[] channel1, float[] channel2) {
		float e = 0;
		for (int i = 0; i<channel1.Length; i++) {
			e += ((channel1[i]*channel1[i]) + (channel2[i]*channel2[i]));
		}
		
		return e;
	}
	
	float sumLocalEnergy() {
		float E = 0;
		
		for (int i = 0; i<historyBuffer.Length; i++) {
			E += historyBuffer[i]*historyBuffer[i];
		}
		
		return E;
	}
	
	string historybuffer() {
		string s = "";
		for (int i = 0; i<historyBuffer.Length; i++) {
			s += (historyBuffer[i] + ",");
		}
		return s;
	}
}