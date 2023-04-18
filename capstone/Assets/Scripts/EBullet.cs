using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EBullet : MonoBehaviour
{
    private Vector2 moveDirection;
    public float moveSpeed = 5f;
    public float lifespan = 10f;
    public float damage = 5f;
    // Start is called before the first frame update
    private void OnEnable()
    {
        Invoke("Destroy", lifespan);
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
        transform.Translate(moveDirection * moveDirection * moveSpeed * Time.deltaTime);
    }

    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }
    private void Destroy()
    {
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        CancelInvoke();
    }
    
}
