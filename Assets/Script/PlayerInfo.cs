using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public GameObject Monster;
    
    public string PlayerName;
    public int Current_HP;  //캐릭터 현재 체력
    public int HP;          // 캐릭터 총 체력

    public int Attack;

    public Text _Name;      // ui상의 캐릭터 이름
    public Text _HP;        // ui상의 캐릭터 HP

    public Animator Anim;

    private void Start()
    {
        _Name.text = PlayerName;
        _HP.text = Current_HP + "/" + HP;

        Monster = GameObject.FindGameObjectWithTag("Monster");
    }

    private void Update()
    {
        if(Monster != null)
        {
            if (Monster.GetComponent<MonsterInfo>().Current_HP > 0)
            {
                Anim.SetInteger("AnimState", 2);
            }
        }
        else
        {
            Anim.SetInteger("AnimState", 0);
        }
    }

    //애니메이션 재생 타이밍에 함수 호출
    public void AttackMonster()
    {
        if(Monster.GetComponent<MonsterInfo>().Current_HP > 0)
        {
            Monster.GetComponent<MonsterInfo>().Current_HP -= Attack;
        }
        
    }
}
