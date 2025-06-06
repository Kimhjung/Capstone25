using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speed = 300f;

    float H, V;

    Rigidbody2D rigid;

    private Animator anim;

    bool Moving = false;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Moving == false)
        {
            H = Input.GetAxisRaw("Horizontal");
            V = Input.GetAxisRaw("Vertical");
        }
       

        if (H < 0.0f)
        {
            transform.localScale = new Vector2(-10, 10);
        }
        else if (H > 0.0f)
        {
            transform.localScale = new Vector2(10, 10);
        }

    }
    void FixedUpdate()
    {
        rigid.velocity = new Vector2(H, V) * speed;
    }

    public void SetAxis(float h, float v)
    {
        h = H;
        v = V;
        if (H == 0 && V == 0)
        {
            Moving = false;
        }
        else
        {
            Moving = true;
        }
    }
}
