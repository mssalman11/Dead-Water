using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Author: Leland LeVassar
//Created: 10/17/24
//Purpose: Keep track of stats and update UI in equip menu

public class StatManagerScript : MonoBehaviour
{  
    public CharactersBaseScript charStat; /*Added in by Elizeo Nava*/

    public float attackSpeed, healAmount, healRate;
    public int maxHp, attack; //Added by Elizeo

    [SerializeField]
    private Text maxHpText, attackText, attackSpeedText, healAmountText, healRateText, characterNameText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateEquipmentStats();
    }

    // Update is called once per frame
    public void UpdateEquipmentStats()
    {
        characterNameText.text = charStat.name.ToString();
        maxHpText.text = charStat.maxHp.ToString();
        attackText.text = charStat.attack.ToString();
        attackSpeedText.text = charStat.attackSpeed.ToString();
        healAmountText.text = charStat.healAmount.ToString();
        healRateText.text = charStat.healRate.ToString();
    }
}
