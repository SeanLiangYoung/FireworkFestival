using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputControl : MonoBehaviour {

    public GameObject gameController;
    public GameObject launchMgr;
	public GameObject hitWindow;

  
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
		//HitResponse hitResp = hitWindow.GetComponent<HitResponse>();
        GameControl gameCtrl = gameController.GetComponent<GameControl>();
        LauncherManager launchScript = launchMgr.GetComponent<LauncherManager>();

		if( Input.GetButtonDown( "Firework1" ) )
		{
            gameCtrl.PressHitButton(1);
            gameCtrl.CheckLastNote();
            launchScript.LaunchFireworks('A', 1);
		}
		else if( Input.GetButtonUp ( "Firework1" ) )
		{
            gameCtrl.ReleaseHitButton();
		}
        else if (Input.GetButtonDown("Firework2"))
        {
            gameCtrl.PressHitButton(2);
            gameCtrl.CheckLastNote();
            launchScript.LaunchFireworks('S', 1);
        }
        else if (Input.GetButtonUp("Firework2"))
        {
            gameCtrl.ReleaseHitButton();
        }
        else if (Input.GetButtonDown("Firework3"))
        {
            gameCtrl.PressHitButton(3);
            gameCtrl.CheckLastNote();
            launchScript.LaunchFireworks('D', 1);
        }
        else if (Input.GetButtonUp("Firework3"))
        {
            gameCtrl.ReleaseHitButton();
        }
        else if (Input.GetButtonDown("Firework4"))
        {
            gameCtrl.PressHitButton(4);
            gameCtrl.CheckLastNote();
            launchScript.LaunchFireworks('F', 1);
        }
        else if (Input.GetButtonUp("Firework4"))
        {
            gameCtrl.ReleaseHitButton();
        }
        else if (Input.GetButtonDown("Firework5"))
        {
            gameCtrl.PressHitButton(5);
            gameCtrl.CheckLastNote();
            launchScript.LaunchFireworks('J', 1);
        }
        else if (Input.GetButtonUp("Firework5"))
        {
            gameCtrl.ReleaseHitButton();
        }
        else if (Input.GetButtonDown("Firework6"))
        {
            gameCtrl.PressHitButton(6);
            gameCtrl.CheckLastNote();
            launchScript.LaunchFireworks('K', 1);
        }
        else if (Input.GetButtonUp("Firework6"))
        {
            gameCtrl.ReleaseHitButton();
        }
        else if (Input.GetButtonDown("Firework7"))
        {
            gameCtrl.PressHitButton(7);
            gameCtrl.CheckLastNote();
            launchScript.LaunchFireworks('L', 1);
        }
        else if (Input.GetButtonUp("Firework7"))
        {
            gameCtrl.ReleaseHitButton();
        }
        else if (Input.GetButtonDown("Firework8"))
        {
            gameCtrl.PressHitButton(8);
            gameCtrl.CheckLastNote();
            launchScript.LaunchFireworks(';', 1);
        }
        else if (Input.GetButtonUp("Firework8"))
        {
            gameCtrl.ReleaseHitButton();
        }
	}
}
