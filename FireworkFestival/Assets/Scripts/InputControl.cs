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

    void OnLevelWasLoaded(int level)
    {
        if (level == 4) //Game level 1
        {
            int[] firework_types = new int[8];
            LauncherManager launchScript = launchMgr.GetComponent<LauncherManager>();

            for (int i = 0; i < 8; ++i)
            {
                firework_types[i] = PlayerPrefs.GetInt(i.ToString());
                launchScript.SetFireworkType(i, firework_types[i]);
            }

        }
    }
	
	// Update is called once per frame
	void Update () {
		
		//HitResponse hitResp = hitWindow.GetComponent<HitResponse>();
        GameControl gameCtrl = gameController.GetComponent<GameControl>();
        //LauncherManager launchScript = launchMgr.GetComponent<LauncherManager>();

        uint heightLv = 1;
		if( Input.GetButtonDown( "Firework1" ) )
		{
            gameCtrl.PressHitButton(1);
            if( (heightLv = gameCtrl.CheckLastNote(0)) > 0 ) {
                //LauncherManager.Instance.LaunchFireworks('A', 2, (int)heightLv);
			}
		}
		else if( Input.GetButtonUp ( "Firework1" ) )
		{
            gameCtrl.ReleaseHitButton();
		}
        else if (Input.GetButtonDown("Firework2"))
        {
            gameCtrl.PressHitButton(2);
            if ((heightLv = gameCtrl.CheckLastNote(1)) > 0){
				//LauncherManager.Instance.LaunchFireworks('S', 2, (int)heightLv );
			}
        }
        else if (Input.GetButtonUp("Firework2"))
        {
            gameCtrl.ReleaseHitButton();
        }
        else if (Input.GetButtonDown("Firework3"))
        {
            gameCtrl.PressHitButton(3);
            if ((heightLv = gameCtrl.CheckLastNote(2)) > 0) {
				//LauncherManager.Instance.LaunchFireworks('D', 2, (int)heightLv);
			}
        }
        else if (Input.GetButtonUp("Firework3"))
        {
            gameCtrl.ReleaseHitButton();
        }
        else if (Input.GetButtonDown("Firework4"))
        {
            gameCtrl.PressHitButton(4);
            if ((heightLv = gameCtrl.CheckLastNote(3)) > 0 ) {
				//LauncherManager.Instance.LaunchFireworks('F', 2, (int)heightLv );
			}
        }
        else if (Input.GetButtonUp("Firework4"))
        {
            gameCtrl.ReleaseHitButton();
        }
        else if (Input.GetButtonDown("Firework5"))
        {
            gameCtrl.PressHitButton(5);
            if ((heightLv = gameCtrl.CheckLastNote(4)) > 0){
				//LauncherManager.Instance.LaunchFireworks('J', 2, (int)heightLv );
			}
        }
        else if (Input.GetButtonUp("Firework5"))
        {
            gameCtrl.ReleaseHitButton();
        }
        else if (Input.GetButtonDown("Firework6"))
        {
            gameCtrl.PressHitButton(6);
            if ((heightLv = gameCtrl.CheckLastNote(5)) > 0){
				//LauncherManager.Instance.LaunchFireworks('K', 2, (int)heightLv );
			}
        }
        else if (Input.GetButtonUp("Firework6"))
        {
            gameCtrl.ReleaseHitButton();
        }
        else if (Input.GetButtonDown("Firework7"))
        {
            gameCtrl.PressHitButton(7);
            if ((heightLv = gameCtrl.CheckLastNote(6)) > 0) {
				//LauncherManager.Instance.LaunchFireworks('L', 2, (int)heightLv );
			}
        }
        else if (Input.GetButtonUp("Firework7"))
        {
            gameCtrl.ReleaseHitButton();
        }
        else if (Input.GetButtonDown("Firework8"))
        {
            gameCtrl.PressHitButton(8);
            if ((heightLv = gameCtrl.CheckLastNote(7)) > 0) {
				//LauncherManager.Instance.LaunchFireworks(';', 2, (int)heightLv );
			}
        }
        else if (Input.GetButtonUp("Firework8"))
        {
            gameCtrl.ReleaseHitButton();
        }
	}
}
