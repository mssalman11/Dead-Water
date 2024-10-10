using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    public GameObject levelSection;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NextPoint"))
        {
            Instantiate(levelSection, new Vector3(0 , 0, 13.27f), Quaternion.identity);
        }
    }
}
