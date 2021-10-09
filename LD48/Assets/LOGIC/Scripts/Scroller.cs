using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    float topBound = 11f;
    float bottomBound = -11f;
    float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition += Vector3.back*speed*Time.deltaTime;
        if(transform.localPosition.z < bottomBound)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, topBound);
        }
    }
}
