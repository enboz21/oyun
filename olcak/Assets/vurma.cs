using UnityEngine;

public class vurma : MonoBehaviour
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
        if (collision.gameObject.CompareTag("d��man"))
        {
            d��man d��manScript = collision.gameObject.GetComponent<d��man>();
            pla_hareket parentScript = transform.parent.GetComponent<pla_hareket>();
            d��manScript.hasar(parentScript.gethasarmik());
        }
    }
}
