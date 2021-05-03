using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPursuer : MonoBehaviour
{
    public float speed; 
    public float distance;
    public float reach;
    public float squareReach;
    private Transform target;    
    void Start()
    {
        reach = 15f;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    
    void FixedUpdate()
    {
        
        // Um calculo melhorado de distancia entre objetos 
        squareReach = reach*reach;
        distance = (transform.position - target.position).sqrMagnitude;
        if(distance < squareReach){
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed*Time.deltaTime);
        }
        
    }
}
