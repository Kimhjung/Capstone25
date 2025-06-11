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
        // ���� �Է�
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
            anim.SetTrigger("isAttck");
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
            transform.localScale = new Vector2(-1, 1);
        }
        else if (H > 0.0f)
        {
            transform.localScale = new Vector2(1, 1);
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

    public void Attack()
    {
        // "Monster" �±׸� ���� ������Ʈ�� �˻�
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

                //������ �ֱ�
                MonsterInfo info = monster.GetComponent<MonsterInfo>();
                if (info != null && info.Current_HP > 0)
                    {
                    info.TakeDamage(attackDamage);
                    Debug.Log("���Ϳ��� ������ ��!");
                        break; // �� ������ ����
                    }
            }
        }
    }

    IEnumerator BlinkRed(SpriteRenderer renderer)
    {
        Color original = renderer.color;
        renderer.color = new Color(1f, 0.4f, 0.4f);  // ���� ����
        yield return new WaitForSeconds(0.15f);
        renderer.color = original;
    }

    // �ִϸ��̼� �̺�Ʈ���� ȣ���� �Լ�
    public void EndAttack()
    {
        isAttack = false;
    }
}
