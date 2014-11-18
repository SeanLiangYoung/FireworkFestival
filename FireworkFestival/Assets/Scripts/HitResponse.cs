using UnityEngine;
using System.Collections;

public class HitResponse : MonoBehaviour {

	enum Status{ PRESS, PRESSING, RELEASE };
	Status stat;

	Vector3 scale;

    const float animateTime = 0.1f;
    float animateElapsed; 

	// Use this for initialization
	void Start () {
	
		stat = Status.RELEASE;
		scale = gameObject.transform.localScale;

        animateElapsed = animateTime;
	}
	
	// Update is called once per frame
	void Update () {
	
        if( stat == Status.PRESS )
        {
            animateElapsed -= Time.deltaTime;
            if (animateElapsed <= 0.0f)
            {
                stat = Status.PRESSING;
                gameObject.transform.localScale = scale;
            }
        }
	}

	public void Hit()
	{
	    if( stat == Status.RELEASE )
		{
			stat = Status.PRESS;
			gameObject.transform.localScale = scale*0.9f;
		}
    }

	public void Release()
	{
		if( stat != Status.RELEASE )
		{
			stat = Status.RELEASE;
			gameObject.transform.localScale = scale;

            animateElapsed = animateTime;
		}
	}
}
