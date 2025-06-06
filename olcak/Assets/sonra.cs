using UnityEngine;
using UnityEngine.SceneManagement;

public class sonra : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    internal static bool ak = false;

    private void Awake()
    {
        gameObject.SetActive(false);
    }
    private void FixedUpdate()
    {
        if (ak)
        {
            gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            pla_hareket.RKaçtane();
            int i = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(i);
        }
        
    }
}
