using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    Status stateTarget;
    Status stateSelf;
    UiManager uiTarget;

    //Instanciar o texto para a caixa de mensagem principal
    public TMP_Text dialogMessage;


    public UiManager player_StatusBox;
    public UiManager enemy_StatusBox;

    public BattleState state;

    void Start()
    {
        state = BattleState.START;
        StartCoroutine(StartBattle());
    }
    
    IEnumerator StartBattle()
    {
        //Tranforma o inimigo e o jogador em um game object e extrai os dados do script "Status"
        GameObject playerinstance = Instantiate(playerTemplate, playerOrigin);
        playerUnit = playerinstance.GetComponent<Status>();
        GameObject enemyInstance = Instantiate(enemyTemplate, enemyOrigin);
        enemyUnit = enemyInstance.GetComponent<Status>();


        dialogMessage.text = "Um "+ enemyUnit.unitName + " Esta pronto para te atacar.";

        

        player_StatusBox.SetStatus(playerUnit);
        enemy_StatusBox.SetStatus(enemyUnit);

        yield return new WaitForSeconds(2.5f);
        state = BattleState.PLAYERTURN;
        StartCoroutine(PlayerTurn());


    }

    void FixedUpdate()
    {
        if(state == BattleState.PLAYERTURN)
        {
            stateTarget = enemyUnit;
            stateSelf = playerUnit;
            uiTarget = enemy_StatusBox;
        }
        else if(state == BattleState.ENEMYTURN)
        {
            stateTarget = playerUnit;
            stateSelf = enemyUnit;
            uiTarget = player_StatusBox;
        }
    }
    

    IEnumerator PlayerTurn()
    {
        yield return new WaitForSeconds(1.5f);
        dialogMessage.text = "o que voce fará?";
        
    }

    IEnumerator EnemyTurn()
    {
        PlayAttack();
        yield return new WaitForSeconds(0.1f);
        state = BattleState.PLAYERTURN;
        StartCoroutine(PlayerTurn());

    }

    IEnumerator PlayAttack()
    {
        yield return new WaitForSeconds(0.5f);
        stateTarget.TakeDamage(stateSelf.UpdateDamage());
        StartCoroutine(DamageCount(stateSelf.UpdateDamage()));
        //uiTarget.DamageDealer(stateTarget.currentHP);
        if (state == BattleState.PLAYERTURN)
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
        uiTarget.StatusUpdate(stateTarget);
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN) { return; }
        StartCoroutine(PlayAttack());
    }

    public IEnumerator ArmorBlock(int hit)
    {
        if (hit == 1)
        {
            yield return new WaitForSeconds(1.5f);
            dialogMessage.text = "O Ataque perfura a armadura !";
        }
        else
        {
            yield return new WaitForSeconds(1.5f);
            dialogMessage.text = "A armadura Bloqueou o Ataque !";
        }

    }

    public IEnumerator DamageCount(float hurtDamage)
    {
        
        
        dialogMessage.text = stateSelf.unitName +" Desferiu " + hurtDamage +"!";
        yield return new WaitForSeconds(1.5f);
    }



}
