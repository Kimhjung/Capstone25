using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public GameObject Monster;
    
    public string PlayerName;
    public int Current_HP;  //ĳ���� ���� ü��
    public int HP;          // ĳ���� �� ü��

    public int Attack;

    public Text _Name;      // ui���� ĳ���� �̸�
    public Text _HP;        // ui���� ĳ���� HP

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

    //�ִϸ��̼� ��� Ÿ�ֿ̹� �Լ� ȣ��
    public void AttackMonster()
    {
        if(Monster.GetComponent<MonsterInfo>().Current_HP > 0)
        {
            Monster.GetComponent<MonsterInfo>().Current_HP -= Attack;
        }
        
    }
}
