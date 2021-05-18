using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandonGenerator : MonoBehaviour
{
    private int minStrength;
    private int maxStrength;
    private int rndMonster;
    public float timeCount;
    private Collider2D enemyinfo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetEnemyInfo(Collider2D colliderInfo){
        enemyinfo = colliderInfo;
    }
    
    public void SetTime(float defineTime){
        timeCount = defineTime;
        //Debug.Log("tempo: "+ timeCount);
    }
    public void RandonMonsterID(){
        Spawner timeM = new Spawner();
        timeCount = timeM.GetTime();
       // Debug.Log("tempo: "+ timeM.timeCount );
        
    }
   
}
