using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_AIMovement : MonoBehaviour
{
    public Transform target;
    public int moveSpeed;
    public float volThreshold;


    public float reset_timer; //timer function removed for now.

    public bool triggered;

    public s_micInput micInput;
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

        if (micInput.loudness > 0.01)
        {
            triggered = true;
            print("works");
        }
    }//End Update

    public void Chase()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, (moveSpeed * Time.deltaTime));
    }


}
