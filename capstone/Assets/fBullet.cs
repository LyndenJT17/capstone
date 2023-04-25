using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fBullet : MonoBehaviour
{
    public int damage = 10;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().damagePlayer(damage);
        }

        Destroy(gameObject);
    }
}
