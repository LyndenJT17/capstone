using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 2.0f;
    public float bulletLifetime = 5.0f;
    public float waitTime;
    public int bulletCount = 10;
    private bool canShoot = true;
    private Transform playerTransform;
    public float shootingRange = 10.0f;
    public Vector3 spawnPosition;
    public Transform prefab;
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        // Check if player is within shooting range
        float distanceToPlayer = Vector2.Distance(transform.position, playerTransform.position);
        if (distanceToPlayer <= shootingRange && canShoot)
        {
            StartCoroutine(ShootBullets());
            SpawnGameObject(prefab, spawnPosition);
        }

        // Aim at player
        Vector2 direction = playerTransform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    public void SpawnGameObject(Transform prefab, Vector3 position)
    {
        Instantiate(prefab, position, Quaternion.Euler(0f, 0f, 90f));
    }
    IEnumerator ShootBullets()
    {
        canShoot = false;

        int pattern = Random.Range(1, 4); // Choose a random bullet pattern

        switch (pattern)
        {
            case 1:
                // Pattern 1: Single bullet aimed at player
                Debug.Log("screen");
                StartCoroutine(ZigzagScreenFill());
                break;

            case 2:
                // Pattern 2: Spiral of bullets
                Debug.Log("spiral");
                StartCoroutine(SpiralBullets());
                break;

            case 3:
                // Pattern 3: Burst of bullets aimed at player
                Debug.Log("burst");
                StartCoroutine(BurstBulletsAtPlayer());
                break;
        }
        
        yield return new WaitForSeconds(waitTime); 
        canShoot = true;
    }
    IEnumerator ZigzagScreenFill()
    {
        float bulletDelay = 0.05f;
        float bulletSpread = 160.0f;
        float bulletSpeed = 1.0f;
        float bulletLifetime = 10.0f;

        for (int i = 0; i < 60; i++)
        {
            for (float j = -5.5f; j <= 5.5f; j += 8f)
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                Vector2 direction = new Vector2(j, -10.0f);

                float bulletAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + Random.Range(-bulletSpread, bulletSpread);
                bullet.transform.rotation = Quaternion.AngleAxis(bulletAngle, Vector3.forward);
                Vector2 bulletDirection = new Vector2(Mathf.Cos(bulletAngle * Mathf.Deg2Rad), Mathf.Sin(bulletAngle * Mathf.Deg2Rad));
                bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * bulletSpeed;

                Destroy(bullet, bulletLifetime);
            }

            yield return new WaitForSeconds(bulletDelay);
        }
    }
    void ShootBulletAtPlayer()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        Vector2 direction = playerTransform.position - transform.position;
        direction.Normalize();

        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

        // Rotate bullet towards its direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        Destroy(bullet, bulletLifetime);
    }

    IEnumerator SpiralBullets()
    {

        float bulletDelay = 0.1f;
        float bulletSpread = 360.0f;
        float anglePerBullet = bulletSpread / bulletCount;

        for (int i = 0; i < bulletCount; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            float bulletAngle = anglePerBullet * i;
            Vector2 bulletDirection = new Vector2(Mathf.Cos(bulletAngle * Mathf.Deg2Rad), Mathf.Sin(bulletAngle * Mathf.Deg2Rad));

            bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * bulletSpeed;

            // Rotate bullet towards its direction
            float angle = Mathf.Atan2(bulletDirection.y, bulletDirection.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            Destroy(bullet, bulletLifetime);

            yield return new WaitForSeconds(bulletDelay);
        }
    }

    IEnumerator BurstBulletsAtPlayer()
    {

        float bulletDelay = 0.1f;
        float bulletSpread = 20.0f;

        for (int i = 0; i < bulletCount; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

            Vector2 direction = playerTransform.position - transform.position;
            direction.Normalize();

            float bulletAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + Random.Range(-bulletSpread, bulletSpread);
            bullet.transform.rotation = Quaternion.AngleAxis(bulletAngle, Vector3.forward);
            Vector2 bulletDirection = new Vector2(Mathf.Cos(bulletAngle * Mathf.Deg2Rad), Mathf.Sin(bulletAngle * Mathf.Deg2Rad));

            bullet.GetComponent<Rigidbody2D>().velocity = bulletDirection * bulletSpeed;

            // Rotate bullet towards its direction
            float angle = Mathf.Atan2(bulletDirection.y, bulletDirection.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            Destroy(bullet, bulletLifetime);

            yield return new WaitForSeconds(bulletDelay);
        }
    }


}