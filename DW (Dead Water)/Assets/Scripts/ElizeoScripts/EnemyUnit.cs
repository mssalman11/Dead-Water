using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : MonoBehaviour
{
    public EnemyBaseScript enemyStat;

    public BattleSystem battleSystem;
    public GameObject battle;

    public string unitName;
    public int level;

    public int damage;

    public float priority;

    public int maxHP;
    public int currentHP;

    public int currentGold;
    public int goldRange;

    public void Start()
    {
        goldRange = enemyStat.gold;
        unitName = enemyStat.name;
        damage = enemyStat.attack;
        priority = enemyStat.attackSpeed;
        maxHP = enemyStat.maxHp;
        currentHP = maxHP;
        battle = GameObject.FindGameObjectWithTag("BattleSystemTag");
        battleSystem = battle.GetComponent<BattleSystem>();
    }

    //This function will make sure that any enemy unit takes damage. Needed for the attack function for BattleSystem.
    public bool takeDamage(int dmg)
    {
        currentHP -= dmg;

        if (currentHP <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public void Heal(int amount)
    {
        currentHP += amount;
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }

    public void GetGold(int amount)
    {
        currentGold += amount;
    }

    public void unitDie()
    {
        if (currentHP <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public IEnumerator ScaleEnemy()
    {
        yield return new WaitForSeconds(0.5f);
        damage += battleSystem.scaleValue;
        maxHP += battleSystem.scaleValue;
        Debug.Log("This enemy has gained " + battleSystem.scaleValue + " ATK and DEF");
        yield return new WaitForSeconds(1f);
        if (battleSystem.scalingCounter == 3)
        {
            battleSystem.scalingCounter = 0;
        }
    }
}
