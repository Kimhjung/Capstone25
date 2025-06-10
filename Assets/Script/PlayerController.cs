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
        // 공격 입력
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("isAttck");
            isAttack = true;
        }

        // 공격 중이 아닐 때만 이동 입력 받기
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

        // 이동 방향에 따라 좌우 반전
        if (H < 0.0f)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (H > 0.0f)
        {
            transform.localScale = new Vector2(-1, 1);
        }

        // 이동 애니메이션
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

    // 애니메이션 이벤트에서 호출할 함수
    public void EndAttack()
    {
        isAttack = false;
    }
}
