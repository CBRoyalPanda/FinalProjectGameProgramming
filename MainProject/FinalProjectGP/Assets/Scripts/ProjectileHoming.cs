using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHoming : MonoBehaviour
{
    public Transform target;
    public float speed = 2f;

    private float minDistance = 1f;
    private float range;

    void Start()
    {
        
    }


    void Update()
    {
        // Measures the distance between the projectile and the player
        range = Vector2.Distance(transform.position, target.position);

        if (range > minDistance)
        {
            //Move the projectile towards the player
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {
            //Destroy the projectile after it collides
            Destroy(gameObject);
        }
    }

    void DestroyObjectDelayed()
    {
        Destroy(gameObject, 10);
    }
}
