using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Pixelnest.BulletML;
using UnityEngine;

public class TimeManagerBoss : MonoBehaviour
{
    public BulletSourceScript bss;
    public EnemyBehavior boss;
    public List<TextAsset> orderedPatterns;

    public float startTime;
    public float timePattern0;
    public float timePattern1;
    public float timePattern2;
    public float timePattern3;

    public float timeToEnd;

    public float currTime = 0;
    public bool endStarted = false;

    int currPattern = 3;
    bool bossDead = false;

    // Start is called before the first frame update
    void Start()
    {

        Camera.main.GetComponent<SceneFader>().FadeOut();
        PlayerPrefs.SetString("CurrScene", SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;

        if(bossDead && currTime > timeToEnd)
        {
            endStarted = true;
            //GameObject.FindGameObjectWithTag("BGCamera").GetComponent<Diver>().Dive();
            Camera.main.GetComponent<SceneFader>().FadeIn();
            
        }

        if (endStarted && !Camera.main.GetComponent<SceneFader>().isFading)
        {
            SceneManager.LoadScene("Chill4");
        }

        if (boss.hp <= 0 && !bossDead)
        {
            currTime = 0;
            bossDead = true;
            bss.xmlFile = orderedPatterns[4];
            bss.ParsePattern(true);
            bss.Initialize();
        }
        else
        {
            if (currPattern == 3 && currTime > startTime)
            {
                currPattern = 0;
                currTime = 0;
                bss.xmlFile = orderedPatterns[currPattern];
                bss.ParsePattern(true);
                bss.Initialize();
            }
            if (currPattern == 0 && currTime > timePattern0)
            {
                currPattern = 1;
                currTime = 0;
                bss.xmlFile = orderedPatterns[currPattern];
                bss.ParsePattern(true);
                bss.Initialize();
            }
            if (currPattern == 1 && currTime > timePattern1)
            {
                currPattern = 2;
                currTime = 0;
                bss.xmlFile = orderedPatterns[currPattern];
                bss.ParsePattern(true);
                bss.Initialize();
            }
            if (currPattern == 2 && currTime > timePattern2)
            {
                currPattern = 3;
                currTime = 0;
                bss.xmlFile = orderedPatterns[currPattern];
                bss.ParsePattern(true);
                bss.Initialize();
            }
        }
        
    }
}
