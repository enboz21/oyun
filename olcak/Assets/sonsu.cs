using UnityEngine;

public class sonsu : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            pla_hareket parentScript = collision.gameObject.GetComponent<pla_hareket>();
            parentScript.hasar(1000000);
        }
    }
}
