using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //resolver Bug DO spawn não dinamico

    //timer
    public float timeCount;
    public float timeTick = 30;
    public List<float> DangerUP = new List<float>();
    public float spawnRate;
    public int spawnNumber;
    int i;

    //variaveis de controle de posicionamento
    public Vector3 origin;
    public Vector3 randomPosition;


    // Controladores do randon
    public int minStrength = 1;
    public int maxStrength = 2;
    public int monsterType;

    //prefabs a serem instanciados
    public GameObject lowPursuer;
    public float radius;
    void Start()
    {
        spawnNumber = 0;
        spawnRate = 30;
    }

    // Update is called once per frame
    void Update()
    {
        //adiciona a diferença para que o contador represente o tempo real
        timeCount += Time.deltaTime;
        // mathf.floor = arredondamento 
        //para que o valores não venham decimais por conta de serem em tempo real
        switch(Mathf.Floor(timeCount)){
            case 40:
                spawnNumber = 1;
            break;
            case 180: //3
                spawnRate = 25;
                
            break;
            case 300: //5:
                spawnRate = 20;
                spawnNumber = 2;
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
                spawnRate += 15;
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
                spawnNumber = 1;
            break;
            default:
            break;
        }
    }
     private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, radius);
    }
}
