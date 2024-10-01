using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBattlePos;
    public Transform enemyBattlePos;

    /* TestUnits are a placeholder for Leland's character data codes*/
    public TestUnit charUnit;
    public TestUnit enemyUnit;

    public Text dialougeText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public BattleState state;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    /* This is meant to set up enemies and characters in the battle system
     */
    public IEnumerator SetupBattle() //was originally a void function used to test the dialouge and HUD.
    {
        
        GameObject charGO = Instantiate(playerPrefab, playerBattlePos);
        charUnit = charGO.GetComponent<TestUnit>();
        
        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattlePos);
        enemyUnit = enemyGO.GetComponent<TestUnit>();

        dialougeText.text = enemyUnit.unitName + " has appeared!";

        playerHUD.SetHUD(charUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    public IEnumerator PlayerAttack()
    {
        //Damages Enemy
        bool isDead = enemyUnit.takeDamage(charUnit.damage);

        enemyHUD.SetHP(enemyUnit.currentHP);
        dialougeText.text = charUnit.name + " has attacked!";

        //Time of Attack
        yield return new WaitForSeconds(2f);

        //Checks if the enemy is dead
        if(isDead)
        {
            // The Battle Ends
            state = BattleState.WON;
            EndBattle();
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
        charUnit.Heal(5);

        playerHUD.SetHP(charUnit.currentHP);
        dialougeText.text = charUnit.name + " has been healed!";

        yield return new WaitForSeconds(2f);
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    public IEnumerator EnemyTurn()
    {
        dialougeText.text = enemyUnit.name + " is Attacking!";

        yield return new WaitForSeconds(1f);

        bool isDead = charUnit.takeDamage(enemyUnit.damage);

        playerHUD.SetHP(charUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if(isDead)
        {
            state = BattleState.LOST;
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
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
}
