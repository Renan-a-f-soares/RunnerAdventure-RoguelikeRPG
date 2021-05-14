using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEvent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EventController(Collider2D colliderInfo){
        
        switch(colliderInfo.tag){
            case "low_pursuer":
                //Chama script para gerar inimigo e em seguida etrart na batalha
                Debug.LogError(colliderInfo.tag);
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
