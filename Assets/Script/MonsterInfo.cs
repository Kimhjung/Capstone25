using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class MonsterInfo : MonoBehaviour
{
    public GameObject Player;
    public string MonsterName;

    public int Current_HP;
    public int HP;

    public int Attack;

    public Text _Name;
    public Text _HP;

    public Animator Anim;

    void Start()
    {
        _Name.text = MonsterName;
       
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        _HP.text = Current_HP + "/" + HP;

        if(Current_HP <= 0)
        {
            Anim.SetInteger("AnimState", 99);
            Player.GetComponent<PlayerInfo>().Monster = null;

            _HP.gameObject.SetActive(false);
            _Name.gameObject.SetActive(false);
        }
    }

    //오브젝트 비활성화 후 부활
    public void OffObj()
    {
        this.gameObject.SetActive(false);

        Invoke("Regan",2);
    }
    
    // 부활 세팅
    public void Regan()
    {
        Current_HP = HP;
        _HP.gameObject.SetActive(true);
        _Name.gameObject.SetActive(true);

        this.gameObject.SetActive(true);

        Player.GetComponent<PlayerInfo>().Monster = this.gameObject;
    }
}
