using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    public GameObject[] levels = new GameObject[10];

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NextPoint"))
        {
            int rlevel = Random.Range(0, levels.Length);
            Instantiate(levels[rlevel], new Vector3(0 , 0, 13.27f), Quaternion.identity);
        }
    }
}
