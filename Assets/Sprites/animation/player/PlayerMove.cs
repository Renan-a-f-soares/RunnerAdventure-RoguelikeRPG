using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float charSpeed;
    int speed;
    public Rigidbody2D rbody;

    public int rndMonster;
    //instancia do modulo de animação
    Animator animator;
    Vector2 movement;
    RandonGenerator rnd;

    void Start()
    {
        animator = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody2D>();
        rnd =  gameObject.AddComponent<RandonGenerator>();
    }

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

   void OnTriggerEnter2D(Collider2D colliderInfo)
    {
        switch(colliderInfo.tag){
            case "low_enemy":
               // RandonGenerator rnd = gameObject.AddComponent<RandonGenerator>();
                
                //Chama script para gerar inimigo e em seguida etrart na batalha
                rnd.SetEnemyInfo(colliderInfo);
                rndMonster = rnd.RandonMonsterID();
                Debug.Log("Monstro: " + rndMonster);
                //selecionar inimigo e alterar seus status

            
            break;
            case "exp_ball":
                //Exclui o objeto do mapa
                //Aumenta o valor do  Status.EXP do Jogador
                //Chama script que contem os calculos de proximo nivel e atualização dos status
                Debug.Log(colliderInfo.tag);
            break;
            case "chest":
                Debug.Log(colliderInfo.tag);
            break;
            default:
            break;
        }
    }

}
