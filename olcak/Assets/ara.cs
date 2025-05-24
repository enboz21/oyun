using Unity.Mathematics;
using UnityEngine;

public class ara : MonoBehaviour
{
    [SerializeField]
    internal int can = 30;
    [SerializeField]
    internal int hasarmik=10;
    [SerializeField]
    internal float h�z = 5f;
    internal Rigidbody2D fizik;
    internal bool y�z;
    internal Animator ani;
    [SerializeField]
    internal float art�y�kseklik = 0.0009f;
    [SerializeField]
    internal float z�plama = 5f;


    internal void hareket(float yatay)
    {
        if (Mathf.Abs(yatay) > 0)
        {
            Vector3 pozisyon = transform.position;
            pozisyon.y += art�y�kseklik;
            transform.position = pozisyon;
        }
        fizik.linearVelocity = new Vector2(h�z * yatay, fizik.linearVelocity.y);
        ani.SetFloat("h�z", math.abs(yatay));
    }
    internal void don(float yatay)
    {
        if (yatay > 0 && !y�z)
        {
            y�z = true;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
        else if (yatay < 0 && y�z)
        {
            y�z = false;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
