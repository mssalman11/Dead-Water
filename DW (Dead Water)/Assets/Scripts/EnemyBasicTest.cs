using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicTest : MonoBehaviour
{
    public bool dead;
    private void Update()
    {
        if (dead)
        {
            Destroy(this.gameObject);
        }
    }
}
