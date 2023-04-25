using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsTarget : MonoBehaviour
{
    public Transform target;
    public float movementSpeed = 5f;

    void Update()
    {
        // Calculate the direction towards the target
        Vector2 direction = target.position - transform.position;

        // Calculate the movement vector
        Vector2 movement = direction.normalized * movementSpeed * Time.deltaTime;

        // Move towards the target
        transform.position += (Vector3)movement;

        // Rotate towards the target
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}