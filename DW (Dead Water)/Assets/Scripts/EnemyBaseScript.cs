using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy ", menuName = "Enemy/Create new Enemy")]

public class EnemyBaseScript : ScriptableObject
{
    //Character Name
    [SerializeField] string name;

    //Character Description
    [TextArea]
    [SerializeField] string description;

    //Character model
    //public GameObject characterModel;

    //Base stats
    [SerializeField] float maxHp;
    [SerializeField] float attack;
    [SerializeField] float attackSpeed;
    //Resources
    [SerializeField] int gold;
    [SerializeField] float xp;


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

    public int Gold
    {
        get { return gold; }
    }

    public float Xp
    {
        get { return xp; }
    }
}
