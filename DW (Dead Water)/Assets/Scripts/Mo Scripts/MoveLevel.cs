using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLevel : MonoBehaviour
{
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
}
