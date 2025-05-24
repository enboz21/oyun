using UnityEngine;

public class düşman : ara
{
    private float fark;
    private bool yön = true;
    private float yatay = -1f;
    private bool dur = false;
    private float süre= 0f;

    void Start()
    {
        yüz = true;
        fizik = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }


    void Update()
    {

    }
    void FixedUpdate()
    {
        if (ani.GetBool("son"))
        {
            Destroy(gameObject);
        }

        if (!dur && !ani.GetBool("bittihas"))
        {
            if (fark > 2f && yön)
            {
                dur = true;
                yön = false;
                yatay = 1f;
                fark = 0f;
            }
            else if (fark > 2f && !yön)
            {
                dur = true;
                yön = true;
                yatay = -1f;
                fark = 0f;
            }
            hareket(yatay);
        }
        else
        {
            if (fark > 2f)
            {
                fark = 0f;
                dur = false;
            }
            ani.SetFloat("hız", 0f);
        }
        fark += Time.deltaTime;
        süre+=Time.deltaTime;
        don(yatay);
    }
    internal void hasar(int has)
    {
        ani.SetBool("bittihas", true);
        can -= has;
        if (can <= 0)
        {
            ani.SetTrigger("öl");
        }
        else
        {
            ani.SetTrigger("has");
        }
        süre = 0f;
    }
    private void son()
    {
        ani.SetBool("son", true);
    }
    private void hasarbit()
    {
        ani.SetBool("bittihas", false);
    }
    }
