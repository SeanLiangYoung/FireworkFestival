using UnityEngine;
using System.Collections;

public class scoreDisplay : MonoBehaviour {

    public GameObject[] highScores;

	// Use this for initialization
	void Start () {

        for (int i = 0; i < highScores.Length; ++i)
            highScores[i].GetComponent<TextMesh>().text = "";
	}
	
	// Update is called once per frame
	void Update () {

        highScores[0].GetComponent<TextMesh>().text = "1: " + PlayerPrefs.GetInt("HG1");
        highScores[1].GetComponent<TextMesh>().text = "2: " + PlayerPrefs.GetInt("HG2");
        highScores[2].GetComponent<TextMesh>().text = "3: " + PlayerPrefs.GetInt("HG3");
	}
}
