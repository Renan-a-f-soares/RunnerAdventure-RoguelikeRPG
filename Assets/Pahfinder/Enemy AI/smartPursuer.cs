using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class smartPursuer : MonoBehaviour
{

    public float speed;
     public float distance;
    public float reach;                                          
    public float squareReach;
    private Transform target;
    NavMeshAgent minion;
    void Start()
    {
        reach = 15f;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        minion = GetComponent<NavMeshAgent>();
        minion.updateRotation = false;
        minion.updateUpAxis = false;
    }

    
    void FixedUpdate()
    {
        minion.speed = speed;
        // Um calculo melhorado de distancia entre objetos 
        squareReach = reach*reach;
        distance = (transform.position - target.position).sqrMagnitude;
        if(distance < squareReach){
            minion.SetDestination(target.position);
        }
    }
}
