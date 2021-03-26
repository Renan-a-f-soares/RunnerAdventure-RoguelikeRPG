using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //start
    public float charSpeed = 20f;
    int speed;
    public Rigidbody2D rbody;
    //instancia do modole de animação
    Animator animator;

    Vector2 movement;
    


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
    }

    void FixedUpdate()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);

        //verifica se esta parado
        if(movement.x != 0 | movement.y != 0)
        {
            speed = 1;
        }
        else
        {
            speed = 0;
        }
        animator.SetFloat("speed", speed);
        
        
        

        rbody.MovePosition(rbody.position + movement * charSpeed * Time.fixedDeltaTime);
    }


    //end
}
