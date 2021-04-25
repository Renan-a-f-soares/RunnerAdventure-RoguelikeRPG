using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuerMove : MonoBehaviour
{
    Animator animator;
    public int pursuerID;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetFloat("ID",pursuerID);
    }

}
