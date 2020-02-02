using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    private Transform bird;

    private float offset = 0.7f;
    void Start()
    {
        bird = GameObject.Find("Flappy Bird").transform;
    }

    void Update()
    {
        transform.position = new Vector3(bird.position.x + offset, 0, transform.position.z);
    }
}
