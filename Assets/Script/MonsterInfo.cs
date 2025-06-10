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
            Debug.Log("¸ó½ºÅÍ »ç¸Á");
        }
    }
}
