using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    
    public int health;
    public int currentHealth;

    public GameObject item;
    public Transform transform;

    public string spawnPointTag = "sometag";
    public bool alwaysSpawn = true;
    public List<GameObject> prefabsToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            DropItem();
        }
    }
    

    public void damageEnemy(int damage)
    {
        currentHealth -= damage;
    }
    void DropItem()
    {
        Vector2 pos = transform.position;
        //GameObject loot = Instantiate(item, pos, Quaternion.identity);

        int randomPrefab = Random.Range(0, prefabsToSpawn.Count);
        GameObject pts = Instantiate(prefabsToSpawn[randomPrefab]);
        pts.transform.position = pos;


    }
}