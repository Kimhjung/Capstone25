using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomMove : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rigid;

    void Start()
    {
        StartCoroutine(RandomMove());
    }

<<<<<<< HEAD
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //마우스 클릭한 좌표값 가져오기
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //해당 좌표에 있는 오브젝트 찾기
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);

            if (hit.collider != null)
            {
                GameObject click_obj = hit.transform.gameObject;
                Debug.Log("click " + click_obj.name);
                //StartCoroutine(StopMove());
            }
        }
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "WallL")
        {
            Debug.Log("충돌 Wall");
            //이동방향으로 캐릭터 뒤집기
            transform.localScale = new Vector2(-1, 1);
            //벽에 닿으면 반대방향으로 이동
            rigid.velocity = new Vector2(Random.Range(0.5f, 1.5f), 0);
        }

        if (other.collider.tag == "WallR")
        {
            Debug.Log("충돌 Wall");
            transform.localScale = new Vector2(1, 1);
            rigid.velocity = new Vector2(Random.Range(-1.5f, -0.5f), 0);

        }
    }
=======

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "WallLeft")
        {
            Debug.Log("Collision " + other.gameObject.name + " left");
            transform.localScale = new Vector2(-1, 1);
            rigid.velocity = new Vector2(50f, 0);
        }
        else if (other.collider.tag == "WallRight")
        {
            Debug.Log("Collision "+ other.gameObject.name + " right");
            transform.localScale = new Vector2(1, 1);
            rigid.velocity = new Vector2(-50f, 0);
        }
    }

>>>>>>> 915e8c3a991972e7591127e38ad686e03857de4f
    IEnumerator RandomMove()
    {
        rigid=GetComponent<Rigidbody2D>();

        while (true)
        {
            float dir = Random.Range(-100f, 100f);

            rigid.velocity = new Vector2(dir, 0);

            if (dir <= 0)
            {
                transform.localScale = new Vector2(1, 1);
            }
            else if (dir >= 0)
            {
                transform.localScale = new Vector2(-1, 1);
            }
<<<<<<< HEAD
=======

>>>>>>> 915e8c3a991972e7591127e38ad686e03857de4f
            yield return new WaitForSeconds(3);
        }
        
    }

    /*IEnumerator StopMove()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        while (true) 
        {
            rigid.velocity = new Vector2(0, 0);
            anim.speed = 0;
        }
        yield return new WaitForSeconds(0f);
        
    }*/
}