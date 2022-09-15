using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindFood : MonoBehaviour
{
    Key1Monster _dog;
    public GameObject brain;
    public bool isTouched = false;

    public void Touched()
    {
        isTouched = true;
    }

    private void Awake()
    {
        _dog = GameObject.Find("Dog").GetComponent<Key1Monster>();
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Dog" && _dog.isCanFindFood && isTouched)
        {
            _dog.isCanFindFood = false;
            _dog.target = brain.transform;
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
        }

    }

}