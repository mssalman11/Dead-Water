using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy ", menuName = "Enemy/Create new Enemy")]

public class EnemyBaseScript : ScriptableObject
{
    //Character Name
    [SerializeField] public string name; //Made to public by Elizeo Nava

    //Character Description
    [TextArea]
    [SerializeField] string description;

    //Character model
    //public GameObject characterModel;

    //Base stats
    [SerializeField] public int maxHp; //Originally a float, turned into Int by Elizeo Nava
    [SerializeField] public int attack;//^^
    [SerializeField] public float attackSpeed;
    //Resources
    [SerializeField] public int gold;
    [SerializeField] public float xp;


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
