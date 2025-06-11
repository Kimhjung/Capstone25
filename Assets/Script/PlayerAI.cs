using UnityEngine;

public class PlayerAI : MonoBehaviour
{
    public float moveSpeed;
    public float attackRange;
    public float attackCooldown;
    public int attackDamage;

    private float lastAttackTime;
    public GameObject currentTarget;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    

    void Start()
    {
        PlayerInfo info = GetComponent<PlayerInfo>();

        moveSpeed = info.speed;
        attackRange = info.attackRange;
        attackCooldown = info.attackCooldown;
        attackDamage = info.attackDamage;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        
    }

    void Update()
    {
        if (currentTarget == null || currentTarget.GetComponent<MonsterInfo>()?.Current_HP <= 0)
        {
            FindNewTarget();
        }

        if (currentTarget != null)
        {
            float distance = Vector2.Distance(transform.position, currentTarget.transform.position);
            Vector2 dir = (currentTarget.transform.position - transform.position).normalized;

            if (distance > attackRange)
            {
                // �̵�
                rb.velocity = dir * moveSpeed;
                anim?.SetBool("isMove", true);

                if (dir.x != 0)
                    spriteRenderer.flipX = dir.x < 0;
            }
            else
            {
                // ����
                rb.velocity = Vector2.zero;
                anim?.SetBool("isMove", false);

                if (Time.time >= lastAttackTime + attackCooldown)
                {
                    Attack();
                    lastAttackTime = Time.time;
                }
            }
        }
        else
        {
            // Ÿ���� ������ ���
            rb.velocity = Vector2.zero;
            anim?.SetBool("isMove", false);
        }
    }

    public void FindNewTarget()
    {
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");
        float closestDistance = Mathf.Infinity;
        GameObject closest = null;

        foreach (var monster in monsters)
        {
            var info = monster.GetComponent<MonsterInfo>();
            if (info != null && info.Current_HP > 0)
            {
                float d = Vector2.Distance(transform.position, monster.transform.position);
                if (d < closestDistance)
                {
                    closestDistance = d;
                    closest = monster;
                }
            }
        }

        currentTarget = closest;
    }

    void Attack()
    {
        Debug.Log("�÷��̾� ����!");

        var monster = currentTarget.GetComponent<MonsterInfo>();
        if (monster != null)
        {
            monster.Current_HP -= attackDamage;
            Debug.Log("���� ü��: " + monster.Current_HP);
        }

        anim?.SetTrigger("isAttck");
    }
}