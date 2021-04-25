using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class smartPursuer : MonoBehaviour
{

    public float speed;
    [SerializeField] Transform target;
    NavMeshAgent minion;
    void Start()
    {
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
