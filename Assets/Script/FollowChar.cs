using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowChar : MonoBehaviour
{
    public float leftLimit = 0f;
    public float rightLimit = 0f;
    public float topLimit = 0f;
    public float bottomLimit = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float x = player.transform.position.x;
            float y = player.transform.position.y;
            float z = transform.position.z;

            if (x < leftLimit)
            {
                x = leftLimit;
            }
            else if (x > rightLimit)
            {
                x = rightLimit;
            }
            if (y < topLimit)
            {
                y = topLimit;
            }
            else if (y > bottomLimit)
            {
                y = bottomLimit;
            }
            Vector3 v3 = new Vector3(x, y, z);
            transform.position = v3;
        }
    }
}
