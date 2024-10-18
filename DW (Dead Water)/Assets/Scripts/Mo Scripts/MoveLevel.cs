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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DestroyBlock"))
        {
            Destroy(this.gameObject);
        }
    }






    /*
    [SerializeField]
    private ColliderTrigger Ctrigger;
    [SerializeField]
    private bool move;
    // Start is called before the first frame update
    void Start()
    {
        Ctrigger.OnPlayerTriggerEnter += ColliderTrigger_OnPlayerEnterTrigger;
        move = true;
    }

    private void ColliderTrigger_OnPlayerEnterTrigger(object sender, System.EventArgs e)
    {
        move = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (move == false)
        {
            transform.position += new Vector3(0, 0, 0) * Time.deltaTime;
        } else
        {
            transform.position += new Vector3(0, 0, -5) * Time.deltaTime;
        }
        
    }
    */
}
