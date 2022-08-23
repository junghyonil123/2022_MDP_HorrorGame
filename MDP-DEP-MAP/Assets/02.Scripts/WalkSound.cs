using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkSound : MonoBehaviour
{
    AudioSource audio;

    Vector3 lastPos;
    Vector3 nowPos;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        lastPos = transform.position;
    }

    void Update()
    {
        nowPos = transform.position;

        if(lastPos - nowPos != Vector3.zero)
        {
            if (!audio.isPlaying)
            audio.Play();
        }
        else if(lastPos - nowPos == Vector3.zero)
        {
            audio.Stop();
        }

        lastPos = nowPos;
    }
}
