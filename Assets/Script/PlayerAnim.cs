using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    public float speed = 300f;

    float H, V;

    Rigidbody2D rigid;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        H = Input.GetAxisRaw("Horizontal");
        V = Input.GetAxisRaw("Vertical");

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            anim.SetTrigger("isAtck");
            anim.SetBool("atck_ing", true);
        }
        else
        {
            anim.SetBool("atck_ing", false);
        }
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            anim.SetBool("isMove", true);
        }
        else
        {
            anim.SetBool("isMove", false);
        }
    }
}
