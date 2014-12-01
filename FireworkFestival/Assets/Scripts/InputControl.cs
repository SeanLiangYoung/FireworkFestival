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

        uint combo = 0;
		if( Input.GetButtonDown( "Firework1" ) )
		{
            gameCtrl.PressHitButton(1);
            if( (combo = gameCtrl.CheckLastNote()) > 0 )
                launchScript.LaunchFireworks('A', (int)combo/3+1 );
		}
		else if( Input.GetButtonUp ( "Firework1" ) )
		{
            gameCtrl.ReleaseHitButton();
		}
        else if (Input.GetButtonDown("Firework2"))
        {
            gameCtrl.PressHitButton(2);
            if ((combo = gameCtrl.CheckLastNote()) > 0)
                launchScript.LaunchFireworks('S', (int)combo / 3 + 1 );
        }
        else if (Input.GetButtonUp("Firework2"))
        {
            gameCtrl.ReleaseHitButton();
        }
        else if (Input.GetButtonDown("Firework3"))
        {
            gameCtrl.PressHitButton(3);
            if ((combo = gameCtrl.CheckLastNote()) > 0)
                launchScript.LaunchFireworks('D', (int)combo / 3 + 1);
        }
        else if (Input.GetButtonUp("Firework3"))
        {
            gameCtrl.ReleaseHitButton();
        }
        else if (Input.GetButtonDown("Firework4"))
        {
            gameCtrl.PressHitButton(4);
            if ((combo = gameCtrl.CheckLastNote()) > 0 )
                launchScript.LaunchFireworks('F', (int)combo / 3 + 1);
        }
        else if (Input.GetButtonUp("Firework4"))
        {
            gameCtrl.ReleaseHitButton();
        }
        else if (Input.GetButtonDown("Firework5"))
        {
            gameCtrl.PressHitButton(5);
            if ((combo = gameCtrl.CheckLastNote()) > 0)
                launchScript.LaunchFireworks('J', (int)combo / 3 + 1);
        }
        else if (Input.GetButtonUp("Firework5"))
        {
            gameCtrl.ReleaseHitButton();
        }
        else if (Input.GetButtonDown("Firework6"))
        {
            gameCtrl.PressHitButton(6);
            if ((combo = gameCtrl.CheckLastNote()) > 0)
                launchScript.LaunchFireworks('K', (int)combo / 3 + 1);
        }
        else if (Input.GetButtonUp("Firework6"))
        {
            gameCtrl.ReleaseHitButton();
        }
        else if (Input.GetButtonDown("Firework7"))
        {
            gameCtrl.PressHitButton(7);
            if ((combo = gameCtrl.CheckLastNote()) > 0)
                launchScript.LaunchFireworks('L', (int)combo / 3 + 1);
        }
        else if (Input.GetButtonUp("Firework7"))
        {
            gameCtrl.ReleaseHitButton();
        }
        else if (Input.GetButtonDown("Firework8"))
        {
            gameCtrl.PressHitButton(8);
            if ((combo = gameCtrl.CheckLastNote()) > 0)
                launchScript.LaunchFireworks(';', (int)combo / 3 + 1);
        }
        else if (Input.GetButtonUp("Firework8"))
        {
            gameCtrl.ReleaseHitButton();
        }
	}
}
