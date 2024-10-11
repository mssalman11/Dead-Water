using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* [Nava, Elizeo]
 * [September 24, 2024]
 * [This serves as a test stat for the battle system. Placeholder for Leland's Stat script]
 */
public class TestUnit : MonoBehaviour
{
    public string unitName;
    public int level;

    public int damage;

    public int maxHP;
    public int currentHP;

    public int currentGold;
    public int goldRange;

    public void Start()
    {
        goldRange = Random.Range(10, 20);
    }
    //This function will make sure that any enemy unit takes damage. Needed for the attack function for BattleSystem.
    public bool takeDamage(int dmg)
    {
        currentHP -= dmg;

        if (currentHP <= 0 )
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Heal (int amount)
    {
        currentHP += amount;
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }

    public void GetGold (int amount)
    {
        currentGold += amount;
    }

    public void unitDie()
    {
        if (currentHP <= 0 )
        {
            Destroy(this.gameObject);
        }
    }
}
