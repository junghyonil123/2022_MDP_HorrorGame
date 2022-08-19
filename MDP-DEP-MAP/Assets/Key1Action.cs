using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Key1Action : MonoBehaviour
{
    public GameObject key1Light;
    public GameObject Key1Enemi;

    public void CatchKey()
    {
        key1Light.SetActive(true);
        key1Light.GetComponent<AudioSource>().Play();
        Key1Enemi.GetComponent<Animator>().SetBool("CatchKey", true);
    }


    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
}
