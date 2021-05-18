using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //timer
    public float timeCount;
    public float timeTick = 30;
    
    //Modificadores de dificuldade
    public float spawnRate;
    public int spawnNumber;
    public float levelMod;

    //variaveis de controle de posicionamento
    public Vector3 origin;
    public Vector3 randomPosition;
    public float radius;


    // Controladores do randon
    public int minType;
    public int maxType ;
    public int monsterType;
    

    //Controle de Instanciamento
    public List<GameObject> monster = new List<GameObject>();
    public GameObject lowPursuer;
    public GameObject smartPursuer1;
    public GameObject smartPursuer2;
    
    void Start()
    { 
        monster.Add(lowPursuer);
        monster.Add(smartPursuer1);
        monster.Add(smartPursuer2);
        minType = 0;
        maxType = 1;
        spawnNumber = 0;
        spawnRate = 30;
    }

    // Update is called once per frame
    public void Update()
    {
        //adiciona a diferença para que o contador represente o tempo real
        timeCount += Time.deltaTime;
        SetTime(timeCount);

        // mathf.floor = arredondamento 
        //para que o valores não venham decimais por conta de serem em tempo real

        DifficultLever(Mathf.Floor(timeCount));
        
        if(timeCount > timeTick){
            timeTick += spawnRate;
            SpawnMonster();
        }
    }

    void SpawnMonster(){

        for(int i=0; i < spawnNumber;i++){
            monsterType = Random.Range(minType,maxType);
            Vector3 randomCirclePosition = Random.insideUnitCircle * radius;
            origin = transform.position; // pega a posição do objeto spawner

            //Faz com que o objeto spawner siga o personagem ao andar
            randomPosition = origin + randomCirclePosition;
            Instantiate(monster[monsterType], randomPosition,Quaternion.identity);
        }
   
    }

    void DifficultLever(float roundTime){
        switch(roundTime){
            case 40:
                spawnNumber = 1;
            break;

            case 180: //3
                spawnRate = 25;
                maxType = 3;
                
            break;

            case 300: //5:
                spawnRate = 20;
                spawnNumber = 3;
            break;

            case 360://6
                spawnRate = 18;
                spawnNumber = 2;
            break;

            case 420://7
                spawnRate = 15;
                spawnNumber = 3;
            break;

            case 540://9
                spawnRate = 15;
                spawnNumber = 4;
            break;

            case 600://10
                spawnRate = 30;
                spawnNumber = 10;
            break;

            case 660://11
                spawnRate = 10;
                spawnNumber = 4;
            break;

            case 780://13
                spawnRate = 10;
                spawnNumber = 5;
            break;

            case 900://15
                spawnRate = 8;
                spawnNumber = 5;
            break;

            case 1020://17
                spawnRate = 5;
                spawnNumber = 4;
            break;

            case 1200://20
                spawnRate = 1;
                spawnNumber = 2;
            break;

            default:
            break;
        }
    }
    void SetTime(float defineTime){
        levelMod = Mathf.Round(defineTime);
        
    }

    public float GetTime(){
        Debug.Log("get: " + levelMod);
        return levelMod;
    }


     private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, radius);
    }
}
