using System.Collections;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public int Current_HP = 1000;
    public int Max_HP = 1000;
    public float speed = 5f;
    public float attackRange = 10;          //���ݹ���
    public float attackCooldown = 1f;
    public int attackDamage = 50;

    

    void Update()
    {
        if (Current_HP <= 0)
        {
            
            Debug.Log("�÷��̾� ���");
        }
    }

    public MonoBehaviour[] PlayerAI;
    public SpriteRenderer spriteRenderer;
    public float blinkDuration = 1.5f;     // �� �����̴� �ð�
    public float blinkInterval = 0.2f;      // ������ ����

    void Die()
    {
        Debug.Log("�÷��̾� ���");

        foreach (MonoBehaviour script in PlayerAI)
        {
            if (script != null)
                script.enabled = false;
        }
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        if (spriteRenderer != null)
            StartCoroutine(BlinkRed());
    }

    IEnumerator BlinkRed()
    {
        Color originalColor = spriteRenderer.color;
        Color redColor = new Color(1f, 0.2f, 0.2f, 1f);

        float timer = 0f;
        while (timer < blinkDuration)
        {
            spriteRenderer.color = redColor;
            yield return new WaitForSeconds(blinkInterval / 2);

            spriteRenderer.color = originalColor;
            yield return new WaitForSeconds(blinkInterval / 2);

            timer += blinkInterval;
        }

        spriteRenderer.color = originalColor;
    }

}