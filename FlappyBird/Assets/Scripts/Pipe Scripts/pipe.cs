using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipe : MonoBehaviour
{
    private Transform Pipe;
    void Start()
    {
        Pipe = GameObject.Find("pipe").transform;
    }
    void Update()
    {
        Pipe.localPosition += new Vector3(-2f*Time.deltaTime,0,0);
        transform.Translate(-Time.deltaTime, 0, 0);

    }
}
