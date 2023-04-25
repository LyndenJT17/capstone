using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Transform firePoint; // Position where bullets will be spawned
    public GameObject bulletPrefab; // Prefab of the bullet that will be spawned
    public float bulletSpeed = 10f; // Speed of the bullets
    public float fireRate = 1f; // Rate of fire
    public float spreadAngle = 15f; // Angle at which the bullets will spread
    public Transform target; // Target for the enemy to aim at
    public float rotationSpeed = 5f; // Speed at which the enemy rotates towards the target
    public float moveSpeed = 5f; // Speed at which the enemy moves towards the target
    private float nextFireTime; // Time when the next shot can be fired
    public float movementSpeed = 5f;
    void Update()
    {
        if (Time.time > nextFireTime)
        {
            // Set the next fire time based on the fire rate
            nextFireTime = Time.time + 1f / fireRate;

            // Create a rotation that points towards the target
            Vector3 targetDirection = target.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, targetDirection);

            // Rotate towards the target with the given rotation speed
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Move towards the target with the given movement speed
            Vector3 movementDirection = targetDirection.normalized;
            transform.position += movementDirection * movementSpeed * Time.deltaTime;

            // Spawn 3 bullets with different directions based on the spread angle
            Quaternion spreadAngle1 = Quaternion.AngleAxis(spreadAngle, Vector3.forward);
            Quaternion spreadAngle2 = Quaternion.AngleAxis(-spreadAngle, Vector3.forward);
            Vector3 bulletDirection1 = spreadAngle1 * targetDirection.normalized;
            Vector3 bulletDirection2 = spreadAngle2 * targetDirection.normalized;
            SpawnBullet(bulletDirection1);
            SpawnBullet(targetDirection.normalized);
            SpawnBullet(bulletDirection2);
        }
    }

    // Spawns a bullet in the specified direction
    void SpawnBullet(Vector3 direction)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
}