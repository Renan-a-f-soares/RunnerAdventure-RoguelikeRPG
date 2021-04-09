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

    IEnumerator PlayerTurn()
    {
        stateTarget = enemyUnit;
        stateSelf = playerUnit;
        uiTarget = enemy_StatusBox;
        yield return new WaitForSeconds(3f);
        dialogMessage.text = "o que voce fará?";

    }

    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(3f);
        dialogMessage.text = "?";
        stateTarget = playerUnit;
        stateSelf = enemyUnit;
        uiTarget = player_StatusBox;
        StartCoroutine(PlayAttack());
        
    }

    IEnumerator PlayAttack()
    {
        yield return new WaitForSeconds(1f);
        stateTarget.TakeDamage(stateSelf.UpdateDamage());
        StartCoroutine(DamageCount(stateSelf.damage));
        
        uiTarget.StatusUpdate(stateTarget);
        turnChange();
    }

    void turnChange()
    {
        
        if(state == BattleState.PLAYERTURN)
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
        else if(state == BattleState.ENEMYTURN)
        {
            state = BattleState.PLAYERTURN;
            StartCoroutine(PlayerTurn());
        }
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN) { return; }
        StartCoroutine(PlayAttack());
    }



    public IEnumerator DamageCount(float hurtDamage)
    {

        if(stateTarget.currentArmor > 0)
        {
            if (stateTarget.hit == 1)
            {
                dialogMessage.text = "O Ataque perfura a armadura!";
            }
            else
            {
                dialogMessage.text = "A armadura Bloqueou o Ataque!";
            }
            yield return new WaitForSeconds(2f);
            
        }
        dialogMessage.text = stateSelf.unitName +" Desferiu " + hurtDamage +"!";
        yield return new WaitForSeconds(3.5f);
    }



}
