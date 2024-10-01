using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSManager : MonoBehaviour
{
    [SerializeField]
    private Transform enemyTransform;
    [SerializeField]
    private ColliderTrigger Ctrigger;
    [SerializeField]
    private GameObject canvas;
    [SerializeField]
    private GameObject battlesysteming;

    // Start is called before the first frame update
    void Start()
    {
        Ctrigger.OnPlayerTriggerEnter += ColliderTrigger_OnPlayerEnterTrigger;

    }

    private void ColliderTrigger_OnPlayerEnterTrigger(object sender, System.EventArgs e)
    {
        StartBattle();
        battlesysteming.SetActive(true);
        canvas.SetActive(true);
    }

    private void StartBattle()
    {
        Debug.Log("HOII");
    }
}
