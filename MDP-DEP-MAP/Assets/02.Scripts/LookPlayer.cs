using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookPlayer : MonoBehaviour
{

    public Transform playerTransform;
    public Vector3 targetTransform;

    void Update()
    {
        targetTransform = new Vector3(playerTransform.position.x , transform.position.y, playerTransform.position.z);
        transform.LookAt(targetTransform);
    }
}
