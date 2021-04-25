using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lowPursuer : MonoBehaviour
{   
    public float speed;    private Transform target;    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed*Time.deltaTime);
    }
}
