using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class nickBulletMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 4;
    public float damage = 5f;
    public float distance = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        setMovement(gameObject.transform.forward, speed);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        //Debug.DrawRay(transform.position, forward, Color.green);
        Destroy(gameObject, distance);
    }

    public void setMovement(Vector3 direction, float speed)
    {
        rb.velocity = Vector3.zero;
        rb.velocity = direction * speed;
    }
    

}