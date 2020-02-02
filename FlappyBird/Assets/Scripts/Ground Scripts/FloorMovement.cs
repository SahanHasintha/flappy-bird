using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorMovement : MonoBehaviour
{
    public float xBound;
    public Bird bird;

    void Awake()
    {
        bird = GameObject.FindObjectOfType <Bird> ();
    }
    void Update()
    {
        if (transform.localPosition.x <= xBound)
        {
            //mehidi floor eke position eke x 3.9ta wada adu unama if statement eka athulata pamine.
            //in pasu x sadaha 0 laba dii aththe mema floor eke position eke x parent object eke x ta sapekshawa 0 wiya yuthu bawai.
            //Enam local position main camera eken iwathata yaa nohaka.
            //E kynne main camera eka saha floor eke x athara wenasak nathi wiya yuthuyi.

            transform.localPosition = new Vector3(0, transform.localPosition.y, transform.localPosition.z);
        }
        if (!bird.hasBirdDead)
        {
            transform.Translate(-Time.deltaTime, 0, 0);
        }
        
        
    }
}
