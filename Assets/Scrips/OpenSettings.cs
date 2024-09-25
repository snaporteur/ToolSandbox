using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenSettings : MonoBehaviour
{
    public void Open()
    {
        SceneManager.LoadScene("Settings");
    }
}
