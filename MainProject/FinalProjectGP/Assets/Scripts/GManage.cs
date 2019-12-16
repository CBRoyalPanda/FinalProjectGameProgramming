using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManage : MonoBehaviour
{
    // Player Object
    public GameObject player;

    // Tracks Player Position
    Vector3 position;

    // Takes the cameras coordinates
    float leftSide = 0.0f;
    float rightSide = 0.0f;

    // The player must disapear completely before appearing on the other side
    float buffer = 1.0f;
    float distanceZ = 10.0f;

    //Projectile
    public GameObject Projectile;

    // Start is called before the first frame update
    void Start()
    {
        // Uses a specific distance
        leftSide = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, distanceZ)).x;
        rightSide = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, distanceZ)).x;

        Instantiate(Projectile, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        position = player.transform.position;
        if (position.x < leftSide - buffer)
        {
            position.x = rightSide - buffer;
            player.transform.position = position;
        }
        if (position.x > rightSide + buffer)
        {
            position.x = leftSide + buffer;
            player.transform.position = position;
        }

        // set new position
        player.transform.position = position;
        position = player.transform.position;

        
        
      


    }

}
