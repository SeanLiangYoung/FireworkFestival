using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameControl : MonoBehaviour
{

    public GameObject noteType1;
    public GameObject noteType2;
    public GameObject hitWindow;

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

    LinkedList<GameObject> notes;

    List<float> beatDurations;

    int currentBeatIdx;
    uint comboCount;
    uint score;

    bool bStartPlayback = false;
    bool bGameOver = false;
	bool levelLoaded = false;
    // Use this for initialization
    void Start()
    {
        //elapsedTime = genInterval;
        notes = new LinkedList<GameObject>();
//        beatDurations = BeatCreator.instance.beatDurations;
//
//        currentBeatIdx = 0;
//
//        elapsedTime = beatDurations[currentBeatIdx++];

        comboText.GetComponent<TextMesh>().text = "";
		StartCoroutine ("StartGame");

    }

	public IEnumerator StartGame () {
		yield return new WaitForSeconds(.5f);

        currentBeatIdx = 0;
		BeatCreator.Instance.CreateBeats();
		
		beatDurations = BeatCreator.Instance.beatDurations;
		elapsedTime = beatDurations[currentBeatIdx++];
		levelLoaded = true;

	}

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
            elapsedTime -= Time.deltaTime;
            if (elapsedTime <= 0.0 )
            {
                //elapsedTime = genInterval;
                elapsedTime += beatDurations[currentBeatIdx++];
             
                //if (currentBeatIdx % 20 == 0)
                {
                    if (Random.value < 0.5)
                        SpawnNote(1, new Vector3(15.0f, 0.0f, 0.0f));
                    else
                        SpawnNote(2, new Vector3(15.0f, 0.0f, 0.0f));
               
                }
            }

            CheckMissed();

            if( !bStartPlayback )
                CheckPlayback();
        }
    }

    void CheckMissed()
    {
        while (true)
        {
            LinkedListNode<GameObject> aNote = notes.First;
            if (aNote != null)
            {
                if (aNote.Value.transform.position.x < -25.0f)
                {
                    //Note noteScript = aNote.Value.GetComponent<Note>();
                    notes.RemoveFirst();
                    Destroy(aNote.Value);
                }
                else break;
            }
            else
                break;

        }
    }

    void CheckPlayback()
    {
        LinkedListNode<GameObject> aNote = notes.First;
        if (aNote != null)
        {
            Vector3 hitPosition = hitWindow.transform.position;
            if ( hitPosition.x >= aNote.Value.transform.position.x-.8f )
            {
                bStartPlayback = true;
                BeatCreator.instance.PlaySong();
            }
        }
    }

    void SpawnNote(int type, Vector3 pos)
    {
        GameObject aNote;
        if (type == 1)
            aNote = GameObject.Instantiate(noteType1) as GameObject;
        else
            aNote = GameObject.Instantiate(noteType2) as GameObject;

        aNote.transform.position = pos;

        notes.AddLast(aNote);
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


    public bool CheckLastNote()
    {
        if (bGameOver)
            return false;
        
        bool isHit = false;
        HitResponse hitResp = hitWindow.GetComponent<HitResponse>();
        Vector3 hitPosition = hitWindow.transform.position;
        GUIController guiController = gameObject.GetComponent<GUIController>();

        //Get the leftmost note, if available
        LinkedListNode<GameObject> aNote = notes.First;
        while (aNote != null)
        {
            Note noteScript = aNote.Value.GetComponent<Note>();

            float hitDiff = Mathf.Abs(hitPosition.x - aNote.Value.transform.position.x);
            if ( hitDiff <= hitMargin )
            {
                if (hitDiff <= greatHitMargin)
                    hitIndicateText.GetComponent<hitIndicate>().Show("Great");
                else if (hitDiff <= goodHitMargin)
                    hitIndicateText.GetComponent<hitIndicate>().Show("Good");
                else
                    hitIndicateText.GetComponent<hitIndicate>().Show("OK");

                hitResp.PlayHitEffect();
                isHit = true;

                notes.Remove(aNote);
                noteScript.Die();
                break;
            }
   
            aNote = aNote.Next;
        }
        if (!isHit)
        {
            comboCount = 0;
            comboText.GetComponent<TextMesh>().text = "0";
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
            comboText.GetComponent<TextMesh>().text = ""+comboCount;
            guiController.IncreLiveBar(1);
        }

        return isHit;
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
