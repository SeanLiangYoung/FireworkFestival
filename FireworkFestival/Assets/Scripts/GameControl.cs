using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameControl : MonoBehaviour
{

    public GameObject noteType1;
    public GameObject noteType2;
    public GameObject hitWindow;

    public GameObject comboText;

    public float hitMargin;

    const float genInterval = 0.5f;
    float elapsedTime;

    LinkedList<GameObject> notes;

    List<float> beatDurations;

    int currentBeatIdx;
    uint comboCount;

    bool bStartPlayback = false;
    // Use this for initialization
    void Start()
    {
        //elapsedTime = genInterval;
        notes = new LinkedList<GameObject>();
        beatDurations = BeatCreator.instance.beatDurations;

        currentBeatIdx = 0;

        elapsedTime = beatDurations[currentBeatIdx++];

        comboText.GetComponent<TextMesh>().text = "";
    }

    void Update()
    {
        elapsedTime -= Time.deltaTime;
        if (elapsedTime <= 0.0)
        {
            //elapsedTime = genInterval;
            elapsedTime = beatDurations[currentBeatIdx++];
             
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
            if ( hitPosition.x >= aNote.Value.transform.position.x-0.05f )
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
        HitResponse hitResp = hitWindow.GetComponent<HitResponse>();
        hitResp.Hit();
    }

    public void ReleaseHitButton()
    {
        HitResponse hitResp = hitWindow.GetComponent<HitResponse>();
        hitResp.Release();
    }


    public bool CheckLastNote()
    {
        
        bool isHit = false;
        HitResponse hitResp = hitWindow.GetComponent<HitResponse>();
        Vector3 hitPosition = hitWindow.transform.position;

        //Get the leftmost note, if available
        LinkedListNode<GameObject> aNote = notes.First;
        while (aNote != null)
        {
            Note noteScript = aNote.Value.GetComponent<Note>();


            if (Mathf.Abs(hitPosition.x - aNote.Value.transform.position.x) <= hitMargin )
            {
                hitResp.PlayHitEffect();
                ++comboCount;
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
            comboText.GetComponent<TextMesh>().text = "Break!";
        }
        else
            comboText.GetComponent<TextMesh>().text = "Combo:" + comboCount;


        return isHit;
    }
}
