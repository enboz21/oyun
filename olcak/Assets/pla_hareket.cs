using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;

public class pla_hareket : MonoBehaviour
{
    private Rigidbody2D fizik;
    private bool yüz;
    private Animator ani;
    private bool deyiyormu = true;
    [SerializeField] 
    private float hız = 5f;
    [SerializeField]
    private float zıplama = 5f;
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

        if (deyiyormu&&(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
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
        dey=ani.GetBool("deyiyormu");
        float yatay= Input.GetAxis("Horizontal");
        hareket(yatay);
        don(yatay);
        
        
    }
    void hareket(float yatay) 
    {
        
        fizik.linearVelocity = new Vector2(hız * yatay, fizik.linearVelocity.y);
        ani.SetFloat("hız",math.abs(yatay));
    }
    void don(float yatay)
    {
        if (yatay > 0 && !yüz)
        {
            yüz = true;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
        else if (yatay < 0 && yüz)
        {
            yüz = false;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("zemin"))
        {   
            ani.SetBool("zemin", true);
            deyiyormu = true;
        }
    }
    private void saldırı() {
        if (Input.GetKey(KeyCode.LeftAlt)) 
        {
            ani.SetBool("sald", true);
            arazaman = 0;
        }
        if (arazaman >= 1)
        {
            ani.SetBool("sald", false);
            arazaman = 0;
        }
    }
}
