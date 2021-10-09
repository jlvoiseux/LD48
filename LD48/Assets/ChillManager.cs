using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChillManager : MonoBehaviour
{

    public int num;
    public bool nextPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(nextPressed && !Camera.main.GetComponent<SceneFader>().isFading)
        {
            if (num == 0)
            {
                SceneManager.LoadSceneAsync("Chill1");
            }
            if (num == 1)
            {
                SceneManager.LoadSceneAsync("Fight1");
            }
            if (num == 2)
            {
                SceneManager.LoadSceneAsync("Fight2");
            }
            if (num == 3)
            {
                SceneManager.LoadSceneAsync("Fight3");
            }
            if (num == 4)
            {
                SceneManager.LoadSceneAsync("Menu");
            }
        }
        
    }

    public void LoadNext()
    {
        if (!nextPressed)
        {
            Camera.main.GetComponent<SceneFader>().FadeIn();
            nextPressed = true;
        }
        

    }
}
