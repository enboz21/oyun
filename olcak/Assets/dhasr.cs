using UnityEngine;

public class dhasr : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            pla_hareket parentScript = collision.gameObject.GetComponent<pla_hareket>();
            d��man d��manScript = transform.parent.GetComponent<d��man>();
            parentScript.hasar(d��manScript.gethasarmik());
            Debug.Log("Player hasar ald�: " + d��manScript.gethasarmik() + " hasar.");
        }
    }
}
