using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    public float moveSpeed;
    public float attackCooldown;
    public int attackDamage;

    private float lastAttackTime;
    private Transform playerTransform;
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    private bool isTouchingPlayer = false;

    void Start()
    {
        MonsterInfo info = GetComponent<MonsterInfo>();
        moveSpeed = info.speed;
        attackCooldown = info.attackCooldown;
        attackDamage = info.attackDamage;


        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
            playerTransform = player.transform;
    }

    void Update()
    {
        
        Vector2 dir = (playerTransform.position - transform.position).normalized;

        if (isTouchingPlayer)
        {
            rb.velocity = Vector2.zero;
            anim?.SetBool("isMove", false);

            if (Time.time >= lastAttackTime + attackCooldown)
            {
                Attack();
                lastAttackTime = Time.time;
            }
        }
        else
        {
            rb.velocity = dir * moveSpeed;
            anim?.SetBool("isMove", true);

            if (dir.x != 0)
                spriteRenderer.flipX = dir.x > 0;
        }
    }

    void Attack()
    {
        Debug.Log("몬스터 공격!");

        //죽었으면(hp == 0)  공격 x
        MonsterInfo info = GetComponent<MonsterInfo>();
        if (info != null && info.Current_HP <= 0)
        {
            Die();
            return;
        }

        PlayerInfo player = playerTransform.GetComponent<PlayerInfo>();
        if (player == null || player.Current_HP <= 0) return;

        player.Current_HP -= attackDamage;
        Debug.Log("플레이어 체력: " + player.Current_HP);
        
        anim?.SetTrigger("isAttack");
    }

    public void Die()
    {
        Debug.Log("몬스터 사망");

        // 죽는 애니메이션만 실행
        GetComponent<Animator>()?.SetTrigger("isDead");

        // 물리 정지
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        // 타겟 제거
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            var ai = player.GetComponent<PlayerAI>();
            if (ai != null && ai.currentTarget == this.gameObject)
            {
                ai.currentTarget = null;
                ai.FindNewTarget();
            }
        }

        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTouchingPlayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTouchingPlayer = false;
        }
    }
}