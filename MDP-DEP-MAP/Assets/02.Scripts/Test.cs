using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR;

public class Test : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent navAgent;

    public void Update()
    {
        navAgent.SetDestination(target.position);
    }
}
