using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameControl : MonoBehaviour
{
    enum NOTETYPE { SINGLE, CONTINUOUS };

    public Note[] noteTypes;
    

    public GameObject hitWindow;

    public GameObject comboValueText;
    public GameObject comboText;
    public GameObject scoreText;
    public GameObject gameoverText;
    public GameObject hitIndicateText;

    public float hitMargin;
    public float goodHitMargin;
    public float greatHitMargin;


    const float genInterval = 0.5f;
    float elapsedTime;
    float gameOverTime = 2.0f;
    float gameOverElapsedTime;

    LinkedList<Note> notes;

    List<float> beatDurations;

    int currentBeatIdx;
    uint comboCount;
    uint score;

    int numBeatDuration;

    bool bStartPlayback = false;
    bool bGameOver = false;
	bool levelLoaded = false;

    NOTETYPE currentNoteType;

    // Use this for initialization
    void Start()
    {
        //elapsedTime = genInterval;
        notes = new LinkedList<Note>();
//        beatDurations = BeatCreator.instance.beatDurations;
//
//        currentBeatIdx = 0;
//
//        elapsedTime = beatDurations[currentBeatIdx++];
        currentNoteType = NOTETYPE.SINGLE;
        comboText.GetComponent<TextMesh>().text = "";
        comboValueText.GetComponent<TextMesh>().text = "";
		StartCoroutine ("StartGame");
        
    }

	public IEnumerator StartGame () {
		yield return new WaitForSeconds(.5f);

        currentBeatIdx = 0;
		BeatCreator.Instance.CreateBeats();
		
		beatDurations = BeatCreator.Instance.beatDurations;
        numBeatDuration = beatDurations.Count;
		elapsedTime = beatDurations[currentBeatIdx++];
		levelLoaded = true;
		bStartPlayback = true;
		//BeatCreator.instance.PlaySong();

	}


	private float _startSongDelay = 1.8f;
	private float _startAdjustment = 1000.0f;
	private bool _songStarted = false;
    void Update()
    {
        if (bGameOver)
        {
            gameOverElapsedTime -= Time.deltaTime;
            if (gameOverElapsedTime <= 0)
            {
                //Jump to score ranking scene
                Application.LoadLevel("scoreRank");
            }
        }
        else if (levelLoaded)
        {
			if (!_songStarted && Time.time - _startAdjustment >= _startSongDelay) {
				BeatCreator.instance.PlaySong();
				_songStarted = true;
			}
			elapsedTime -= Time.deltaTime;
            if (elapsedTime <= 0.0 )
            {
                if (currentBeatIdx < numBeatDuration)
                    elapsedTime += beatDurations[currentBeatIdx++];
                else
                    bGameOver = true;

                //if (Random.value < 0.5)
                //    SpawnNote(0, new Vector3(15.0f, 0.0f, 0.0f));
                //else
                //    SpawnNote(1, new Vector3(15.0f, 0.0f, 0.0f));
					Note aNote = SpawnNote( Random.Range(0,noteTypes.Length-1), new Vector3(15.0f, 0.0f, 0.0f));
				//LauncherManager.Instance.LaunchFireworks('A', 2, 4);
				LauncherManager.Instance.LaunchFireworks(1, 1, aNote );
				
				if (currentBeatIdx==2) {
					_startAdjustment = Time.time;

					//StartCoroutine("playSongWithDelay");
				}


                //Randomly set the note mode to single or continuous
                if (currentNoteType == NOTETYPE.SINGLE)
                {
                    if (Random.value < 0.1f)
                        currentNoteType = NOTETYPE.CONTINUOUS;
                }
                else
                {

                }
            }

            CheckMissed();

            /*if( !bStartPlayback )
                CheckPlayback();*/
        }
    }



    void CheckMissed()
    {
        while (true)
        {
            LinkedListNode<Note> aNote = notes.First;
            if (aNote != null)
            {
                if (aNote.Value.GetElapsedTime(Time.time) >= 1.9f) //TODO FIX FOR NEW THING
                {
                    //Note noteScript = aNote.Value.GetComponent<Note>();
					notes.RemoveFirst();//(aNote);
                    //Destroy(aNote.Value);
					
					//Note noteScript = aNote.Value.GetComponent<Note>();
					aNote.Value.Disappear(true);
                }
                else break;
            }
            else
                break;

        }
    }

    void CheckPlayback()
    {
        LinkedListNode<Note> aNote = notes.First;
        if (aNote != null)
        {
            Vector3 hitPosition = hitWindow.transform.position;
            if ( hitPosition.x >= aNote.Value.transform.position.x-.8f )
            {
                bStartPlayback = true;
                //BeatCreator.instance.PlaySong();
				StartCoroutine("playSongWithDelay");
            }
        }
    }

	private IEnumerator playSongWithDelay () {
		float MAX_DELAY = 2.0f;
		yield return new WaitForSeconds(MAX_DELAY);
		BeatCreator.instance.PlaySong();

	}
    Note SpawnNote(int type, Vector3 pos)
    {
        Note aNote;

        aNote = GameObject.Instantiate(noteTypes[type]) as Note;

        aNote.transform.position = pos;
        aNote.GetComponent<Note>().Type = type;
        notes.AddLast(aNote);
		aNote.startTime = Time.time;
		return aNote;
    }

    public void PressHitButton( int no )
    {
        if (!bGameOver)
        {
            HitResponse hitResp = hitWindow.GetComponent<HitResponse>();
            hitResp.Hit();
        }
    }

    public void ReleaseHitButton()
    {
        HitResponse hitResp = hitWindow.GetComponent<HitResponse>();
        hitResp.Release();
    }


    public uint CheckLastNote( int key )
    {
        if (bGameOver)
            return 0;
        
        bool isHit = false;
        uint hitLevel = 0;
        HitResponse hitResp = hitWindow.GetComponent<HitResponse>();
        Vector3 hitPosition = hitWindow.transform.position;
        GUIController guiController = gameObject.GetComponent<GUIController>();

        //Get the leftmost note, if available
        LinkedListNode<Note> aNote = notes.First;
        while (aNote != null && aNote.Value!= null)
        {
            Note noteScript = aNote.Value.GetComponent<Note>();

            //if (noteScript.Type != key)
            //    continue;
                
            float hitDiff = noteScript.GetHitDiff(Time.time);//= Mathf.Abs(hitPosition.x - aNote.Value.transform.position.x); // TODO
            if ( hitDiff <= hitMargin )
            {
                if (hitDiff <= greatHitMargin)
                {
                    hitIndicateText.GetComponent<hitIndicate>().Show("Great");
                    hitLevel = 3;
                }
                else if (hitDiff <= goodHitMargin)
                {
                    hitIndicateText.GetComponent<hitIndicate>().Show("Good");
                    hitLevel = 2;
                }
                else
                {
                    hitIndicateText.GetComponent<hitIndicate>().Show("OK");
                    hitLevel = 1;
                }

                hitResp.PlayHitEffect();
                isHit = true;

                notes.Remove(aNote);
                //noteScript.Die();
				aNote.Value.Disappear(false);
				aNote.Value.launcher.TriggerExplosion();
                break;
            }
   
            aNote = aNote.Next;
        }
        if (!isHit)
        {
            comboCount = 0;
            comboText.GetComponent<TextMesh>().text = "";

            hitIndicateText.GetComponent<hitIndicate>().Show("Miss");

            guiController.IncreLiveBar(-1);

            if (guiController.IsLiveZero())
            {
                bGameOver = true;

                gameoverText.SetActive(true);
                gameOverElapsedTime = gameOverTime;

                SaveHighScore();
            }
        }
        else
        {
            ++comboCount;
            score += 100 * (1+comboCount);
            scoreText.GetComponent<TextMesh>().text = "Score:" + score;
            comboText.GetComponent<TextMesh>().text = "HIT:"+comboCount;

            //Show special text to indicate 
            //the player 5x combo has reached
            if (comboCount % 5 == 0)
            {
                comboValueText.GetComponent<ComboValue>().SetText( comboCount.ToString()+"x Bonus");
                comboValueText.GetComponent<ComboValue>().Show();
            }

            guiController.IncreLiveBar(1);
        }

        return hitLevel;
    }

    void SaveHighScore()
    {
        int highscore1 = PlayerPrefs.GetInt("HG1");
        int highscore2 = PlayerPrefs.GetInt("HG2");
        int highscore3 = PlayerPrefs.GetInt("HG3");

        if (score > highscore1)
        {
            highscore3 = highscore2;
            highscore2 = highscore1;
            highscore1 = (int)score;
        }
        else if (score > highscore2)
        {
            highscore3 = highscore2;
            highscore2 = (int)score;
        }
        else if (score > highscore3 )
        {
            highscore3 = (int)score;
        }

        PlayerPrefs.SetInt("HG1", highscore1);
        PlayerPrefs.SetInt("HG2", highscore2);
        PlayerPrefs.SetInt("HG3", highscore3);

        PlayerPrefs.Save();
    }
}
