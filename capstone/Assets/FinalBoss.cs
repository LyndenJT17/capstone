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

    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (canShoot)
        {
            StartCoroutine(ShootBullets());
        }

        // Aim at player
        Vector2 direction = playerTransform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    IEnumerator ShootBullets()
    {
        canShoot = false;

        int pattern = Random.Range(1, 4); // Choose a random bullet pattern

        switch (pattern)
        {
            case 1:
                // Pattern 1: Single bullet aimed at player
                ShootBulletAtPlayer();
                break;

            case 2:
                // Pattern 2: Spiral of bullets
                StartCoroutine(SpiralBullets());
                break;

            case 3:
                // Pattern 3: Burst of bullets aimed at player
                StartCoroutine(BurstBulletsAtPlayer());
                break;
        }

        yield return new WaitForSeconds(waitTime); // Wait 5 seconds before shooting again
        canShoot = true;
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




