using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] public float lifeTime = 3f;
    public float criticalStrikeChance = 0.1f;
    public int bulletDamage;
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
        if (other.gameObject.tag == "Enemy")
        {
            if (Random.value < criticalStrikeChance)
            {
                other.gameObject.GetComponent<EnemyHealth>().damageEnemy(bulletDamage * 2); // Double damage for critical strike
            }
            else
            {
                other.gameObject.GetComponent<EnemyHealth>().damageEnemy(bulletDamage);
            }
            Destroy(gameObject);
        }
        

    }
}
