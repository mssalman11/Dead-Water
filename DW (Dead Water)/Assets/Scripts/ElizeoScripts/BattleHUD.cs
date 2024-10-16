using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/* [Nava, Elizeo]
 * [September 24, 2024]
 * [This used as a placement for the HUD in the BattleSystem script.]
 */
public class BattleHUD : MonoBehaviour
{
    public Text nameText;
    public Text levelText;
    public Slider hpSlider;
    public Text goldText;
    public Text atkText;

    public void SetCharHUD(CharacterUnit unit)
    {
        nameText.text = unit.charStat.name;
        levelText.text = "Lvl: " + unit.level;
        hpSlider.maxValue = unit.charStat.maxHp ;
        hpSlider.value = unit.currentHP;
        goldText.text = "Gold: " + unit.currentGold;
    }

    public void SetEnemyHUD(EnemyUnit unit)
    {
        nameText.text = unit.enemyStat.name;
        levelText.text = "Lvl: " + unit.level;
        hpSlider.maxValue = unit.enemyStat.maxHp ;
        hpSlider.value = unit.currentHP;
      //  goldText.text = "Gold: " + unit.currentGold;
    }

    public void SetHP(int hp)
    {
        hpSlider.value = hp;
    }

}
