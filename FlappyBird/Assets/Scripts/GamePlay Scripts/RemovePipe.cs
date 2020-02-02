using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovePipe : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "PipeScoe")
        {
            Destroy(target.gameObject);
        }
    }
}
