using SWS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    [Header("Wave 1")]
    public splineMove pack1a;
    public float pack1aStart1 = 3f;
    public float pack1aDuration1 = 7.5f;
    public bool pack1aStarted1 = false;
    public PathManager path1a2;
    public float pack1aStart2 = 10.5f;
    public float pack1aDuration2 = 7.5f;
    public bool pack1aStarted2 = false;

    public splineMove pack1b;
    public float pack1bStart1 = 7f;
    public float pack1bDuration1 = 3f;
    public bool pack1bStarted1 = false;
    public PathManager path1b2;
    public float pack1bStart2 = 14f;
    public float pack1bDuration2 = 3f;
    public bool pack1bStarted2 = false;

    public splineMove pack1c;
    public float pack1cStart1 = 3f;
    public float pack1cDuration1 = 7.5f;
    public bool pack1cStarted1 = false;
    public PathManager path1c2;
    public float pack1cStart2 = 10.5f;
    public float pack1cDuration2 = 7.5f;
    public bool pack1cStarted2 = false;

    [Header("Wave 2")]
    public splineMove pack2a;
    public float pack2aStart = 18f;
    public float pack2aDuration = 15f;
    public bool pack2aStarted = false;

    public splineMove pack2b;
    public float pack2bStart = 18f;
    public float pack2bDuration = 15f;
    public bool pack2bStarted = false;

    [Header("Wave 3")]
    public GameObject pack3;
    public float pack3Start = 35f;
    public float pack3Duration = 25f;
    public float pack3Item = 10f;
    public bool pack3Started = false;

    public float end = 60f;
    bool endStarted = false;

    public float currTime = 0;
    int count = 0;

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

        if (!pack1aStarted1 && currTime > pack1aStart1)
        {
            pack1aStarted1 = true;
            pack1a.speed = pack1aDuration1;
            pack1a.StartMove();
        }

        if (!pack1aStarted2 && currTime > pack1aStart2)
        {
            pack1aStarted2 = true;
            pack1a.speed = pack1aDuration2;
            pack1a.SetPath(path1a2);
            pack1a.StartMove();
        }

        if (!pack1bStarted1 && currTime > pack1bStart1)
        {
            pack1bStarted1 = true;
            pack1b.speed = pack1bDuration1;
            pack1b.StartMove();
        }

        if (!pack1bStarted2 && currTime > pack1bStart2)
        {
            pack1bStarted2 = true;
            pack1b.speed = pack1bDuration2;
            pack1b.SetPath(path1b2);
            pack1b.StartMove();
        }

        if (!pack1cStarted1 && currTime > pack1cStart1)
        {
            pack1cStarted1 = true;
            pack1c.speed = pack1cDuration1;
            pack1c.StartMove();
        }

        if (!pack1cStarted2 && currTime > pack1cStart2)
        {
            pack1cStarted2 = true;
            pack1c.speed = pack1cDuration2;
            pack1c.SetPath(path1c2);
            pack1c.StartMove();
        }

        if (!pack2aStarted && currTime > pack2aStart || (pack1a.transform.childCount == 0 && pack1b.transform.childCount == 0 && pack1c.transform.childCount == 0))
        {
            pack2aStarted = true;
            pack2a.speed = pack2aDuration;
            pack2a.StartMove();
        }

        if (!pack2bStarted && currTime > pack2bStart)
        {
            pack2bStarted = true;
            pack2b.speed = pack2bDuration;
            pack2b.StartMove();
        }

        if (!pack3Started && currTime > pack3Start || (pack2a.transform.childCount == 0 && pack2b.transform.childCount == 0))
        {
            pack3Started = true;
        }

        if (pack3Started && count < pack3.transform.childCount)
        {
            if (currTime > pack3Start + count * pack3Duration / pack3.transform.childCount)
            {
                splineMove currSp = pack3.transform.GetChild(count).GetComponent<splineMove>();
                currSp.speed = pack3Item;
                currSp.StartMove();
                count++;
            }
        }

        if (!endStarted && (currTime > end || pack3.transform.childCount == 0))
        {
            endStarted = true;
            GameObject.FindGameObjectWithTag("BGCamera").GetComponent<Diver>().Dive();
            Camera.main.GetComponent<SceneFader>().FadeIn();
        }

        if(endStarted && SceneManager.GetActiveScene().name == "Fight1" && !Camera.main.GetComponent<SceneFader>().isFading)
        {
            SceneManager.LoadScene("Chill2");
        }
        else if(endStarted && SceneManager.GetActiveScene().name == "Fight2" && !Camera.main.GetComponent<SceneFader>().isFading)
        {
            SceneManager.LoadScene("Chill3");
        }

    }

}

