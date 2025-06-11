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

        Debug.Log("������ ����: " + amount);
        Current_HP -= amount;

        Debug.Log("���� ���� HP: " + Current_HP);

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

        Debug.Log("���� ���");

        // �ִϸ��̼�
        GetComponent<Animator>()?.SetTrigger("isDead");

        // �̵� ����
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        // AI ����
        foreach (var ai in MonsterAI)
        {
            if (ai != null)
                ai.enabled = false;
        }

        // Ÿ�� ����
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

        // ���� �ð� �� ����
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
            Debug.LogWarning("SpriteRenderer �� ã��");
        }
    }

    IEnumerator BlinkRed(SpriteRenderer sr)
    {
        Debug.Log("BlinkRed ����");
        Color originalColor = sr.color;
        sr.color = new Color(1f, 0.5f, 0.5f, 1f);   //������
        yield return new WaitForSeconds(0.1f);
        sr.color = originalColor;
    }

    IEnumerator Disappear(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false); // �Ǵ� Destroy(gameObject);
    }
}
