using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] private float lifeTime = 3f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject, lifeTime);
    }
}
