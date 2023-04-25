using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBDamage : MonoBehaviour
{
    public int bulletDamage;
    [SerializeField] public float lifeTime = 3f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        Destroy(gameObject, lifeTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().damagePlayer(bulletDamage);
            Destroy(gameObject);
        }
    }
}