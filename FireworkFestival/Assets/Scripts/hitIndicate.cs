using UnityEngine;
using System.Collections;

public class hitIndicate : MonoBehaviour {

    float DISPLAYINTERVAL = 0.5f;
    float displayTime = 0.0f;

	// Use this for initialization
	void Start () {

        displayTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        if( gameObject.activeSelf )
            displayTime -= Time.deltaTime;

        if (displayTime <= 0.0f)
            gameObject.SetActive(false);
    }

    public void Show( string text )
    {
        displayTime = DISPLAYINTERVAL;
        gameObject.SetActive(true);

        gameObject.GetComponent<TextMesh>().text = text;
    }
}
