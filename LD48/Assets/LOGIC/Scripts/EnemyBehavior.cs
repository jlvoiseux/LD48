using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehavior : MonoBehaviour
{
    public int hp = 5;
    float blinkingLength =0.05f;

    SpriteRenderer sr;
    bool hit = false;
    int hpLost = 0;
    float countHit = 0f;
    Text scoreText;
    ScoreCounter sc;
    AudioSource ded;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        scoreText = GameObject.FindGameObjectWithTag("ScoreTextField").GetComponent<Text>();  
        sc = GameObject.FindGameObjectWithTag("ScoreTextField").GetComponent<ScoreCounter>();
        ded = GameObject.FindGameObjectWithTag("MasterDedEffect").GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            sc.IncrementScore(hpLost);
            scoreText.text = sc.GetScore().ToString();
            if(!ded.isPlaying)
                ded.Play();
            int sib = transform.GetSiblingIndex();
            GameObject repl = Instantiate(new GameObject(), transform.parent);
            Destroy(gameObject);
            repl.transform.SetSiblingIndex(sib);
        }
        if (hit)
        {
            sr.color = Color.red;
            countHit += Time.deltaTime;
        }
        if(countHit > blinkingLength)
        {
            countHit = 0;
            sr.color = Color.white;
            hit = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if(collision.gameObject.layer == 10)
        {
            hp--;
            hpLost++;
            hit = true;
            Destroy(collision.gameObject);

        }
        
    }
}
