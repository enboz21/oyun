using UnityEngine;

public class düşman : ara
{
    private float fark;
    private bool yön = true;
    private float yatay = -1f;
    [SerializeField]
    private Transform kon;
    [SerializeField]
    private float çapyar;
    [SerializeField]
    private LayerMask katman;
    private bool yeter;
    [SerializeField]
    private float durgun = 2f;
    private float durgunsü;
    [SerializeField]
    private Transform var;
    [SerializeField]
    private LayerMask kat;
    void Start()
    {
        yüz = true;
        fizik = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }


    void Update()
    {
        durgunsü += Time.deltaTime;

    }
    void FixedUpdate()
    {
        yeter = yeterli();
        if (ani.GetBool("son"))
        {
            Destroy(gameObject);
        }
        saldır();

        if (!ani.GetBool("bittihas"))
        {
            if (yeter) // Engel tespit edildiğinde
            {
                // Hareket etmeyi durdur
                ani.SetFloat("hız", 0f);
                fark += Time.deltaTime;

                // 2 saniye bekledikten sonra yön değiştir
                if (fark >= 2f)
                {
                    yön = !yön; // Yönü tersine çevir
                    yatay = yön ? -1f : 1f;
                    fark = 0f;
                    yeter = false; // Tekrar harekete geç
                }
            }
            else
            {
                // Normal hareket
                hareket(yatay);
            }
        }

        
        don(yatay);
    }
    internal void hasar(int has)
    {
        if (!ani.GetBool("bittihas")) {
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
        }
    }
    private void son()
    {

        ani.SetBool("son", true);
        Destroy(gameObject, 1f);
    }
    private void saldbit()
    {
        ani.SetBool("sald", false);
    }
    private void hasarbit()
    {
        ani.SetBool("bittihas", false);
    }
    private bool yeterli()
    {

        Collider2D[] colli = Physics2D.OverlapCapsuleAll(kon.position, new Vector2(çapyar, çapyar), 0f, 0f, katman);
        for(int i = 0; i < colli.Length; i++)
        {
            if (colli[i].gameObject!=gameObject)
            {
                return false;
            }
        }
        return true;
    }
    private void saldır()
    {
        bool a = aa();
        if ((a && !ani.GetBool("sald")) && durgunsü>=durgun)
        {   durgunsü = 0f;
            ani.SetTrigger("saldır");
            ani.SetBool("sald", true);
        }
    }
    internal int gethasarmik() { return hasarmik; }

    private bool aa()
    {

        Collider2D[] colli = Physics2D.OverlapCapsuleAll(var.position, new Vector2(çapyar, çapyar), 0f, 0f, kat);
        for (int i = 0; i < colli.Length; i++)
        {
            if (colli[i].gameObject != gameObject)
            {
                return true;
            }
        }
        return false;
    }

}
