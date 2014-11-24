using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour {
	public string sceneName;

	public string songName;

	private TextMesh _textMesh;

	private Color _originalColor;
	// Use this for initialization
	void Start () {
		_textMesh = gameObject.GetComponent<TextMesh>() as TextMesh;
		_originalColor = _textMesh.color;
	
	}
	void OnMouseEnter () {
		_textMesh.color = Color.blue;
	}
	void OnMouseDown () {
		//USE TWEEN HERE
		gameObject.transform.localScale = .8f * gameObject.transform.localScale;
	}
	void OnMouseUp () {
		//ANOTHER TWEEN
		gameObject.transform.localScale = 1.25f * gameObject.transform.localScale;
	}
	void OnMouseExit () {
		_textMesh.color = _originalColor;
	}

	
	void OnMouseUpAsButton () {
		if (!string.IsNullOrEmpty(songName)) {
			SceneProperties.currentSongName=songName;
		}
		Application.LoadLevel (sceneName); 
	}
	// Update is called once per frame
	void Update () {
	
	}
}
