using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*[Nava, Elizeo]
 *[October 24, 2024]
 *[This is just a line of script that will be used to determine the rarity of the item. To be used soon in Leland's Script]
 */
public class ItemRarity : MonoBehaviour
{
    public void setRarity (itemRarity rarity)
    {
        switch (rarity)
        {
            case itemRarity.COMMON:
                Debug.Log("This item is COMMON");
            break;

            case itemRarity.RARE:
                Debug.Log("This item is RARE");
            break;

            case itemRarity.SUPER_RARE:
                Debug.Log("This item is SUPER RARE");
            break;

            case itemRarity.ULTRA_RARE:
                Debug.Log("This item is ULTRA RARE");
            break;

        }
    }
     
        public enum itemRarity
    {
        COMMON,
        UNCOMMON,
        RARE,
        SUPER_RARE,
        ULTRA_RARE
    }

    public itemRarity rarity;

}
