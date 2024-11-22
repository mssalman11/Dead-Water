using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Author: Leland LeVassar
 * Date created: 09/15/24
 * Purpose: Template to allow for the creation of player character scriptable objects.
 */

[CreateAssetMenu(fileName = "Mercenary ", menuName = "Mercenary/Create new Merc")]

public class CharactersBaseScript : ScriptableObject
{
    //Character Name
    [SerializeField] public string name; //made public by Elizeo Nava

    //Character Description
    [TextArea]
    [SerializeField] public string description; //made public by Elizeo Nava

    public GameObject characterModel;

    //Role in team
    [SerializeField] CharacterType type1;

    //Base stats, public in each float or ints added by Elizeo Nava
    [SerializeField] public int maxHp; //Originally a float, changed to int by Elizeo Nava
    [SerializeField] public int currentHp; //Added by Elizeo Nava
    [SerializeField] public int attack; //Originally a float, changed to int by Elizeo Nava
    [SerializeField] public float attackSpeed;
    //Support Stats Only
    [SerializeField] public float healAmount;
    [SerializeField] public float healRate;

    
    public string Name
    {
        get { return name; }

    }

    public string Description
    {
        get { return description; }
    }

    /*
     * QUARANTINED FOR DEBUGGING
    public gameObject CharacterModel
    {
        get { return characterModel; }
    }
    */

    public CharacterType Type1
    {
        get { return type1; }
    }

    public float MaxHp
    {
        get { return maxHp; }
    }

    public float Attack
    {
        get { return attack; }
    }

    public float AttackSpeed
    {
        get { return attackSpeed; }
    }

    public float HealAmount
    {
        get { return healAmount; }
    }

    public float HealRate
    {
        get { return healRate; }
    }

    //Copied from TestUnit Script by Elizeo Nava
    public bool takeDamage(int dmg)
    {
        currentHp -= dmg;

        if (currentHp <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

public enum CharacterType
{
    None,
    Damage,
    Tank,
    Support
}