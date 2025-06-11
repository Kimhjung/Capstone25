using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterInfo : MonoBehaviour
{
    public int Current_HP = 100;
    public int Max_HP = 100;
    public float speed = 2;
    public float attackCooldown = 2.5f;
    public int attackDamage = 10;

    public MonoBehaviour[] MonsterAI;

    void Update()
    {
        if (Current_HP <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;

        Debug.Log("데미지 받음: " + amount);
        Current_HP -= amount;

        Debug.Log("현재 몬스터 HP: " + Current_HP);

        BlinkOnHit();

        if (Current_HP <= 0)
        {
            Die();
        }
    }

    bool isDead = false;

    public void Die()
    {
        if (isDead) return;
        isDead = true;

        Debug.Log("몬스터 사망");

        // 애니메이션
        GetComponent<Animator>()?.SetTrigger("isDead");

        // 이동 멈춤
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        // AI 멈춤
        foreach (var ai in MonsterAI)
        {
            if (ai != null)
                ai.enabled = false;
        }

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

        // 일정 시간 후 제거
        StartCoroutine(Disappear(1.5f));
    }

    public void BlinkOnHit()
    {
        SpriteRenderer sr = GetComponentInChildren<SpriteRenderer>();
        if (sr != null)
        {
            StartCoroutine(BlinkRed(sr));
        }
        else
        {
            Debug.LogWarning("SpriteRenderer 못 찾음");
        }
    }

    IEnumerator BlinkRed(SpriteRenderer sr)
    {
        Debug.Log("BlinkRed 진입");
        Color originalColor = sr.color;
        sr.color = new Color(1f, 0.5f, 0.5f, 1f);   //연빨강
        yield return new WaitForSeconds(0.1f);
        sr.color = originalColor;
    }

    IEnumerator Disappear(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false); // 또는 Destroy(gameObject);
    }
}
