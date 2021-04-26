using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class smartPursuer : MonoBehaviour
{

    public float speed;
    private Transform target;
    NavMeshAgent minion;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        minion = GetComponent<NavMeshAgent>();
        minion.updateRotation = false;
        minion.updateUpAxis = false;
    }

    
    void FixedUpdate()
    {
        minion.speed = speed;
        minion.SetDestination(target.position);
    }
}
