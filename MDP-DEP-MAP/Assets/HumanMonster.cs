using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMonster : MonoBehaviour
{
    public Transform target;

    private void Update()
    {
        transform.LookAt(new Vector3(target.position.x , transform.position.y, transform.position.z));
    }
}
