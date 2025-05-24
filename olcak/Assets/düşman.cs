using UnityEngine;

public class düşman : ara
{
    private float fark;
    private bool yön = true;
    private float yatay = -1f;
    private bool dur = false;
    private float durfark;

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

        if (!dur)
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
        don(yatay);
    }
}
