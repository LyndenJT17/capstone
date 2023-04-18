using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [Range(1, 10)]
    [SerializeField] private float lifeTime = 3f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
	if (collision.gameObject.tag == "Wall"){
			Destroy(gameObject);
		}
        Destroy(gameObject, lifeTime);
		
    }
}
