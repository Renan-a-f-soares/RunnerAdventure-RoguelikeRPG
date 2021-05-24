using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandonGenerator : MonoBehaviour
{
    private int minStrength;
    private int maxStrength;
    private int rndMonster;
    public float timeCount;
    public float timeTick;
    private Collider2D enemyinfo;
    // Start is called before the first frame update
    void Start()
    {
     timeTick = 2;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetEnemyInfo(Collider2D colliderInfo){
        enemyinfo = colliderInfo;
    }

    public void RandonMonsterID(){
        Debug.Log("tempo certo: "+ maxStrength);
        
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
