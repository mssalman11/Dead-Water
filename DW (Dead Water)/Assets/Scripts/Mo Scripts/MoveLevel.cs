using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class MoveLevel : MonoBehaviour
{
    public ColliderTrigger stopBattle;
    public bool move;

    
    
    void Start()
    {
        move = true;
        stopBattle.OnPlayerTriggerEnter += StopBattle_OnPlayerTriggerEnter;
    }

    private void StopBattle_OnPlayerTriggerEnter(object sender, System.EventArgs e)
    {
        move = false;
    }

    private void Update()
    {
        if (move == false)
        {
            transform.position += new Vector3(0, 0, 0) * Time.deltaTime;
        }
        else
        {
            transform.position += new Vector3(0, 0, -3) * Time.deltaTime;
        }

        
        if (ResourceManagement.Instance.nextMove == true)
        {
            move = true;
        }
       

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DestroyBlock"))
        {
            Destroy(this.gameObject);
        }
    }


}
