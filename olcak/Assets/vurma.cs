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
        if (collision.gameObject.CompareTag("düþman"))
        {
            düþman düþmanScript = collision.gameObject.GetComponent<düþman>();
            pla_hareket parentScript = transform.parent.GetComponent<pla_hareket>();
            düþmanScript.hasar(parentScript.gethasarmik());
        }
    }
}
