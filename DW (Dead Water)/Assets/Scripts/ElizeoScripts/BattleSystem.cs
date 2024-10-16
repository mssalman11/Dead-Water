using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;

/*[Nava, Elizeo]
 *[September 24, 2024]
 *[This is a new battle system as the old battle system being worked on was giving me trouble]
 *[Producer and Designer are free to make some changes, make sure to state your name and tell me what you have changed.]
 */

public enum BattleState
{
    START,
    PLAYERTURN,
    ENEMYTURN,
    WON,
    LOST
}

public class BattleSystem : MonoBehaviour
{
    public GameObject battleUI;
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject triggerTest;

    public bool incomingBattle;

 //   public List<GameObject> enemyObjs;
 //   public List<GameObject> playerObjs;

    public Transform playerBattlePos;
    public GameObject enemyBattlePos;

    /* TestUnits are a placeholder for Leland's character data codes*/
    //public TestUnit charUnit;
    public CharacterUnit playerUnit;
    public EnemyUnit enemyUnit;
    //public TestUnit enemyUnit;


    public Text dialougeText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;
   // public BattleHUD charHUD;

    public BattleState state;

    
    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
        incomingBattle = false;
    }

    private void Update()
    {
        startAnotherBattle();
    }

    public void startAnotherBattle()
    {
        if (incomingBattle == true)
        {
            battleUI.SetActive(false);
          //  state = BattleState.START;
        }
        if (incomingBattle == false)
        {

            battleUI.SetActive(true);
            triggerTest.SetActive(false);
        }
    }

    /* This is meant to set up enemies and characters in the battle system
     */
    public IEnumerator SetupBattle() //was originally a void function used to test the dialouge and HUD.
    {
        
        GameObject charGO = Instantiate(playerPrefab, playerBattlePos.transform.position, Quaternion.identity);
        playerUnit = charGO.GetComponent<CharacterUnit>();
        
        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattlePos.transform.position, Quaternion.identity);
        enemyUnit = enemyGO.GetComponent<EnemyUnit>();

        dialougeText.text = enemyUnit.enemyStat.name + " has appeared!";

        playerHUD.SetCharHUD(playerUnit);
        enemyHUD.SetEnemyHUD(enemyUnit);
        playerHUD.SetHP(playerUnit.charStat.maxHp);
        enemyHUD.SetHP(enemyUnit.enemyStat.maxHp) ;

        yield return new WaitForSeconds(2);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    //Use this coroutine for the on the Trigger ebnter
    public IEnumerator SetupAnotherBattle()
    {
        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattlePos.transform.position, Quaternion.identity);
        enemyUnit = enemyGO.GetComponent<EnemyUnit>();

        dialougeText.text = "Another " + enemyUnit.enemyStat.name + " has appeared!";

        playerHUD.SetCharHUD(playerUnit);
        enemyHUD.SetEnemyHUD(enemyUnit);
        enemyHUD.SetHP(enemyUnit.enemyStat.maxHp);
        playerUnit.goldRange = Random.Range(10, 20);

        yield return new WaitForSeconds(2);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }
    public IEnumerator PlayerAttack()
    {
        //Damages Enemy
        bool isDead = enemyUnit.takeDamage(playerUnit.damage);

        enemyHUD.SetHP(enemyUnit.currentHP);
        dialougeText.text = playerUnit.unitName + " has attacked!";

        //Time of Attack
        yield return new WaitForSeconds(2f);

        //Checks if the enemy is dead
        if(isDead)
        {
            // The Battle Ends
            state = BattleState.WON;
            EndBattle();
            enemyUnit.unitDie();
            StartCoroutine(NextBattle());
        }
        else
        {
            // Enemy attacks next
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
        //
    }

    public void EndBattle()
    {
        if (state == BattleState.WON)
        {
            dialougeText.text = "You have won the battle!";
        }
        else if (state == BattleState.LOST)
        {
            dialougeText.text = "You are dead. Game Over!";
        }
    }

    //The healing function is added in for in case we ever implement healing items in the future.
    public IEnumerator PlayerHeal()
    {
        playerUnit.Heal(5);

        playerHUD.SetHP(playerUnit.currentHP);
        dialougeText.text = playerUnit.name + " has been healed!";

        yield return new WaitForSeconds(2f);
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    public IEnumerator EnemyTurn()
    {
        dialougeText.text = enemyUnit.enemyStat.name + " is Attacking!";

        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.takeDamage(enemyUnit.damage);

        playerHUD.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if(isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            //PlayerTurn(); original line.
            StartCoroutine(PlayerAttack()); //Battle system should be automatic thanks to this change of code.
        }
    }

    public IEnumerator NextBattle()
    {
        
        yield return new WaitForSeconds(2f);

        playerUnit.GetGold(enemyUnit.goldRange);
        dialougeText.text = playerUnit.unitName + " has earned " + enemyUnit.goldRange + " Gold!";
        playerHUD.goldText.text = "Gold: " + playerUnit.currentGold.ToString();

        yield return new WaitForSeconds(2f);
        incomingBattle = true;
        triggerTest.SetActive(true);
        //dialougeText.text = "Incoming next battle";

        //yield return new WaitForSeconds(4f);

        // charUnit.currentHP = 22; //11;
        enemyUnit.currentHP = 22;

        playerHUD.SetHP(playerUnit.currentHP);
        enemyHUD.SetHP(enemyUnit.currentHP);

       // state = BattleState.PLAYERTURN;
       // PlayerTurn();
        //  dialougeText.text = "Starting Battle..";


        //yield return new WaitForSeconds(2f);

        //StartCoroutine(PlayerAttack());

    }

    public void PlayerTurn()
    {
        dialougeText.text = "Choose any action!";
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }
            StartCoroutine(PlayerAttack());

    }

    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }
        StartCoroutine(PlayerHeal());
            
    }

    public void OnTriggerButton()
    {
        incomingBattle = false;
        StartCoroutine(SetupAnotherBattle());
    }
}
