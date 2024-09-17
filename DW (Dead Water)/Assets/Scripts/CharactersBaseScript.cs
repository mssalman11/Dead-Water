using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Author: Leland LeVassar
 * Date created: 09/15/24
 * Purpose: Template to allow for the creation of player character scriptable objects
 */

[CreateAssetMenu(fileName = "Mercenary ", menuName = "Mercenary/Create new Merc")]

public class CharactersBaseScript : ScriptableObject
{
    //Character Name
    [SerializeField] string name;

    //Character Description
    [TextArea]
    [SerializeField] string description;

    public GameObject characterModel;

    //Role in team
    [SerializeField] CharacterType type1;

    //Base stats
    [SerializeField] float maxHp;
    [SerializeField] float attack;
    [SerializeField] float attackSpeed;
    //Support Stats Only
    [SerializeField] float healAmount;
    [SerializeField] float healRate;

    
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
}

public enum CharacterType
{
    None,
    Damage,
    Tank,
    Support
}