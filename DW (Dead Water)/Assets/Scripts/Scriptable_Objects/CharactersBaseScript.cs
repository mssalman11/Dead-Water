using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Mercenary ", menuName = "Mercenary/Create new Merc") ]

public class CharactersBaseScript : ScriptableObject
{
    //Character Name
    [SerializeField] string name;

    //CHaracter Description
    [TextArea]
    [SerializeField] string description;

    //Role in team
    [SerializeField] CharacterType type1;

    //Base stats
    [SerializeField] int MaxHp;
    [SerializeField] int Attack;
    [SerializeField] float AttackSpeed;
}

public enum CharacterType
{
    None,
    Damage,
    Tank,
    Support
}