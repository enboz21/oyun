using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pla_hareket : ara
{
    private bool deyiyormu = true;
    
    private float arazaman = 0;
    [SerializeField]
    private Image ca;
    private float maxcan;
    private void Start()
    {
        yüz = true;
        fizik = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        maxcan= can;
    }

    void Update()
    {
        cannn();

        if (ani.GetBool("bittihas") && deyiyormu && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
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
        
        float yatay = Input.GetAxis("Horizontal");
        if (ani.GetBool("bittihas"))
        {
            hareket(yatay);
            don(yatay);
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
    private void saldırı()
    {
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            ani.SetTrigger("sald");
        }
    }
    internal int gethasarmik() {         return hasarmik; }
    internal void hasar(int has)
    {
        Debug.Log("Hasar alındı: " + has);
        if (ani.GetBool("bittihas"))
        {
            Debug.Log(can + " can kaldı, " + has + " hasar alındı.");
            ani.SetBool("bittihas", false);
            can -= has;
            if (can <= 0)
            {
                ani.SetTrigger("ölüm");
            }
            else
            {
                ani.SetTrigger("tekhas");
            }
        }
    }
    private void hasarbit()
    {
        ani.SetBool("bittihas", true);
    }
    private void ölüm()
    {
        ani.SetBool("ölümson", true);
        Destroy(gameObject, 1f);
        
        SceneManager.LoadScene(0);
    
}

    private void cannn()
    {
        ca.fillAmount =  can/ maxcan;
    }

}
