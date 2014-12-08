using UnityEngine;
using System.Collections;

public class ComboValue : MonoBehaviour {

    float DISPLAYINTERVAL = 1.0f;
    float displayTime = 0.0f;

	// Use this for initialization
	void Start () {
        displayTime = 0.0f;
	}

    void FixedUpdate()
    {
        if (gameObject.activeSelf)
            displayTime -= Time.deltaTime;

        if (displayTime <= 0.0f)
            gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetText( string newText )
    {
        gameObject.GetComponent<TextMesh>().text = newText;
    }

    public void Show()
    {
        displayTime = DISPLAYINTERVAL;
        gameObject.SetActive(true);

    }
}
