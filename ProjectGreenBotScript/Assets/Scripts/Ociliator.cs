using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ociliator : MonoBehaviour
{
    [Header("Movement Parameters")]
    public Transform posStart;
    public Transform posEnd;

    public float speed = 1.0f;
    public float journeyLength = 1.0f;
    private float startTime;

    public bool loop = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!loop)
        {
            float lengthCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = lengthCovered / journeyLength;
            transform.position = Vector3.Lerp(posStart.position, posEnd.position, fractionOfJourney);
        }
        if (loop)
        {
            float lengthCovered = Mathf.PingPong(Time.time - startTime, journeyLength / speed);
            float fractionOfJourney = lengthCovered / journeyLength;
            transform.position = Vector3.Lerp(posStart.position, posEnd.position, fractionOfJourney);
        }
    }
}
