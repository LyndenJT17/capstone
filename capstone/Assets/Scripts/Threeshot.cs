using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Threeshot : MonoBehaviour
{
    public float shotDeviation = .2f;
    public List<Vector3> shots;
    public float delay = 0f;
    public GameObject bulletPrefab;

    public float shootInterval;

    // Start is called before the first frame update
    void Start()
    {
        shots = new List<Vector3> {
        new Vector3(0, 0, 0),
        new Vector3(0, -shotDeviation, 0),
        new Vector3(0, shotDeviation, 0),
        new Vector3(0, -shotDeviation -10, 0),
        new Vector3(0, shotDeviation +10, 0),
        new Vector3(0, -shotDeviation -5, 0),
        new Vector3(0, shotDeviation +5, 0),
        new Vector3(0, -shotDeviation -6, 0),
        new Vector3(0, shotDeviation +6, 0),
        //new Vector3(shotDeviation, 0, 0),
        //new Vector3(shotDeviation, shotDeviation, 0),
        
        //new Vector3(-shotDeviation, shotDeviation, 0),
        //new Vector3(-shotDeviation, 0, 0),
        //new Vector3(-shotDeviation, -shotDeviation, 0),
        
        //new Vector3(shotDeviation, -shotDeviation, 0)
        };

        InvokeRepeating("Fire", delay, shootInterval);

    }

    void Fire()
    {
        foreach (var shot in shots)
        {
            Vector3 angle = (transform.TransformDirection(Vector3.forward) + shot);
            Debug.Log("angle: " + angle);
            Debug.DrawRay(transform.position, angle, Color.red);

            Vector3 rot = transform.rotation.eulerAngles + shot;

            Instantiate(bulletPrefab, transform.position, Quaternion.Euler(rot), null);
        }
    }
}