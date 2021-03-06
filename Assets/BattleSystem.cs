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

    public float turnDamage; 
    public BattleState state;

    void Start()
    {
        //Formula para definir a dificuldade do random e o level dos inimigos
        // ---> Chama script Randon para definir inimigo
        // ---> chama Script lista de inimigos para definir qual inimigo será usado
                // definir inimigos por um ID, 
                        //eles devem ter pesos de status baseados em seu level
                        //Eles devem ter uma lista de metodos que chamam as habilidades
                        //eles devem ter uma função chamada que irá encadear essas habilidades
        //


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
        yield return new WaitForSeconds(3f);
        stateTarget = enemyUnit;
        stateSelf = playerUnit;
        uiTarget = enemy_StatusBox;
        dialogMessage.text = "o que voce fará?";

    }

    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(3f);
        stateTarget = playerUnit;
        stateSelf = enemyUnit;
        uiTarget = player_StatusBox;
        dialogMessage.text = "?";
        StartCoroutine(PlayAttack());
        
    }

    IEnumerator PlayAttack()
    {
        yield return new WaitForSeconds(2f);
        turnDamage = stateSelf.UpdateDamage();
        stateTarget.TakeDamage(turnDamage);
        StartCoroutine(DamageCount(turnDamage));
        
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

        if (stateTarget.currentArmor > 0)
        {
            if (stateTarget.hit == 1)
            {
                dialogMessage.text = "O Ataque perfura a armadura!";
            }
            else
            {
                dialogMessage.text = "A armadura Bloqueou o Ataque!";
            }
            yield return new WaitForSeconds(1f);

        }

        dialogMessage.text = stateSelf.unitName + " Desferiu " + hurtDamage + "!";
        yield return new WaitForSeconds(3f);

    }



}
