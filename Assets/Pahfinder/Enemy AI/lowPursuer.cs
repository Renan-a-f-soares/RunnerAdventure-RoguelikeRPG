using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class lowPursuer : MonoBehaviour
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
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed*Time.deltaTime);
    }
}
