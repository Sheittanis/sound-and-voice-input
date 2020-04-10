using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_AIMovement : MonoBehaviour
{
    public Transform target;
    public int moveSpeed;
    public int rotSpeed;


    public float reset_timer;

    public bool triggered;
    void Start ()
    {
        moveSpeed = 1;
        reset_timer = 1.0f;
        triggered = false;
	}

    // Update is called once per frame
    void Update()
    {
        if (triggered)
        {
            Chase();     
        }
    }//End Update

    public void Chase()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, (moveSpeed * Time.deltaTime));
    }


}
