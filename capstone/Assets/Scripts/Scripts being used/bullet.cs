using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] public float lifeTime = 3f;
    
    public int bulletDamage;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject, lifeTime);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealth>().damageEnemy(bulletDamage);
            Destroy(gameObject);
        }
        

    }
}
