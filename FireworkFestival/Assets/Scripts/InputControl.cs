using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputControl : MonoBehaviour {

    public GameObject gameController;
	public GameObject hitWindow;

  
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
		HitResponse hitResp = hitWindow.GetComponent<HitResponse>();

		if( Input.GetButtonDown( "Fire1" ) )
		{
			hitResp.Hit ();

            GameControl gameCtrl = gameController.GetComponent<GameControl>();
            gameCtrl.checkLastNote();
		}
		else if( Input.GetButtonUp ( "Fire1" ) )
		{
			hitResp.Release();
		}
	}
}
