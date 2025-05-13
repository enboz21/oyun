using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class pla_hareket : MonoBehaviour
{
    private Rigidbody2D fizik;
    private bool yüz;
    private bool deyiyormu = true;
    [SerializeField] 
    private float hız = 5f;
    [SerializeField]
    private float zıplama = 5f;

    private void Start()
    {
        yüz = true;
        fizik = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (deyiyormu&&(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
        {
            deyiyormu = false;
            fizik.AddForce(new Vector2(0, zıplama));
        }

    }  

    void FixedUpdate()
    {
        float yatay= Input.GetAxis("Horizontal");
        hareket(yatay);
        don(yatay);
    }
    void hareket(float yatay) 
    {
        fizik.linearVelocity = new Vector2(hız * yatay, fizik.linearVelocity.y);
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
            deyiyormu = true;
        }
    }
}
