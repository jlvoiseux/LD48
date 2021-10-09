using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletBehavior : MonoBehaviour
{
    public float speed = 10f;
    public float ttl = 2f;
    public int damage = 1000;

    float bulletTime = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bulletTime += Time.deltaTime;
        if(bulletTime > ttl)
        {
            Destroy(gameObject);
        }

        transform.position += Vector3.up * speed * Time.deltaTime;
    }
}
