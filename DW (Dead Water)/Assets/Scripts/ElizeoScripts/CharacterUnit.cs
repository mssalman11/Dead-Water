using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUnit : MonoBehaviour
{

    public CharactersBaseScript charStat;

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
        goldRange = Random.Range(10, 20);
        unitName = charStat.name;
        damage = charStat.attack;
        priority = charStat.attackSpeed;
        maxHP = charStat.maxHp;
        currentHP = maxHP;

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
}
