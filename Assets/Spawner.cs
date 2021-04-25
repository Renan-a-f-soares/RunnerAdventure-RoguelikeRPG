using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //timer
    public float timeCount;
    public float timeTick = 30;
    public float spawnRate;
    public int spawnNumber;

    //prefabs a serem instanciados
    public GameObject lowPursuer;
    public float radius;
    void Start()
    {
        spawnNumber = 1;
        spawnRate = 30;
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        switch(timeCount){

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
                spawnNumber = 8;
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
        
        if(timeCount > timeTick){
            timeTick += spawnRate;
            SpawnMonster();
        }
        

    }

    void SpawnMonster(){
        Debug.LogError("spawna!!!!!!!!!" + timeTick);
    }

     private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, radius);
    }
}
