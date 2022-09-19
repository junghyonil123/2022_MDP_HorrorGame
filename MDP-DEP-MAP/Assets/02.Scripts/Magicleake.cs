using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Magicleake : MonoBehaviour
{
    int keyCount = 0;
    public Transform endingPos;
    public Transform playerPos;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Key1")
        {

            if (!GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().Play();
            }
            keyCount += 1;
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.CompareTag("Key"))
        {
            if (!GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().Play();
            }
            keyCount += 1;
            Destroy(collision.gameObject);

        }
        
    }

    private void Update()
    {
        if (keyCount == 4)
        {
            keyCount = 0;
            playerPos.position = endingPos.position; 
        }
    }
}
