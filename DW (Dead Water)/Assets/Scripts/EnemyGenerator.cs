using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Tiles;
    [SerializeField]
    private GameObject[] enemies;
    [SerializeField]
    private GameObject[] enemiesList;

    [SerializeField] private bool allDead;
    [SerializeField] private bool spawnin;

    private void Start()
    {
        
    }

    private void FixedUpdate()
    {
        if (spawnin)
        {
            spawningIn();
            spawnin = false;
        }
    }

    private void spawningIn()
    {
        for (int i = 0; i < Tiles.Length; i++)
        {
            for (int j = 0; j < enemies.Length; j++) {
                int rand = Random.Range(0, enemies.Length);
                Instantiate(enemies[i], Tiles[i].transform.position, Quaternion.identity);
                //enemies[i] += enemiesList[j];
            }
        }
    }
}

