using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.Rendering;
using Unity.VisualScripting;
//using Unity.PlasticSCM.Editor.WebApi; <- For some reason, this was added. Had to contain this because it was causing an error.

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

[RequireComponent(typeof(AudioSource))]
public class BattleSystem : MonoBehaviour
{
    public GameObject battleUI;
    public GameObject[] characters;
    public GameObject[] enemies;
    public GameObject triggerTest;
    public GameObject attackButton;
    public GameObject healButton;

    public GameObject gameOverUI;
    public GameObject continueUI;

    public bool incomingBattle;
    public static bool isPlayerDead;
    public static bool isEnemyDead;

    public Transform playerBattlePos;
    public GameObject enemyBattlePos;
    private int scalingcounter = 0;

    //Value for Healing
    [SerializeField] private int healValue;

    //Price for Healing
    [SerializeField] private int healingPrice;

    /* TestUnits are a placeholder for Leland's character data codes*/
    //public TestUnit charUnit;
    public CharacterUnit playerUnit;
    public EnemyUnit enemyUnit;

    //public TestUnit enemyUnit;

    //Text for the damage
    public Text damageText;

    //Text for the Dialouge
    public Text dialougeText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;
   // public BattleHUD charHUD;

    public BattleState state;

    /*This will use the SoundManagement Script*/
    public SoundManagement soundManager;
    

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        //StartCoroutine(SetupBattle());
        incomingBattle = true;
        triggerTest.SetActive(false);
        gameOverUI.SetActive(false);
        continueUI.SetActive(false);
        ResourceManagement.Instance.itemSelectUI.SetActive(false);


        //Opens up the character selection first before the level starts
        ResourceManagement.Instance.CharSelection();

        damageText.text = " ";
        dialougeText.text = " ";

        //Opens up the SoundManager
        soundManager = GameObject.FindGameObjectWithTag("Sound").GetComponent<SoundManagement>();
        soundManager.traverseSource.Play();

