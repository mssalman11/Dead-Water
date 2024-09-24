using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] levelPrefabs;

    [SerializeField] private List<GameObject> levelsSpawned;

    [SerializeField] private bool alive, kill;

    UnityEvent enemydies;

    private void Start()
    {
        levelsSpawned = new List<GameObject>();


        if (enemydies == null)
            enemydies = new UnityEvent();

        enemydies.AddListener(spawnLevelSystem);
    }


    public void SpawnTile(int tileIndex)
    {
        GameObject t = Instantiate(levelPrefabs[tileIndex],levelPrefabs[tileIndex].transform.position , Quaternion.identity);
    }

    public void DeleteTile()
    {
        Destroy(levelsSpawned[0]);
        levelsSpawned.RemoveAt(0);    
    }

    public void spawnLevelSystem()
    {
        int ra = Random.Range(0,levelPrefabs.Length);
        SpawnTile(ra);
        DeleteTile();
    }
}
