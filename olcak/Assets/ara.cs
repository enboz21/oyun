using Unity.Mathematics;
using UnityEngine;

public class ara : MonoBehaviour
{
    [SerializeField]
    internal int can = 30;
    [SerializeField]
    internal int hasarmik=10;
    [SerializeField]
    internal float hýz = 5f;
    internal Rigidbody2D fizik;
    internal bool yüz;
    internal Animator ani;
    [SerializeField]
    internal float artýyükseklik = 0.0009f;
    [SerializeField]
    internal float zýplama = 5f;


    internal void hareket(float yatay)
    {
        if (Mathf.Abs(yatay) > 0)
        {
            Vector3 pozisyon = transform.position;
            pozisyon.y += artýyükseklik;
            transform.position = pozisyon;
        }
        fizik.linearVelocity = new Vector2(hýz * yatay, fizik.linearVelocity.y);
        ani.SetFloat("hýz", math.abs(yatay));
    }
    internal void don(float yatay)
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
