using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Dead", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TryAgain()
    {
        Camera.main.GetComponent<SceneFader>().FadeIn();
        SceneManager.LoadScene(PlayerPrefs.GetString("CurrScene"));
    }
}
