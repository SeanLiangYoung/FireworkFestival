using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameControl : MonoBehaviour
{

    public GameObject noteType1;
    public GameObject noteType2;
    public GameObject hitWindow;

    const float genInterval = 0.5f;
    float elapsedTime;

    LinkedList<GameObject> notes;

    // Use this for initialization
    void Start()
    {
        elapsedTime = genInterval;
        notes = new LinkedList<GameObject>();
    }

    void FixedUpdate()
    {
        elapsedTime -= Time.deltaTime;
        if (elapsedTime <= 0.0)
        {
            elapsedTime = genInterval;

            //Create a note in 50% chance
            if (Random.value < 0.5)
            {
                if (Random.value < 0.5)
                    spawnNote(1);
                else
                    spawnNote(2);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {


    }

    void spawnNote(int type)
    {
        GameObject aNote;
        if (type == 1)
            aNote = GameObject.Instantiate(noteType1) as GameObject;
        else
            aNote = GameObject.Instantiate(noteType2) as GameObject;

        aNote.transform.position = new Vector3(10.0f, 0.0f, 0.0f);

        notes.AddLast(aNote);
    }

    public void checkLastNote(  )
    {
        Vector3 hitPosition = hitWindow.transform.position;

        LinkedListNode<GameObject> aNote = notes.First;
        if (aNote != null)
        {
            Note noteScript = aNote.Value.GetComponent<Note>();
            notes.RemoveFirst();

            noteScript.Die();
            //if ( Mathf.Abs(hitPosition.x - aNote.Value.transform.position.x) <= 0.01f)
            //{

                
            //}
        }

    }
}
