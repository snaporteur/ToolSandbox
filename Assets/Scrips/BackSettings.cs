using UnityEngine;
using UnityEngine.SceneManagement;

public class BackSettings : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }
}
