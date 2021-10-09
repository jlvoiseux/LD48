using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemTextManager : MonoBehaviour
{

    Text currText;
    float counter = 0;
    bool textFlag = false;
    float ttl = 3;

    // Start is called before the first frame update
    void Start()
    {
        currText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!textFlag && currText.text != "")
        {
            textFlag = true;
        }

        if (textFlag)
        {
            counter += Time.deltaTime;
            if(counter > ttl)
            {
                counter = 0;
                textFlag = false;
                currText.text = "";
            }
        }


    }
}
