using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*[Nava, Elizeo]
 *[September 24, 2024]
 *[This is the character script that utilized Leland's Character ScriptableObject]
 */
public class CharacterUnit : MonoBehaviour
{

    public CharactersBaseScript charStat;

    public string unitName;
    public int level;

    public int damage;

    public float priority;

    public int maxHP;
    public int currentHP;

    //public int currentGold; Player gold will now be used in the Resource Management Singleton Script.
    //public int goldRange;

    //This is to set up a stat for each scriptable object
    public void Start()
    {
       // goldRange = Random.Range(10, 20);
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

    //This is where the amount of health that the player can heal.
    public void Heal(int amount)
    {
        currentHP += amount;
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }

    //This is where the Gold System lies
    //public void GetGold(int amount)
    //{
        //currentGold += amount;
    //}

    //This
    public void unitDie()
    {
        if (currentHP <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
