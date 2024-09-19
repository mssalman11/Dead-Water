using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleState : MonoBehaviour
{

    public enum Actions
    {
        WAITING,
        TAKINGACTION,
        PERFORMING,

    }

    public Actions currentBattleState;

    public List<TurnHandler> performList = new List<TurnHandler>();

    public List<GameObject> charactersActive = new List<GameObject>();
   
    public List<GameObject> enemiesActive = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        currentBattleState = Actions.WAITING;
        enemiesActive.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        charactersActive.AddRange(GameObject.FindGameObjectsWithTag("Character"));
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentBattleState)
        {
            case Actions.WAITING:
                break;
            case Actions.TAKINGACTION:
                break;
            case Actions.PERFORMING:
                break;
        }
    }
}
