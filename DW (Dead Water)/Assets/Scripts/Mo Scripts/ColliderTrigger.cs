using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigger : MonoBehaviour
{
    public event EventHandler OnPlayerTriggerEnter;

    public GameObject battle;
    private BattleSystem internalBS;
    

    private void Start()
    {
        battle = GameObject.FindGameObjectWithTag("BattleSystemTag");
        internalBS = battle.GetComponent<BattleSystem>();        
    }

    private void Update()
    {

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.tag == "FirstBattle")
        {
            if (other.gameObject.CompareTag("Player"))
            {
                OnPlayerTriggerEnter?.Invoke(this, EventArgs.Empty);
                internalBS.incomingBattle = false;
                StartCoroutine(internalBS.SetupBattle());


            }
        }
        if (this.gameObject.tag == "StopLevel")
        {
            if (other.gameObject.CompareTag("Player"))
            {
                OnPlayerTriggerEnter?.Invoke(this, EventArgs.Empty);
                internalBS.incomingBattle = false;
                StartCoroutine(internalBS.SetupAnotherBattle());
            }
        }
    }

}
