using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandonGenerator : MonoBehaviour
{
    private int minStrength;
    private int maxStrength;
    private int rndMonster;
    private int levelMod = 1;
    public int levelTick = 3;
    public int newValue = 0;
    public float timeCount;
    public float timeTick;
    public Collider2D enemyinfo;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    public void SetEnemyInfo(Collider2D colliderInfo){
        enemyinfo = colliderInfo;
    }

    public int UpdateValue(int oldValue){
        newValue = oldValue ;
        return newValue;
    }

    public int RandonMonsterID(){
        if (levelMod < 10){
            if (levelTick == 3){
                //deixa os valores minimos e maximos do random dinamicos
                minStrength += 1;
                maxStrength = levelMod + 1;
                levelMod += 2;
                levelTick = 0;

            }
            levelTick += 1;
        }
        rndMonster = Random.Range(minStrength,maxStrength);

            //Debug.Log("Min" + minStrength);
            //Debug.Log("Max" + maxStrength);
            //Debug.Log("Levelmod" + levelTick);
            //Debug.Log("rnd" + rndMonster);
        return rndMonster;
    }

   
    
    public void SetTime(float defineTime){
        timeCount = defineTime;
        if(defineTime > timeTick){
            minStrength = minStrength + 1;
            maxStrength = maxStrength + 2;
            timeTick = timeTick + 3;
            //Debug.Log("tempo: "+ minStrength +" "+ timeTick);
        } 
        
    }
    
}
