using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Key1Action : MonoBehaviour
{
    public GameObject key1Light;
    public GameObject Key1Enemi;

    public bool is_tricked = true;

    public void CatchKey()
    {
        if (is_tricked)
        {
            is_tricked = false;
            key1Light.SetActive(true);
            key1Light.GetComponent<AudioSource>().Play();
            Key1Enemi.GetComponent<Animator>().SetBool("CatchKey", true);
            HeadLotate.instance.StartCoroutine("FollowTarget");
        }
    }
}
