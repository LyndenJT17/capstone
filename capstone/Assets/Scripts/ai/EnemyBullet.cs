using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float bulletSpeed = 10f;
    public int bulletDamage = 10;
    public float bulletLifeTime = 3f;

    public float spreadAngle = 30f;

    public GameObject bulletPrefab;

    public void Fire()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject bulletInstance = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            float angle = spreadAngle * (i - 1);
            Vector2 direction = Quaternion.Euler(0, 0, angle) * transform.right;
            bulletInstance.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

            Destroy(bulletInstance, bulletLifeTime);
        }
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