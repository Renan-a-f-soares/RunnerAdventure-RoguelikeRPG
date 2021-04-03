using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


[SerializeField] 
public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST};

public class BattleSystem : MonoBehaviour
{

    //instancia o jogador e os inimigos
    public GameObject playerTemplate;
    public GameObject enemyTemplate;

    //localiza a posição dos objetos que definem onde devem ser instanciados jogador e o inimigo
    public Transform playerOrigin;
    public Transform enemyOrigin;
    
    //Instancia as propriedades do Script Status
    Status playerUnit;
    Status enemyUnit;

    //Instanciar o texto para a caixa de mensagem principal
    public TMP_Text dialogMessage;

    public BattleState state;

    void Start()
    {
        state = BattleState.START;
        StartBattle();
    }
    
    void StartBattle()
    {

        //Tranforma o inimigo e o jogador em um game object e extrai os dados do script "Status"
        GameObject playerinstance = Instantiate(playerTemplate, playerOrigin);
        playerUnit = playerinstance.GetComponent<Status>();
        GameObject enemyInstance = Instantiate(enemyTemplate, enemyOrigin);
        enemyUnit = enemyInstance.GetComponent<Status>();

        dialogMessage.text = "Um "+ enemyUnit.unitName + " Esta pronto para te atacar.";

    }



    
}
