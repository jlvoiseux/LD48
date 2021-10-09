using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed = 5.0f;
    public float bulletPeriod = 0.1f;
    public GameObject bulletPrefab;

    public AudioSource shootSource;
    public AudioSource hitSource;
    public AudioSource deadSource;

    public Transform sa1;
    public Transform sa2;
    float timeCount = 0;

    Vector2 direction;
    float shootState;

    float topCameraLimit;
    float bottomCameraLimit;
    float leftCameraLimit;
    float rightCameraLimit;

    float topPlayerLimit = 4.44f;
    float bottomPlayerLimit = -4.44f;
    float leftPlayerLimit = -8.32f;
    float rightPlayerLimit = 8.32f;

    int initialHp = 150;
    int hp;
    float blinkingLength = 0.05f;

    SpriteRenderer sr;
    bool hit = false;
    float countHit = 0f;
    SceneFader sf;
    Image hpBar;
    bool gameOver = false;


    // Start is called before the first frame update
    void Start()
    {
        hp = initialHp;
        sr = GetComponentInChildren<SpriteRenderer>();
        sf = Camera.main.GetComponent<SceneFader>();
        hpBar = GameObject.FindGameObjectWithTag("HPTextField").GetComponent<Image>();

        PlayerPrefs.SetInt("Dead", 0);

        Vector3 p0 = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        leftCameraLimit = p0.x;
        bottomCameraLimit = p0.y;

        Vector3 p1 = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));
        rightCameraLimit = p1.x;
        topCameraLimit = p1.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (!sf.isFading)
        {
            MoveCharacter();
            Shoot();

            if (hp <= 0)
            {
                sf.FadeIn();
                PlayerPrefs.SetInt("Dead", 1);
                gameOver = true;
                SceneManager.LoadScene("GameOver");
                Destroy(gameObject);
                
            }
            if (hit)
            {
                sr.color = Color.red;
                countHit += Time.deltaTime;
            }
            if (countHit > blinkingLength)
            {
                countHit = 0;
                sr.color = Color.white;
                hit = false;
            }
        }
        else
        {
            transform.position += new Vector3(0, 1 * speed * Time.deltaTime, 0);
        }    
    
    }

    
    public void Shoot()
    {
        if(Input.GetButton("Fire1"))
        {
            if(!shootSource.isPlaying)
                shootSource.Play();
            timeCount += Time.deltaTime;
            if(timeCount > bulletPeriod)
            {
                timeCount = 0;
                Instantiate(bulletPrefab, sa1.position, Quaternion.identity);
                Instantiate(bulletPrefab, sa2.position, Quaternion.identity);
            }
        }
        else
        {
            timeCount = bulletPeriod;
        }
    }

    public void MoveCharacter()
    {
        float tempH = 0;
        float tempV = 0;

        if(Input.GetAxisRaw("Horizontal") > 0.2f)
        {
            tempH = 1;
        }
        else if (Input.GetAxisRaw("Horizontal") < -0.2f)
        {
            tempH = -1;
        }

        if (Input.GetAxisRaw("Vertical") > 0.2f)
        {
            tempV = 1;
        }
        else if (Input.GetAxisRaw("Vertical") < -0.2f)
        {
            tempV = -1;
        }

        if(tempH == 1 && tempV == 0)
        {
            direction = new Vector2(tempH, tempV);
        }
        else if(tempH == 1 && tempV == 1)
        {
            direction = new Vector2(0.7f, 0.7f);
        }
        else if (tempH == 0 && tempV == 1)
        {
            direction = new Vector2(tempH, tempV);
        }
        else if (tempH == -1 && tempV == 1)
        {
            direction = new Vector2(-0.7f, 0.7f);
        }
        else if (tempH == -1 && tempV == 0)
        {
            direction = new Vector2(tempH, tempV);
        }
        else if (tempH == -1 && tempV == -1)
        {
            direction = new Vector2(-0.7f, -0.7f);
        }
        else if (tempH == 0 && tempV == -1)
        {
            direction = new Vector2(tempH, tempV);

        }
        else if (tempH == 1 && tempV == -1)
        {
            direction = new Vector2(0.7f, -0.7f);
        }
        else
        {
            direction = new Vector2(tempH, tempV);
        }

        if (direction.x < 0)
        {
            if (transform.position.x > leftPlayerLimit)
            {
                transform.position += new Vector3(direction.x * speed * Time.deltaTime, 0, 0);
            }
            else
            {
                transform.position = new Vector3(leftPlayerLimit, transform.position.y, 0);
            }
        }

        if (direction.x > 0)
        {
            if (transform.position.x < rightPlayerLimit)
            {
                transform.position += new Vector3(direction.x * speed * Time.deltaTime, 0, 0);

            }
            else
            {
                transform.position = new Vector3(rightPlayerLimit, transform.position.y, 0);
            }
        }

        if (direction.y < 0)
        {
            if (transform.position.y > bottomPlayerLimit)
            {
                transform.position += new Vector3(0, direction.y * speed * Time.deltaTime, 0);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, bottomPlayerLimit, 0);
            }
        }

        if (direction.y > 0)
        {
            if (transform.position.y < topPlayerLimit)
            {
                transform.position += new Vector3(0, direction.y * speed * Time.deltaTime, 0);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, topPlayerLimit, 0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9 || collision.gameObject.layer == 11)
        {
            if (!sf.isFading)
            {
                hp--;
                hit = true;
                hpBar.fillAmount -= 1f / initialHp;
                if (!hitSource.isPlaying)
                    hitSource.Play();
            }     

        }
        if(collision.gameObject.layer == 11)
        {
            Destroy(collision.gameObject);
        }
        
    }
}
