using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* [Nava, Elizeo]
 * [September 18, 2024]
 * [Same codes as PlayerState.]
 */

public class EnemyState : MonoBehaviour
{
    //

    private BattleState BS;
    public enum TurnStates
    {
        PROCESS,
        //ADDINGTOLIST,
        CHOOSEACTION,
        WAITING,
        //SELECTION,
        ACTION,
        DEATH
    }

    public TurnStates currentState;

    // Start is called before the first frame update
    void Start()
    {
        currentState = TurnStates.PROCESS;
        BS = GameObject.Find("BattleStateContainer").GetComponent<BattleState>();
    }

    private float minProcess = 0f;
    private float maxProcess = 1f;

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Enemy is " + currentState.ToString());
        switch (currentState)
        {
            case TurnStates.PROCESS:
                inProcess();
                break;

            case TurnStates.CHOOSEACTION:
                break;

            case TurnStates.WAITING:
                break;

            case TurnStates.ACTION:
                break;

            case TurnStates.DEATH:
                break;
        }
    }

    void inProcess()
    {
        minProcess = minProcess + Time.deltaTime;
        float processTimer = minProcess / maxProcess;
        if (processTimer >= maxProcess)
        {
            currentState = TurnStates.CHOOSEACTION;
        }
    }

    void ChooseAnAction()
    {
        TurnHandler myAttack = new TurnHandler();
        myAttack.attackerObject = this.gameObject;
        //myAttack. (To be added soon)
    }
}
