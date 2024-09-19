using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* [Nava, Elizeo]
 * [September 18, 2024]
 * [This is the battle system for Dead Water as well as the HP System for the player characters.]
 */
public class PlayerState : MonoBehaviour
{
    public enum TurnStates
    {
        PROCESS,
        ADDINGTOLIST,
        WAITING,
        SELECTION,
        ACTION,
        DEATH
    }

    public TurnStates currentState;

    // Start is called before the first frame update
    void Start()
    {
        currentState = TurnStates.PROCESS;
    }

    private float minProcess = 0f;
    private float maxProcess = 1f;

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Player is " + currentState.ToString());
        switch(currentState)
        {
            case TurnStates.PROCESS:
                inProcess();
                break; 

            case TurnStates.ADDINGTOLIST:
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
            currentState = TurnStates.ADDINGTOLIST;
        }
    }
    
}
