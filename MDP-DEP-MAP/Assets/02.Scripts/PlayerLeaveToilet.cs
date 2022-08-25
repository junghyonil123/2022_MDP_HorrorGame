using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLeaveToilet : MonoBehaviour
{
    public GameObject ghostGirl;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && other && Key2Action.instanse.isTricked)
        {
            ghostGirl.GetComponent<Enemy>().navgo();
        }
       
    }
}
