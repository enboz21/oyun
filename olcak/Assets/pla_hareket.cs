using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class pla_hareket : MonoBehaviour
{
    private Rigidbody2D fizik;
    private bool yüz;
    [SerializeField] 
    private float hız = 5f;
    
    private void Start()
    {
        yüz = true;
        fizik = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
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
}
