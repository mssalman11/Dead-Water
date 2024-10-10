using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigger : MonoBehaviour
{
    public event EventHandler OnPlayerTriggerEnter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnPlayerTriggerEnter?.Invoke(this, EventArgs.Empty);
        }
    }
}
