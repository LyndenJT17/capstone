using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spreadshotEnemy : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    public float bulletSpeed = 10f;
    public float fireRate = 1f;

    private float timeUntilNextFire = 0f;

    void Update()
    {
        if (timeUntilNextFire <= 0)
        {
            Fire();
            timeUntilNextFire = 1f / fireRate;
        }
        else
        {
            timeUntilNextFire -= Time.deltaTime;
        }
    }

    private void Fire()
    {
        Vector3[] bulletDirections = new Vector3[] { Vector3.up, Vector3.right, Vector3.down };

        foreach (Vector3 direction in bulletDirections)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        }
    }
}