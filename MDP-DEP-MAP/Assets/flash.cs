using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class flash : MonoBehaviour
{ 
    BoxCollider col;
    Enemy enemy;

    public bool turn_on = false;

    float timer;

    int waitingTime;

    void Awake()
    {
        col = GetComponent<BoxCollider>();
        enemy = FindObjectOfType<Enemy>();
    }

    private void Start()
    {
        timer = 0f;
        waitingTime = 1;
    }

    private void Update()
    {
        //gameObject.SetActive(turn_on);
        //if (turn_on)
        //{
        //    timer += Time.deltaTime;
        //    if (timer > waitingTime)
        //    {
        //        timer = 0;
        //        turn_on = false;
        //    }
        //}
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "enemy")
        {
            enemy.stun = true;
        }
    }


}
