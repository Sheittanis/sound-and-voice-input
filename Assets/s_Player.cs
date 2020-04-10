using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_Player : MonoBehaviour
{
    public float speed = 2.0f;
	// Use this for initialization
	void Start ()
    {
        transform.position = new Vector3(0, 1, 0);
    }
	

    public void Left()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    public void Right()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    public void Back()
    {
        transform.position += Vector3.back * speed * Time.deltaTime;
    }

    public void Forward()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }
}
