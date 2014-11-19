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

    // Use this for initialization
    void Start()
    {
        //elapsedTime = genInterval;
        notes = new LinkedList<GameObject>();
        beatDurations = BeatCreator.instance.beatDurations;

        currentBeatIdx = 0;

        elapsedTime = beatDurations[currentBeatIdx++];

    }

    void FixedUpdate()
    {
        elapsedTime -= Time.deltaTime;
        if (elapsedTime <= 0.0)
        {
            //elapsedTime = genInterval;
            elapsedTime = beatDurations[currentBeatIdx++];

            //if (currentBeatIdx % 20 == 0)
            {
                if (Random.value < 0.5)
                    SpawnNote(1);
                else
                    SpawnNote(2);
               
            }
        }

    }

    // Update is called once per frame
    void Update()
    {


    }

    void SpawnNote(int type)
    {
        GameObject aNote;
        if (type == 1)
            aNote = GameObject.Instantiate(noteType1) as GameObject;
        else
            aNote = GameObject.Instantiate(noteType2) as GameObject;

        aNote.transform.position = new Vector3(10.0f, 0.0f, 0.0f);

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


    public void CheckLastNote()
    {
        HitResponse hitResp = hitWindow.GetComponent<HitResponse>();
        Vector3 hitPosition = hitWindow.transform.position;

        //Get the leftmost note, if available
        LinkedListNode<GameObject> aNote = notes.First;
        if (aNote != null)
        {
            Note noteScript = aNote.Value.GetComponent<Note>();


            if (Mathf.Abs(hitPosition.x - aNote.Value.transform.position.x) <= hitMargin )
            {
                hitResp.PlayHitEffect();
                ++comboCount;
            }
            else
                comboCount = 0;
            notes.RemoveFirst();
            noteScript.Die();
        }

    }
}
