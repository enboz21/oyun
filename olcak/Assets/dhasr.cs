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
            düþman düþmanScript = transform.parent.GetComponent<düþman>();
            parentScript.hasar(düþmanScript.gethasarmik());
            Debug.Log("Player hasar aldý: " + düþmanScript.gethasarmik() + " hasar.");
        }
    }
}
