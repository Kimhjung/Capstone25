using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomMove : MonoBehaviour
{

    Rigidbody2D rigid;

    void Start()
    {
        StartCoroutine(RandomMove());
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "WallLeft")
        {
            Debug.Log("Collision" + other.gameObject.name + "left");
            transform.localScale = new Vector2(-1, 1);
            rigid.velocity = new Vector2(1.5f, 0);
        }
        else if (other.collider.tag == "WallRight")
        {
            Debug.Log("Collision"+ other.gameObject.name + "right");
            transform.localScale = new Vector2(1, 1);
            rigid.velocity = new Vector2(-1.5f, 0);
        }
    }

    IEnumerator RandomMove()
    {
        rigid=GetComponent<Rigidbody2D>();

        while (true)
        {
            float dir = Random.Range(-2f, 2f);

            yield return new WaitForSeconds(3);
            rigid.velocity = new Vector2(dir, 0);

            if (dir <= 0)
            {
                transform.localScale = new Vector2(1, 1);
            }
            else if (dir >= 0)
            {
                transform.localScale = new Vector2(-1, 1);
            }
        }
        
    }
}