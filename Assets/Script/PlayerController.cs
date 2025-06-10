using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    private float H, V;
    private Rigidbody2D rigid;
    private Animator anim;

    public bool isAttack = false;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // ���� �Է�
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("isAttck");
            isAttack = true;
        }

        // ���� ���� �ƴ� ���� �̵� �Է� �ޱ�
        if (!isAttack)
        {
            H = Input.GetAxisRaw("Horizontal");
            V = Input.GetAxisRaw("Vertical");
        }
        else
        {
            H = 0;
            V = 0;
        }

        // �̵� ���⿡ ���� �¿� ����
        if (H < 0.0f)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (H > 0.0f)
        {
            transform.localScale = new Vector2(-1, 1);
        }

        // �̵� �ִϸ��̼�
        if (!isAttack && (H != 0 || V != 0))
        {
            anim.SetBool("isMove", true);
        }
        else
        {
            anim.SetBool("isMove", false);
        }
    }

    void FixedUpdate()
    {
        rigid.velocity = new Vector2(H, V) * speed;
    }

    // �ִϸ��̼� �̺�Ʈ���� ȣ���� �Լ�
    public void EndAttack()
    {
        isAttack = false;
    }
}
