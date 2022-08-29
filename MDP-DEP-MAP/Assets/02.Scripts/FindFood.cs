using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindFood : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Dog")
        {
            GameObject.Find("Dog").GetComponent<Key1Monster>().target = transform;
        }
    }
}
