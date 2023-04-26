using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnPlayerAction : MonoBehaviour
{
    public Transform targetPosition; // the position to move the object to
    public KeyCode actionKey; // the key that triggers the action
    public float moveSpeed = 5f; // the speed at which to move the object

    private bool isMoving = false; // whether the object is currently moving
    private GameObject player; // the player object

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        // check if the action key is pressed while the player is in the trigger area
        if (Input.GetKeyDown(actionKey) && isMoving)
        {
            // start moving the object towards the target position
            StartCoroutine(MoveToTarget());
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            // set isMoving to true so the object can be moved when the action key is pressed
            isMoving = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            // set isMoving to false so the object can no longer be moved
            isMoving = false;
        }
    }

    IEnumerator MoveToTarget()
    {
        // move the object towards the target position
        while (transform.position != targetPosition.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}