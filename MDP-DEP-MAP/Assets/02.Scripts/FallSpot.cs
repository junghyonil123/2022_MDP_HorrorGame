using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallSpot : MonoBehaviour
{
    public GameObject fallObj;
    public AudioSource audio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            fallObj.SetActive(true);
        }
    }
}
