using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_Player : MonoBehaviour
{
    public float speed = 2.0f;

    public Vector3 Dir = Vector3.zero;
    // Use this for initialization
    void Start ()
    {
        transform.position = new Vector3(0, 1, 0);
    }

    void Update()
    {
        transform.position += Dir * speed * Time.deltaTime;
    }

}
