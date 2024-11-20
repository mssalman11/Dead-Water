using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Author: Leland LeVassar
//Created: 10/17/24
//Purpose: Keep track of stats and update UI in equip menu

public class StatManagerScript : MonoBehaviour
{
    public float maxHp, attack, attackSpeed, healAmount, healRate;

    [SerializeField]
    private Text maxHpText, attackText, attackSpeedText, healAmountText, healRateText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateEquipmentStats();
    }

    // Update is called once per frame
    void UpdateEquipmentStats()
    {
        maxHpText.text = maxHp.ToString();
        attackText.text = attack.ToString();
        attackSpeedText.text = attackSpeed.ToString();
        healAmountText.text = healAmount.ToString();
        healRateText.text = healRate.ToString();
    }
}