        randomNum = 0;

    }

    private void Update()
    {
        startAnotherBattle();
    }

    //Turns the battle mode either on or off.
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
    public IEnumerator SetupBattle() //USED FOR THE VERY FIRST TRIGGER OF THE LEVEL. Tag for the trigger should be "FirstBattle"
    {
        //Lets the player play as "Michigan" after selection.
        if (ResourceManagement.Instance.currentChar == ResourceManagement.SelectedChar.MICHIGAN)
        {
            GameObject charGO = Instantiate(characters[0], playerBattlePos.transform.position, Quaternion.identity);
            playerUnit = charGO.GetComponent<CharacterUnit>();
        }
        //Lets the player play as "Rainier" after selection.
        if (ResourceManagement.Instance.currentChar == ResourceManagement.SelectedChar.RAINIER)
        {
            GameObject charGO = Instantiate(characters[1], playerBattlePos.transform.position, Quaternion.identity);
            playerUnit = charGO.GetComponent<CharacterUnit>();
        }
        //Lets the player play as "Colbalt" after selection.
        if (ResourceManagement.Instance.currentChar == ResourceManagement.SelectedChar.COLBALT)
        {
            GameObject charGO = Instantiate(characters[2], playerBattlePos.transform.position, Quaternion.identity);
            playerUnit = charGO.GetComponent<CharacterUnit>();
        }

        GameObject enemyGO = Instantiate(enemies[0], enemyBattlePos.transform.position, Quaternion.identity);
        enemyUnit = enemyGO.GetComponent<EnemyUnit>();

        dialougeText.text = enemyUnit.enemyStat.name + " has appeared!";

        playerHUD.SetCharHUD(playerUnit);
        enemyHUD.SetEnemyHUD(enemyUnit);
        playerHUD.SetHP(playerUnit.charStat.maxHp);
        enemyHUD.SetHP(enemyUnit.enemyStat.maxHp) ;
        attackButton.SetActive(false);
        healButton.SetActive(false);
        soundManager.battleSource.Play();
        soundManager.traverseSource.Stop();

        yield return new WaitForSeconds(2);

        attackButton.SetActive(true);
        healButton.SetActive(true);
        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    //Use this coroutine for the on the second Trigger enter and above
    public IEnumerator SetupAnotherBattle()
    {
        GameObject enemyGO = Instantiate(enemies[Random.Range(0,5)], enemyBattlePos.transform.position, Quaternion.identity);
        enemyUnit = enemyGO.GetComponent<EnemyUnit>();

        dialougeText.text = "A " + enemyUnit.enemyStat.name + " has appeared!";

        playerHUD.SetCharHUD(playerUnit);
        enemyHUD.SetEnemyHUD(enemyUnit);
        enemyHUD.SetHP(enemyUnit.enemyStat.maxHp);

        attackButton.SetActive(false);
        healButton.SetActive(false);

        soundManager.traverseSource.Stop();
        soundManager.battleSource.Play();

        yield return new WaitForSeconds(2);

        attackButton.SetActive(true);
        healButton.SetActive(true);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
        Debug.Log(enemyUnit.damage);
        Debug.Log(enemyUnit.maxHP);
        Debug.Log(scalingcounter);
    }

    //Trigger Coroutines for Specific Enemy (TESTING PURPOSES ONLY)

    //Spawns a Skull Jelly
    public IEnumerator SetupBattleWithJelly()
    {
        GameObject enemyGO = Instantiate(enemies[0], enemyBattlePos.transform.position, Quaternion.identity);
        enemyUnit = enemyGO.GetComponent<EnemyUnit>();

        dialougeText.text = "A " + enemyUnit.enemyStat.name + " has appeared!";

        playerHUD.SetCharHUD(playerUnit);
        enemyHUD.SetEnemyHUD(enemyUnit);
        enemyHUD.SetHP(enemyUnit.enemyStat.maxHp);

        yield return new WaitForSeconds(2);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    //Spawns a Giant Snapper
    public IEnumerator SetupBattleWithFish()
    {
        GameObject enemyGO = Instantiate(enemies[1], enemyBattlePos.transform.position, Quaternion.identity);
        enemyUnit = enemyGO.GetComponent<EnemyUnit>();

        dialougeText.text = "A " + enemyUnit.enemyStat.name + " has appeared!";

        playerHUD.SetCharHUD(playerUnit);
        enemyHUD.SetEnemyHUD(enemyUnit);
        enemyHUD.SetHP(enemyUnit.enemyStat.maxHp);

        yield return new WaitForSeconds(2);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    //Spawns a Giant Squid
    public IEnumerator SetupBattleWithSquid()
    {
        GameObject enemyGO = Instantiate(enemies[2], enemyBattlePos.transform.position, Quaternion.identity);
        enemyUnit = enemyGO.GetComponent<EnemyUnit>();

        dialougeText.text = "A " + enemyUnit.enemyStat.name + " has appeared!";

        playerHUD.SetCharHUD(playerUnit);
        enemyHUD.SetEnemyHUD(enemyUnit);
        enemyHUD.SetHP(enemyUnit.enemyStat.maxHp);

        yield return new WaitForSeconds(2);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }
    //THE ATTACK ACTION
    public IEnumerator PlayerAttack()
    {
        dialougeText.text = playerUnit.unitName + " has attacked!";

        attackButton.SetActive(false);
        healButton.SetActive(false);

        yield return new WaitForSeconds(1f);

        //Damages Enemy
        isEnemyDead = enemyUnit.takeDamage(playerUnit.damage);
        damageText.text = playerUnit.damage.ToString();
        enemyHUD.SetHP(enemyUnit.currentHP);
        
        

        soundManager.PlaySFX(soundManager.attackSound);


        //Time of Attack
        yield return new WaitForSeconds(2f);

        damageText.text = " ";

        //Checks if the enemy is dead
        if(isEnemyDead)
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

    //Changes the dialouge base on the result of battle.
    public void EndBattle()
    {
        if (state == BattleState.WON)
        {
            dialougeText.text = "YOU HAVE WON THE BATTLE!";
            soundManager.PlaySFX(soundManager.victorySound);
            scalingcounter++;
            Debug.Log("SC INCREASE");

        }
        else if (state == BattleState.LOST)
        {
            dialougeText.text = "YOU ARE DEAD!";
            soundManager.PlaySFX(soundManager.defeatSound);
        }
    }

    //The healing function is added in for in case we ever implement healing items in the future.
    //The healing system will now use gold
    public IEnumerator PlayerHeal()
    {
        //If the player has enough gold, heal the player and then the enemy will attack next. Healing costs 3 gold.
        if (ResourceManagement.Instance.totalCoins >= healingPrice)
        {
            ResourceManagement.Instance.removeCoins(healingPrice);
            playerHUD.goldText.text = "Gold: " + ResourceManagement.Instance.totalCoins.ToString();
            playerUnit.Heal(playerUnit.maxHP / healValue);
            playerHUD.SetHP(playerUnit.currentHP);
            dialougeText.text = playerUnit.unitName + " has been healed!";
            attackButton.SetActive(false);
            healButton.SetActive(false);
            soundManager.PlaySFX(soundManager.healSound);
            yield return new WaitForSeconds(2f);
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());            
        }
        //If the player does not have enough gold, tell the player that their gold is insufficient and then lead them back to battle selection.
        else if (ResourceManagement.Instance.totalCoins < healingPrice)
        {
            dialougeText.text = "Insufficient Gold";
            attackButton.SetActive(false);
            healButton.SetActive(false);
            soundManager.PlaySFX(soundManager.invalidSound);
            yield return new WaitForSeconds(2f);
            state = BattleState.PLAYERTURN;
            PlayerTurn();
            attackButton.SetActive(true);
            healButton.SetActive(true);
        }

    }

    //The enemy's turn to attack
    public IEnumerator EnemyTurn()
    {
        dialougeText.text = enemyUnit.enemyStat.name + " is Attacking!";

        yield return new WaitForSeconds(1f);

        isPlayerDead = playerUnit.takeDamage(enemyUnit.damage);

        damageText.text = enemyUnit.damage.ToString();

        playerHUD.SetHP(playerUnit.currentHP);

        soundManager.PlaySFX(soundManager.attackSound);

        yield return new WaitForSeconds(1f);

        damageText.text = " ";

        if(isPlayerDead)
        {
            state = BattleState.LOST;
            EndBattle();
            StartCoroutine(GameOverScreen());
        }
        else
        {
            state = BattleState.PLAYERTURN;
            //PlayerTurn(); original line.
            StartCoroutine(PlayerAttack()); //Battle system should be automatic thanks to this change of code.
        }
    }

    //Starts up after the battle is Won
    public IEnumerator NextBattle()
    {
        yield return new WaitForSeconds(2f);

        ResourceManagement.Instance.addCoins(enemyUnit.goldRange);
        dialougeText.text = playerUnit.unitName + " has earned " + enemyUnit.goldRange + " Gold!";
        playerHUD.goldText.text = "Gold: " + ResourceManagement.Instance.totalCoins.ToString();
        soundManager.PlaySFX(soundManager.goldSound);

        yield return new WaitForSeconds(2f);


        randomNum = Random.Range(1, 4);

        dialougeText.text = " ";

        //Mo Addition
        ResourceManagement.Instance.itemSelectUI.SetActive(true);


        incomingBattle = true;
        //soundManager.battleSource.Stop();
        //soundManager.traverseSource.Play();


        //-------------------------------------

        // triggerTest.SetActive(true);
        //dialougeText.text = "Incoming next battle";

        //yield return new WaitForSeconds(4f);

        // charUnit.currentHP = 22; //11;

        //Replenishes Enemy HP
        enemyUnit.currentHP = 22;

        //Fixes bug that makes the health not show it's increase.
        playerHUD.SetHP(playerUnit.currentHP);
        enemyHUD.SetHP(enemyUnit.currentHP);

        if (scalingcounter % 3 == 0)
        {
            enemyUnit.maxHP += 5;
            enemyUnit.damage += 5;
            
        }

        // state = BattleState.PLAYERTURN;
        // PlayerTurn();
        //  dialougeText.text = "Starting Battle..";


        //yield return new WaitForSeconds(2f);

        //StartCoroutine(PlayerAttack());

    }

    public IEnumerator GameOverScreen()
    {
        yield return new WaitForSeconds(2f);

        incomingBattle = true;
        gameOverUI.SetActive(true);

        yield return new WaitForSeconds(2f);

        continueUI.SetActive(true);
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

    //All used for Trigger Testing
    public void OnTriggerButton()
    {
        incomingBattle = false;
        StartCoroutine(SetupAnotherBattle());
    }

    public void OnJellyButton()
    {
        incomingBattle = false;
        StartCoroutine(SetupBattleWithJelly());
    }

    public void OnFishButton()
    {
        incomingBattle = false;
        StartCoroutine(SetupBattleWithFish());
    }

    public void OnSquidButton()
    {
        incomingBattle = false;
        StartCoroutine(SetupBattleWithSquid());
    }

    //Helps the player stop every trigger.
    public IEnumerator IntotheNextBattle()
    {
        yield return new WaitForSeconds(3f);
        ResourceManagement.Instance.nextMove = false;
    }

    public void BattleOVER()
    {
        //Turns on the bool in the ResourceManagement scripts, which should help the player stop every trigger.
        ResourceManagement.Instance.isBattleOver();
        StartCoroutine(IntotheNextBattle());
        soundManager.battleSource.Stop();
        soundManager.traverseSource.Play();
    }

    //Mo Addition
    //These functions will allow the player to go to the next battle after selecting an item.

    //These void function will be the action where the player obtains the item.

    //public int statBoostValue;

    public int randomNum;
    public int coinflip;

    public void getAttackItem()
    {
        //This is a placeholder. This code should be able to add up to a current character's attack stat.
        //(i.e. playerUnit.damage += any number
        dialougeText.text = playerUnit.unitName + " has gained " + randomNum + " ATK";
        playerUnit.damage += randomNum;
        soundManager.PlaySFX(soundManager.itemSound);
    }

    public void getDefenseItem()
    {
        //This is a placeholder. This code should be able to add up to a current character's health stat.
        //(i.e. playerUnit.maxHP += any number
        dialougeText.text = playerUnit.unitName + " has gained " + randomNum + " to their health";
        playerUnit.maxHP += randomNum;
        soundManager.PlaySFX(soundManager.itemSound);
    }

    public void getWildItem()
    {
        //This is a placeholder. Not much has been decided for the wild item yet..
        coinflip = Random.Range(1, 3);
        if (coinflip % 2 == 0)
        {
            dialougeText.text = playerUnit.unitName + " has increased a random stat by " + randomNum;
            if (randomNum == 1)
            {
                playerUnit.damage += coinflip;
            }
            else if (randomNum >= 2)
            {
                playerUnit.maxHP += coinflip;
            }
            soundManager.PlaySFX(soundManager.itemSound);
        }
        else
        {
            dialougeText.text = "Better luck next time!";
        }
    }

    //These codes will activate once an item has been selected.
    public IEnumerator attackItemObtained()
    {
        ResourceManagement.Instance.itemSelectUI.SetActive(false);
        getAttackItem();
        yield return new WaitForSeconds(2f);
        dialougeText.text = " ";
        randomNum = 0;
        BattleOVER();
        //IntotheNextBattle();
    }

    public IEnumerator defenseItemObtained()
    {
        ResourceManagement.Instance.itemSelectUI.SetActive(false);
        getDefenseItem();
        yield return new WaitForSeconds(2f);
        dialougeText.text = " ";
        randomNum = 0;
        BattleOVER();
        //IntotheNextBattle();
    }

    public IEnumerator wildItemObtained()
    {
        ResourceManagement.Instance.itemSelectUI.SetActive(false);
        getWildItem();
        yield return new WaitForSeconds(2f);
        dialougeText.text = " ";
        randomNum = 0;
        BattleOVER();
        //IntotheNextBattle();
    }

    //These will be used on each item button.
    public void OnAttackItemSelection()
    {
        StartCoroutine(attackItemObtained());
    }

    public void OnDefenseItemSelection()
    {
        StartCoroutine(defenseItemObtained());
    }

    public void OnWildItemSelection()
    {
        StartCoroutine(wildItemObtained());
    }
    
}


