using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    private float H, V;
    private Rigidbody2D rigid;
    private Animator anim;

    public float attackRange;
    public int attackDamage;

    public bool isAttack = false;

    void Start()
    {
        PlayerInfo info = GetComponent<PlayerInfo>();
        attackRange = info.attackRange;
        attackDamage = info.attackDamage;

        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // 공격 입력
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
            anim.SetTrigger("isAttck");
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
            transform.localScale = new Vector2(-1, 1);
        }
        else if (H > 0.0f)
        {
            transform.localScale = new Vector2(1, 1);
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

    public void Attack()
    {
        // "Monster" 태그를 가진 오브젝트들 검색
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");
        foreach (GameObject monster in monsters)
        {
            float distance = Vector2.Distance(transform.position, monster.transform.position);

            if (distance <= attackRange)
            {
                //
                var renderer = monster.GetComponent<SpriteRenderer>();
                if (renderer != null)
                    StartCoroutine(BlinkRed(renderer));

                //데미지 주기
                MonsterInfo info = monster.GetComponent<MonsterInfo>();
                if (info != null && info.Current_HP > 0)
                    {
                    info.TakeDamage(attackDamage);
                    Debug.Log("몬스터에게 데미지 줌!");
                        break; // 한 마리만 공격
                    }
            }
        }
    }

    IEnumerator BlinkRed(SpriteRenderer renderer)
    {
        Color original = renderer.color;
        renderer.color = new Color(1f, 0.4f, 0.4f);  // 연한 빨강
        yield return new WaitForSeconds(0.15f);
        renderer.color = original;
    }

    // 애니메이션 이벤트에서 호출할 함수
    public void EndAttack()
    {
        isAttack = false;
    }
}
