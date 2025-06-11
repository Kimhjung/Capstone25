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
            //���콺 Ŭ���� ��ǥ�� ��������
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //�ش� ��ǥ�� �ִ� ������Ʈ ã��
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
            Debug.Log("�浹 Wall");
            //�̵��������� ĳ���� ������
            transform.localScale = new Vector2(-1, 1);
            //���� ������ �ݴ�������� �̵�
            rigid.velocity = new Vector2(Random.Range(0.5f, 1.5f), 0);
        }

        if (other.collider.tag == "WallR")
        {
            Debug.Log("�浹 Wall");
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