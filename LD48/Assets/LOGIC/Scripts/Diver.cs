using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diver : MonoBehaviour
{

    Camera cam;
    float lerpingValue;
    float A, B;
    float time, duration;
    bool isLerping;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    


    public void Dive()
    {
        this.A = 60;
        this.B = 0;
        this.duration = 2;
        this.time = 0;
        this.isLerping = true;

        // 'move per second' value can be calculated like this
        float movePerSecond = (B - A) / duration;
    }


    void Update()
    {
        if (isLerping)
        {
            // Accumulating time
            time += Time.deltaTime;

            // determining where are we on the time line
            // flow is our time line increasing from 0 to 1
            float flow = time / duration;

            if (flow < 1)
            {
                // lerping formula
                cam.fieldOfView = A + (B - A) * flow;
            }
            else
            {
                // operation is done
                lerpingValue = B;
                isLerping = false;
            }
        }
    }

}
