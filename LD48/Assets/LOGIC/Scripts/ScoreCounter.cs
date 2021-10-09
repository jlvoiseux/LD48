using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public int score;
    int initialScore;
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Fight1")
        {
            score = 0;
            initialScore = 0;
        }
        else
        {
            score = PlayerPrefs.GetInt("Score", 0);
            initialScore = PlayerPrefs.GetInt("Score", 0); 
            GameObject.FindGameObjectWithTag("ScoreTextField").GetComponent<Text>().text = score.ToString();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        if(PlayerPrefs.GetInt("Dead") == 1)
        {
            PlayerPrefs.SetInt("Score", initialScore);
        }
        else
        {
            PlayerPrefs.SetInt("Score", score);
        }
        
    }

    public void IncrementScore(int value)
    {
        score += value;
    }

    public int GetScore()
    {
        return score;
    }
}
