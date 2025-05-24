using Unity.Mathematics;
using UnityEngine;

public class pla_hareket : ara
{
    private bool deyiyormu = true;
    private bool dey;
    private float arazaman = 0;


    private void Start()
    {
        yüz = true;
        fizik = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    void Update()
    {

        if (deyiyormu && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            ani.SetBool("zemin", false);
            deyiyormu = false;
            fizik.AddForce(new Vector2(0, zıplama));
        }
        arazaman += Time.deltaTime;
    }

    void FixedUpdate()
    {
        saldırı();
        ani.SetFloat("yek", fizik.linearVelocity.y);
        dey = ani.GetBool("deyiyormu");
        float yatay = Input.GetAxis("Horizontal");
        hareket(yatay);
        don(yatay);


    }
    
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("zemin"))
        {
            ani.SetBool("zemin", true);
            deyiyormu = true;
        }
    }
    private void saldırı()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            ani.SetTrigger("sald");
        }
    }
    internal int gethasarmik() {         return hasarmik; }
}
