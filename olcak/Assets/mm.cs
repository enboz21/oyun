using UnityEngine;
using UnityEngine.SceneManagement;
public class mm : MonoBehaviour
{
    public void ba()
    {
        int i = SceneManager.GetActiveScene().buildIndex+1;
        SceneManager.LoadScene(i);
    }
    public void çý()
    {
        Application.Quit();
    }
}
